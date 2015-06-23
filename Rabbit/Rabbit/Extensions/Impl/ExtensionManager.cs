using Rabbit.Caching;
using Rabbit.Extensions.Folders;
using Rabbit.Extensions.Loaders;
using Rabbit.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rabbit.Extensions.Impl
{
    public class ExtensionManager : IExtensionManager
    {
        private readonly ICacheManager _cacheManager;
        private readonly IParallelCacheContext _parallelCacheContext;
        private readonly IEnumerable<IExtensionFolders> _folders;
        private readonly IEnumerable<IExtensionLoader> _loaders;
        private readonly IAsyncTokenProvider _asyncTokenProvider;

        public ExtensionManager(ICacheManager cacheManager, IParallelCacheContext parallelCacheContext, IEnumerable<IExtensionFolders> folders, IEnumerable<IExtensionLoader> loaders, IAsyncTokenProvider asyncTokenProvider)
        {
            _cacheManager = cacheManager;
            _parallelCacheContext = parallelCacheContext;
            _folders = folders;
            _loaders = loaders;
            _asyncTokenProvider = asyncTokenProvider;

            Logger = NullLogger.Instance;
        }

        #region Property

        public ILogger Logger { get; set; }

        #endregion Property

        #region Implementation of IExtensionManager

        /// <summary>
        /// 可用的扩展。
        /// </summary>
        /// <returns>扩展描述符条目集合。</returns>
        public IEnumerable<ExtensionDescriptor> AvailableExtensions()
        {
            return _cacheManager.Get("AvailableExtensions", ctx => _parallelCacheContext
                .RunInParallel(_folders, folder => folder.AvailableExtensions().ToArray())
                .SelectMany(entrys => entrys).ToArray());
        }

        /// <summary>
        /// 可用的特性。
        /// </summary>
        /// <returns>特性描述符集合。</returns>
        public IEnumerable<FeatureDescriptor> AvailableFeatures()
        {
            return _cacheManager.Get("AvailableFeatures", ctx => AvailableExtensions()
                .SelectMany(ext => ext.Features))
                //                .OrderByDependenciesAndPriorities(HasDependency, GetPriority)
                .ToArray();
        }

        /// <summary>
        /// 根据扩展Id获取指定的扩展描述符条目。
        /// </summary>
        /// <param name="id">扩展Id。</param>
        /// <returns>扩展描述符。</returns>
        public ExtensionDescriptor GetExtension(string id)
        {
            return AvailableExtensions().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// 加载特性。
        /// </summary>
        /// <param name="featureDescriptors">特性描述符。</param>
        /// <returns>特性集合。</returns>
        public IEnumerable<Feature> LoadFeatures(IEnumerable<FeatureDescriptor> featureDescriptors)
        {
            Logger.Information("加载特性");

            var result =
                _parallelCacheContext
                .RunInParallel(featureDescriptors, descriptor => _cacheManager.Get(descriptor.Id, ctx => LoadFeature(descriptor)))
                .ToArray();

            Logger.Information("完成特性加载");
            return result;
        }

        #endregion Implementation of IExtensionManager

        #region Private Method

        private Feature LoadFeature(FeatureDescriptor featureDescriptor)
        {
            var extensionDescriptor = featureDescriptor.Extension;
            var featureId = featureDescriptor.Id;
            var extensionId = extensionDescriptor.Id;

            ExtensionEntry extensionEntry;
            try
            {
                extensionEntry = _cacheManager.Get(extensionId, ctx =>
                {
                    var entry = BuildEntry(extensionDescriptor);
                    /*                    if (entry != null)
                                        {
                                            ctx.Monitor(_asyncTokenProvider.GetToken(monitor =>
                                            {
                                                foreach (var loader in _loaders.Value)
                                                {
                                                    loader.Monitor(entry.Descriptor, monitor);
                                                }
                                            }));
                                        }*/
                    return entry;
                });
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "加载扩展 '{0}' 失败", extensionId);
                throw new RabbitException(string.Format("加载扩展 '{0}' 失败。", extensionId), ex);
            }

            if (extensionEntry == null)
            {
                //如果该功能因为某种原因不能被编译，返回一个"null"的特性，即没有输出的类型的功能。
                return new Feature
                {
                    Descriptor = featureDescriptor,
                    ExportedTypes = Enumerable.Empty<Type>()
                };
            }

            var extensionTypes = extensionEntry.ExportedTypes;

            var featureTypes = extensionTypes.Where(
                i =>
                    string.Equals(GetSourceFeatureNameForType(i, extensionId), featureId,
                        StringComparison.OrdinalIgnoreCase)).ToArray();

            return new Feature
            {
                Descriptor = featureDescriptor,
                ExportedTypes = featureTypes
            };
        }

        private ExtensionEntry BuildEntry(ExtensionDescriptor descriptor)
        {
            var entry = _loaders.Select(loader => loader.Load(descriptor)).FirstOrDefault(i => i != null);
            if (entry == null)
                Logger.Warning("没有发现适合扩展 \"{0}\" 的装载机", descriptor.Id);
            return entry;
        }

        private static string GetSourceFeatureNameForType(Type type, string extensionId)
        {
            /*foreach (FeatureAttribute featureAttribute in type.GetCustomAttributes(typeof(FeatureAttribute), false))
                return featureAttribute.FeatureName;*/
            return extensionId;
        }

        #endregion Private Method
    }
}