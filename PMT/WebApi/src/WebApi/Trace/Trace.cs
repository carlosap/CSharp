using WebApi.Extensions.Strings;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
namespace WebApi.TraceInfo
{
    public static class Tracer
    {     
        public static Task Exception(string name, Exception exception,bool isTraceEnable = true) => Task.Run(async () =>
        {
            await Task.Run(async () =>
            {
                string filePath = await GetFilePath(name, TraceType.Exceptions);
                var content = $"Name:{name}{Environment.NewLine}Exception: {exception.ToString()}";
                if (isTraceEnable)
                {
                    Trace.TraceError(exception.ToString());
                    File.WriteAllText(filePath, content);
                }
            });
        });
        public static Task Error(string name, string strError, bool isTraceEnable = true) => Task.Run(async () =>
        {
            await Task.Run(async () =>
            {
                string filePath = await GetFilePath(name, TraceType.Errors);
                var content = $"Name:{name}{Environment.NewLine}Error: {strError}";
                if (isTraceEnable)
                {
                    Trace.TraceError(strError);
                    File.WriteAllText(filePath, content);
                }
            });

        });

        public static Task Msg(string name, string strInformation, bool isTraceEnable = true) => Task.Run(async () =>
        {
            await Task.Run(async () =>
            {
                string filePath = await GetFilePath(name, TraceType.Msgs);
                var content = $"Name:{name}{Environment.NewLine}Message: {strInformation}";
                if (isTraceEnable)
                {
                    Trace.TraceInformation(strInformation);
                    File.WriteAllText(filePath, content);
                }
            });
        });
        public static Task Warning(string name,string strWarningInfo, bool isTraceEnable = true) => Task.Run(async () =>
        {
            await Task.Run(async () =>
            {
                string filePath = await GetFilePath(name, TraceType.Warnings);
                var content = $"Name:{name}{Environment.NewLine}Warning: {strWarningInfo}";
                if (isTraceEnable)
                {
                    Trace.TraceInformation(strWarningInfo);
                    File.WriteAllText(filePath, content);
                }
            });
        });
        private static Task<string> AddDatemeStringValues(string strName) => Task.Run(() =>{ return $"{strName}-{DateTime.Now:yyyy-MM-dd_hh-mm-ss-tt}";});
        private static async Task<string> GetFilePath(string traceName, TraceType traceType)
        {
            return await Task.Run(async () =>
            {
                string traceExtension = await GetFileExtension(traceType);
                var directoryPath = Path.Combine(Startup._appEnvironment.ApplicationBasePath, "Logs", traceType.ToString());
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                traceName = traceName.ReplaceInvalidCharsForUnderscore();
                traceName = await AddDatemeStringValues(traceName);
                traceName = $"{traceName}{traceExtension}";
                var filePath = Path.Combine(directoryPath, traceName);
                return filePath;
            });
        }
        private static Task<string> GetFileExtension(TraceType traceType)
        {
            return Task.Run(() =>
            {
                var traceExtension = string.Empty;
                switch (traceType)
                {
                    case TraceType.Exceptions:
                        traceExtension = ".ex";
                        break;
                    case TraceType.Errors:
                        traceExtension = ".err";
                        break;
                    case TraceType.Msgs:
                        traceExtension = ".log";
                        break;
                    case TraceType.Warnings:
                        traceExtension = ".warn";
                        break;
                    default:
                        traceExtension = ".unknown";
                        break;
                }
                return traceExtension;
            });
        }
    }
}
