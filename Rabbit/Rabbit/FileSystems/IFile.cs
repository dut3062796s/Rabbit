using Microsoft.AspNet.FileProviders;
using Microsoft.Framework.Expiration.Interfaces;
using System.IO;

namespace Rabbit.FileSystems
{
    /// <summary>
    /// 一个抽象的文件接口。
    /// </summary>
    public interface IFile : IFileInfo
    {
        /// <summary>
        /// 创建一个支持写入的文件流。
        /// </summary>
        /// <returns>支持写入的文件流。</returns>
        /// <exception cref="FileNotFoundException">文件不存在。</exception>
        Stream CreateWriterStream();

        /// <summary>
        /// 文件如果存在则删除文件。
        /// </summary>
        /// <exception cref="FileNotFoundException">文件不存在。</exception>
        void Delete();

        /// <summary>
        /// 监视。
        /// </summary>
        /// <returns>过期触发器。</returns>
        /// <exception cref="FileNotFoundException">文件不存在。</exception>
        IExpirationTrigger Watch();
    }
}