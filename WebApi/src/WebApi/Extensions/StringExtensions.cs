using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.DataServer;
using WebApi.TraceInfo;
using WebApi.Model;

namespace WebApi.Extensions.Strings
{
    public static class StringExtensions
    {
        private static SqlServer _sqlDb;
        private static Dictionary<string, object> _parameters;
        public static void EncryptFile(string filePath, byte[] encryptedBytes) => File.WriteAllBytes(filePath, encryptedBytes);
        public static string ReplaceInvalidCharsForUnderscore(this string strvalue) => Path.GetInvalidFileNameChars().Aggregate(ClearInvalidHttpChars(strvalue), (current, c) => current.Replace(c, '_'));
        public static string ClearInvalidHttpChars(this string strvalue) => strvalue.Replace("http", "").Replace("https", "").Replace(":", "").Replace("//", "").Replace("www.", "");
        public static T DeserializeObject<T>(this string json) => JsonConvert.DeserializeObject<T>(json);
        public static string SerializeObject<T>(this T obj) => JsonConvert.SerializeObject(obj);
        public static string ToCamelCase(this string value) => char.ToLowerInvariant(value[0]) + value.Substring(1);
        public static string FormatWith(this string formatString, params object[] args) => args == null || args.Length == 0 ? formatString : string.Format(formatString, args);
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
        public static bool IsNullOrWhitespace(this string value) => string.IsNullOrWhiteSpace(value);
        public static string FirstCharToLower(this string value) => char.ToLowerInvariant(value[0]) + value.Substring(1);
        public static string ExtractString(string source,
            string beginDelim,
            string endDelim,
            bool caseSensitive = false,
            bool allowMissingEndDelimiter = false,
            bool returnDelimiters = false)
        {
            int at1, at2;

            if (string.IsNullOrEmpty(source))
                return string.Empty;

            if (caseSensitive)
            {
                at1 = source.IndexOf(beginDelim, StringComparison.Ordinal);
                if (at1 == -1)
                    return string.Empty;

                at2 = !returnDelimiters
                    ? source.IndexOf(endDelim, at1 + beginDelim.Length, StringComparison.Ordinal)
                    : source.IndexOf(endDelim, at1, StringComparison.Ordinal);
            }
            else
            {
                at1 = source.IndexOf(beginDelim, 0, source.Length, StringComparison.OrdinalIgnoreCase);
                if (at1 == -1)
                    return string.Empty;

                at2 = !returnDelimiters
                    ? source.IndexOf(endDelim, at1 + beginDelim.Length, StringComparison.OrdinalIgnoreCase)
                    : source.IndexOf(endDelim, at1, StringComparison.OrdinalIgnoreCase);
            }

            if (allowMissingEndDelimiter && at2 == -1)
                return source.Substring(at1 + beginDelim.Length);

            if (at1 <= -1 || at2 <= 1) return string.Empty;
            return !returnDelimiters
                ? source.Substring(at1 + beginDelim.Length, at2 - at1 - beginDelim.Length)
                : source.Substring(at1, at2 - at1 + endDelim.Length);
        }

        public static IEnumerable<string> GetFileNames(this string path, string pattern, SearchOption options = SearchOption.AllDirectories)
        {
            foreach (var fileName in Directory.EnumerateFiles(path, pattern))
            {
                yield return fileName;
            }
        }
        public static IEnumerable<string> LoadLines(this string filepath)
        {
                using (FileStream stream = File.OpenRead(filepath))
                {
                    var reader = new StreamReader(stream);
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {

                        yield return line;
                    }
                }
            
        }
        public static async Task<T> LoadAsTypeAsync<T>(this string filePath)
        {
            return await Task.Run(() =>
            {
                var json = File.ReadAllText(filePath);
                var obj = json.DeserializeObject<dynamic>();
                return obj;

            });

        }
        public static async Task<List<T>> LoadAsListTypeAsync<T>(this string filePath)
        {
            return await Task.Run(() =>
            {
                var json = File.ReadAllText(filePath);
                var obj = JsonConvert.DeserializeObject<List<T>>(json);
                return obj;
            });
        }
        public static async Task<string> GetMediasByNameAsync(this string mediaName)
        {
            return await Task.Run(async () =>
            {
                _sqlDb = new SqlServer();
                _parameters = new Dictionary<string, object>();
                string jsonResults;
                try
                {
                    _parameters.Add("Name", mediaName);
                    _parameters.Add("TableName", "medias");
                    jsonResults = await _sqlDb.usp_GetJsonValueAsync("usp_GetComponentByName", _parameters);
                    return jsonResults;
                }
                catch (Exception ex)
                {
                    await Tracer.Error("GetMediasByName", ex.ToString());
                    return string.Empty;
                }
            });
        }
        public static async Task<string> GetPageByNameAsync(this string pageName)
        {
            _sqlDb = new SqlServer();
            _parameters = new Dictionary<string, object>();
            string jsonResults;
            try
            {
                _parameters.Add("Name", pageName);
                _parameters.Add("TableName", "documents");
                jsonResults = await _sqlDb.usp_GetJsonValueAsync("usp_GetComponentByName", _parameters);
            }
            catch (Exception ex)
            {
                await Tracer.Error("PageRepository:GetPageByName", ex.ToString());
                jsonResults = string.Empty;
            }
            return jsonResults;
        }

        public static async Task<List<DictionaryItem>> GetLabelsByNameAsync(this string filePath, string keyword)
        {
            return await Task.Run(() => {
                List<DictionaryItem> definitionList = new List<DictionaryItem>();
                var lines = filePath.LoadLines();
                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line) && (line[0] == '\'')) continue;
                    var commaIndex = line.IndexOf(':');
                    if (commaIndex <= 0) continue;
                    if (commaIndex == line.Length - 1) continue;
                    var name = line.Substring(0, commaIndex);
                    var value = line.Substring(commaIndex + 1, line.Length - commaIndex - 1);
                    if (keyword.Contains("*"))
                    {
                        string tempKeyword = keyword.Replace("*", "");
                        if (name.Contains(tempKeyword))
                        {
                            definitionList.Add(new DictionaryItem(name, value));
                            continue;
                        }
                    }
                    else
                    {
                        if (name.Equals(keyword, StringComparison.CurrentCultureIgnoreCase))
                        {
                            definitionList.Add(new DictionaryItem(name, value));
                            break;
                        }
                    }

                }
                return definitionList;
            });
        }
        public static object ReadFromJson(this string json, string messageType)
        {
            var type = Type.GetType(messageType);
            return JsonConvert.DeserializeObject(json, type);
        }
        public static string RemoveJsonNulls(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;
            var regex = new Regex(UtilityRegExp.JsonNullRegEx);
            var data = regex.Replace(str, string.Empty);

            regex = new Regex(UtilityRegExp.JsonNullWithSpaceRegEx);
            data = regex.Replace(data, string.Empty);

            regex = new Regex(UtilityRegExp.JsonNullArrayRegEx);
            return regex.Replace(data, "[]");
        }
    }
}



