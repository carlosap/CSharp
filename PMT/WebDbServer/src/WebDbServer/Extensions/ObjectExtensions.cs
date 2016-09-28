using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
//using WebDbServer.Extensions.Strings;

namespace WebDbServer.Extensions.Objects
{
    public static class ObjectExtensions
    {
        public static string GetMessageType(this object obj) => obj.GetType().AssemblyQualifiedName;
        public static string ToJsonString(this object obj) => JsonConvert.SerializeObject(obj);
        public static object StringToTypedValue(string sourceString, Type targetType) => StringToTypedValue(sourceString, targetType, CultureInfo.CurrentCulture);
        public static T StringToTypedValue<T>(string sourceString, CultureInfo culture) => (T)StringToTypedValue(sourceString, typeof(T), culture);
        public static T StringToTypedValue<T>(string sourceString) => (T)StringToTypedValue(sourceString, typeof(T), CultureInfo.CurrentCulture);
        public static object LoadFileAsType(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            return obj;
        }

        public static string SerializeToJson(this object arg, bool checknull = false)
        {
            if (checknull)
            {
                return JsonConvert.SerializeObject(arg, Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });//Todo fixme //RemoveJsonNulls();
            }
            return JsonConvert.SerializeObject(arg);
        }

        public static object StringToTypedValue(string sourceString, Type targetType, CultureInfo culture)
        {
            object result;
            var isEmpty = string.IsNullOrEmpty(sourceString);
            if (targetType == typeof(string))
                result = sourceString;
            else if (targetType == typeof(int) || targetType == typeof(int))
            {
                result = isEmpty ? 0 : int.Parse(sourceString, NumberStyles.Any, culture.NumberFormat);
            }
            else if (targetType == typeof(long))
            {
                if (isEmpty)
                    result = (long) 0;
                else
                    result = long.Parse(sourceString, NumberStyles.Any, culture.NumberFormat);
            }
            else if (targetType == typeof(short))
            {
                if (isEmpty)
                    result = (short) 0;
                else
                    result = short.Parse(sourceString, NumberStyles.Any, culture.NumberFormat);
            }
            else if (targetType == typeof(decimal))
            {
                result = isEmpty ? 0M : decimal.Parse(sourceString, NumberStyles.Any, culture.NumberFormat);
            }
            else if (targetType == typeof(DateTime))
            {
                result = isEmpty ? DateTime.MinValue : Convert.ToDateTime(sourceString, culture.DateTimeFormat);
            }
            else if (targetType == typeof(byte))
            {
                result = isEmpty ? 0 : Convert.ToByte(sourceString);
            }
            else if (targetType == typeof(double))
            {
                result = isEmpty ? 0F : double.Parse(sourceString, NumberStyles.Any, culture.NumberFormat);
            }
            else if (targetType == typeof(float))
            {
                result = isEmpty ? 0F : float.Parse(sourceString, NumberStyles.Any, culture.NumberFormat);
            }
            else if (targetType == typeof(bool))
            {
                if (sourceString != null && (!isEmpty &&
                                             sourceString.ToLower() == "true" || sourceString.ToLower() == "on" ||
                                             sourceString == "1"))
                    result = true;
                else
                    result = false;
            }
            else if (targetType == typeof(Guid))
            {
                result = isEmpty ? Guid.Empty : new Guid(sourceString);
            }
            //else if (targetType.IsEnum)
            //    result = Enum.Parse(targetType, sourceString);
            else if (targetType == typeof(byte[]))
            {
                // TODO: Convert HexBinary string to byte array
                result = null;
            }

            else if (targetType.Name.StartsWith("Nullable`"))
            {
                if (sourceString != null && (sourceString.ToLower() == "null" || sourceString == string.Empty))
                    result = null;
                else
                {
                    targetType = Nullable.GetUnderlyingType(targetType);
                    result = StringToTypedValue(sourceString, targetType);
                }
            }
            else
            {
                var converter = TypeDescriptor.GetConverter(targetType);
                if (converter.CanConvertFrom(typeof(string)))
                    result = converter.ConvertFromString(null, culture, sourceString);
                else
                {
                    Debug.Assert(false,
                        $"Type Conversion not handled in StringToTypedValue for {targetType.Name} {sourceString}");
                    throw new InvalidCastException("StringToTypedValueValueTypeConversionFailed");
                }
            }

            return result;
        }
    }
}
