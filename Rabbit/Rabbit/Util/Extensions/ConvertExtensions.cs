using System;

namespace Rabbit.Util.Extensions
{
    /// <summary>
    /// 将一个基本数据类型转换为另一个基本数据类型的扩展方法。
    /// </summary>
    public static class ConvertExtensions {
        public static T Convert<T>(this string value, T defaultValue = default(T)) {
            return ConvertUtil.To(value, defaultValue);
        }
        public static T Convert<T>(this Enum value, T defaultValue = default(T)) {
            return ConvertUtil.To(value, defaultValue);
        }
        public static T Convert<T>(this int value, T defaultValue = default(T)) {
            return ConvertUtil.To(value, defaultValue);
        }
        public static T Convert<T>(this object value, T defaultValue = default(T)) {
            return ConvertUtil.To(value, defaultValue);
        }
    }
}