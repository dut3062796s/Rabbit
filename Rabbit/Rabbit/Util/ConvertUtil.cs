using System;
using System.Linq;

namespace Rabbit.Util {
    /// <summary>
    /// 将一个基本数据类型转换为另一个基本数据类型。
    /// </summary>
    public static class ConvertUtil {
        /// <summary>
        /// 各种数据类型转换,支持可空值类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="value">源数据</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>转换类型后的结果</returns>
        public static T To<T>(object value, T defaultValue = default(T)) {
            T obj = default(T);
            try {
                if (value == null) {
                    return defaultValue;
                }
                var valueType = value.GetType();
                var targetType = typeof(T);
            label1:
                if (valueType == targetType) {
                    return (T)value;
                }
                if (targetType.IsEnum) {
                    var strValue = value as string;
                    if (strValue != null) {
                        return (T)Enum.Parse(targetType, strValue);
                    }
                    if (value is int) {//判断枚举中是否包含指定值
                        if (Enum.GetValues(targetType).Cast<object>().Any(enumItem => (int)enumItem == (int)value)) {
                            return (T)Enum.ToObject(targetType, value);
                        }
                        return defaultValue;
                    }
                    return (T)Enum.ToObject(targetType, value);
                }
                if (targetType == typeof(Guid) && value is string) {
                    object obj1 = new Guid((string)value);
                    return (T)obj1;
                }
                if (targetType == typeof(DateTime) && value is string) {
                    DateTime dateTime;
                    if (DateTime.TryParse((string)value, out dateTime)) {
                        object obj1 = dateTime;
                        return (T)obj1;
                    }
                }
                if (targetType.IsGenericType) {
                    if (targetType.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                        targetType = Nullable.GetUnderlyingType(targetType);
                        goto label1;
                    }
                }
                if (value is IConvertible) {
                    obj = (T)Convert.ChangeType(value, typeof(T));
                }

                if (obj == null) {
                    obj = defaultValue;
                }
            } catch {
                obj = defaultValue;
            }
            return obj;
        }
    }
}
