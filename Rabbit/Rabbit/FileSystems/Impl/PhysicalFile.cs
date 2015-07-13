using Microsoft.AspNet.FileProviders;
using Microsoft.Framework.Expiration.Interfaces;
using System;
using System.IO;

namespace Rabbit.FileSystems.Impl
{
    /// <summary>
    /// 物理文件。
    /// </summary>
    public class PhysicalFile : IFile
    {
        #region Field

        private readonly IFileInfo _fileInfo;

        #endregion Field

        #region Constructor

        public PhysicalFile(IFileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }

        #endregion Constructor

        #region Implementation of IFileInfo

        /// <summary>
        /// Return file contents as readonly stream. Caller should dispose stream when complete.
        /// </summary>
        /// <returns>
        /// The file stream
        /// </returns>
        public Stream CreateReadStream()
        {
            return _fileInfo.CreateReadStream();
        }

        /// <summary>
        /// True if resource exists in the underlying storage system.
        /// </summary>
        public bool Exists => _fileInfo.Exists;

        /// <summary>
        /// The length of the file in bytes, or -1 for a directory or non-existing files.
        /// </summary>
        public long Length => _fileInfo.Length;

        /// <summary>
        /// The path to the file, including the file name. Return null if the file is not directly accessible.
        /// </summary>
        public string PhysicalPath => _fileInfo.PhysicalPath;

        /// <summary>
        /// The name of the file or directory, not including any path.
        /// </summary>
        public string Name => _fileInfo.Name;

        /// <summary>
        /// When the file was last modified
        /// </summary>
        public DateTimeOffset LastModified => _fileInfo.LastModified;

        /// <summary>
        /// True for the case TryGetDirectoryContents has enumerated a sub-directory
        /// </summary>
        public bool IsDirectory => _fileInfo.IsDirectory;

        #endregion Implementation of IFileInfo

        #region Implementation of IFile

        /// <summary>
        /// 创建一个支持写入的文件流。
        /// </summary>
        /// <returns>支持写入的文件流。</returns>
        /// <exception cref="FileNotFoundException">文件不存在。</exception>
        public Stream CreateWriterStream()
        {
            if (!Exists)
                throw new FileNotFoundException($"未能找到文件 “{_fileInfo.Name}”");

            return File.OpenWrite(_fileInfo.PhysicalPath);
        }

        /// <summary>
        /// 文件如果存在则删除文件。
        /// </summary>
        /// <exception cref="FileNotFoundException">文件不存在。</exception>
        public void Delete()
        {
            if (!Exists)
                throw new FileNotFoundException($"未能找到文件 “{_fileInfo.Name}”");

            File.Delete(_fileInfo.PhysicalPath);
        }

        /// <summary>
        /// 监视。
        /// </summary>
        /// <returns>过期触发器。</returns>
        /// <exception cref="FileNotFoundException">文件不存在。</exception>
        public IExpirationTrigger Watch()
        {
            if (!Exists)
                throw new FileNotFoundException($"未能找到文件 “{_fileInfo.Name}”");

            var path=_fileInfo.PhysicalPath;
            var root = Path.GetDirectoryName(path);
            var provider=new PhysicalFileProvider(root);

            return provider.Watch(Path.GetFileName(path));
        }

        #endregion Implementation of IFile
    }
}