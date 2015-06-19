using System;

namespace Rabbit.Util.Extensions {
    /// <summary>
    /// 对象扩展方法。
    /// </summary>
    internal static class ObjectExtensions {
        /// <summary>
        /// 不允许为Null。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="instance">对象实例。</param>
        /// <param name="paramName">参数名称。</param>
        /// <returns>对象实例。</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> 为null。</exception>
        public static T NotNull<T>(this T instance, string paramName) where T : class {
            if (instance == null)
                throw new ArgumentNullException(paramName.NotEmpty("paramName"));
            return instance;
        }

        /// <summary>
        /// 不允许空字符串。
        /// </summary>
        /// <param name="str">字符串。</param>
        /// <param name="paramName">参数名称。</param>
        /// <returns>字符串。</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> 为空。</exception>
        public static string NotEmpty(this string str, string paramName) {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentNullException(paramName.NotEmpty("paramName"));
            return str;
        }

        /// <summary>
        /// 不允许空和只包含空格的字符串。
        /// </summary>
        /// <param name="str">字符串。</param>
        /// <param name="paramName">参数名称。</param>
        /// <returns>字符串。</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> 为空或者全为空格。</exception>
        public static string NotEmptyOrWhiteSpace(this string str, string paramName) {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException(paramName.NotEmpty("paramName"));
            return str;
        }


    }
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