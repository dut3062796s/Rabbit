namespace Rabbit.Extensions
{
    /// <summary>
    /// 功能描述符。
    /// </summary>
    public sealed class FeatureDescriptor
    {
        /// <summary>
        /// 标识。
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 扩展描述符。
        /// </summary>
        public ExtensionDescriptor Extension { get; set; }
    }
}