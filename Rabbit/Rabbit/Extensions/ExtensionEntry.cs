using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rabbit.Extensions
{
    /// <summary>
    /// 扩展条目。
    /// </summary>
    public sealed class ExtensionEntry
    {
        /// <summary>
        /// 扩展描述符。
        /// </summary>
        public ExtensionDescriptor Descriptor { get; set; }

        /// <summary>
        /// 扩展程序集。
        /// </summary>
        public Assembly Assembly { get; set; }

        /// <summary>
        /// 扩展导出类型集合。
        /// </summary>
        public IEnumerable<Type> ExportedTypes { get; set; }
    }
}