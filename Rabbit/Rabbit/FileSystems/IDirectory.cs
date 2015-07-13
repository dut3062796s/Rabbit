using System.IO;
using Microsoft.AspNet.FileProviders;
using Microsoft.Framework.Expiration.Interfaces;

namespace Rabbit.FileSystems
{
    /// <summary>
    /// 一个抽象的目录接口。
    /// </summary>
    public interface IDirectory : IDirectoryContents
    {
        /// <summary>
        /// 删除目录。
        /// </summary>
        /// <exception cref="DirectoryNotFoundException">目录不存在。</exception>
        void Delete();

        /// <summary>
        /// 监视。
        /// </summary>
        /// <param name="filter">筛选条件。</param>
        /// <returns>过期触发器。</returns>
        /// <exception cref="DirectoryNotFoundException">目录不存在。</exception>
        IExpirationTrigger Watch(string filter);
    }
}