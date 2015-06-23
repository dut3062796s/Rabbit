using Rabbit.Extensions;
using System;

namespace Rabbit.Environment.Builders
{
    /// <summary>
    /// 蓝图项。
    /// </summary>
    public abstract class BlueprintItem
    {
        /// <summary>
        /// 类型。
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// 所属功能。
        /// </summary>
        public Feature Feature { get; set; }
    }
}