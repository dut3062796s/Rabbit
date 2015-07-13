using Microsoft.AspNet.FileProviders;
using Microsoft.Framework.Expiration.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Rabbit.FileSystems.Impl
{
    /// <summary>
    /// 物理目录。
    /// </summary>
    public class PhysicalDirectory : IDirectory
    {
        #region Field

        private readonly string _physicalPath;
        private readonly IDirectoryContents _directoryContents;

        #endregion Field

        #region Constructor

        public PhysicalDirectory(string physicalPath, IDirectoryContents directoryContents)
        {
            _physicalPath = physicalPath;
            _directoryContents = directoryContents;
        }

        #endregion Constructor
        #region Implementation of IEnumerable

        /// <summary>
        /// 返回一个循环访问集合的枚举器。
        /// </summary>
        /// <returns>
        /// 可用于循环访问集合的 <see cref="T:System.Collections.Generic.IEnumerator`1"/>。
        /// </returns>
        public IEnumerator<IFileInfo> GetEnumerator()
        {
            return _directoryContents.GetEnumerator();
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举器。
        /// </summary>
        /// <returns>
        /// 可用于循环访问集合的 <see cref="T:System.Collections.IEnumerator"/> 对象。
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion Implementation of IEnumerable

        #region Implementation of IDirectoryContents

        /// <summary>
        /// True if a directory was located at the given path.
        /// </summary>
        public bool Exists => _directoryContents.Exists;

        /// <summary>
        /// 删除目录。
        /// </summary>
        /// <exception cref="DirectoryNotFoundException">目录不存在。</exception>
        public void Delete()
        {
            if (!Exists)
                throw new DirectoryNotFoundException($"未能找到目录 “{Path.GetDirectoryName(_physicalPath)}”");

            Directory.Delete(_physicalPath);
        }

        /// <summary>
        /// 监视。
        /// </summary>
        /// <param name="filter">筛选条件。</param>
        /// <returns>过期触发器。</returns>
        /// <exception cref="DirectoryNotFoundException">目录不存在。</exception>
        public IExpirationTrigger Watch(string filter)
        {
            if (!Exists)
                throw new DirectoryNotFoundException($"未能找到目录 “{Path.GetDirectoryName(_physicalPath)}”");
            
            var root = _physicalPath;
            return new PhysicalFileProvider(root).Watch(filter);
        }

        #endregion Implementation of IDirectoryContents
    }
}