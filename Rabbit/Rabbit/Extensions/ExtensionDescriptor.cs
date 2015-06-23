using System.Collections.Generic;

namespace Rabbit.Extensions
{
    /// <summary>
    /// 扩展描述符。
    /// </summary>
    public sealed class ExtensionDescriptor
    {
        /// <summary>
        /// 标识。
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 特性集合。
        /// </summary>
        public IEnumerable<FeatureDescriptor> Features { get; set; }
    }
}