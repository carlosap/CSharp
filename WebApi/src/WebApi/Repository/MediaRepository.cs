using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DataServer;
using WebApi.Interfaces;
using WebApi.Model;
using WebApi.TraceInfo;
using System.Threading.Tasks;
using WebApi.Extensions.Strings;
namespace WebApi.Repository
{
    public class MediaRepository:IMedia
    {
        private static SqlServer _sqlDb;
        private static Dictionary<string, object> _parameters;
        public async Task<List<Media>> Get(string mediaName)
        {
            return await Task.Run(async () =>
            {
                var medias = new List<Media>();
                var jsonResults = await GetMediasByName(mediaName);
                if (string.IsNullOrWhiteSpace(jsonResults)) return medias;
                await Tracer.Msg($"GetMediasByName:{mediaName}", jsonResults);
                var jsMedia = jsonResults.DeserializeObject<List<Media>>();
                if (!jsMedia.Any()) return medias;
                medias.AddRange(jsMedia.Select(media => new Media
                {
                    Id = media.Id,
                    Description =
                    media.Description,
                    Title = media.Title,
                    FileUrl = media.FileUrl,
                    FileExtension = media.FileExtension,
                    ContentType = media.ContentType,
                    ContentLength = media.ContentLength,
                    FileName = media.FileName,
                    DisplayOrder = media.DisplayOrder,
                    Width = media.Width,
                    Height = media.Height
                }));
                return medias;
            });

        }
        private static async Task<string> GetMediasByName(string mediaName)
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
                    await Tracer.Msg($"GetMediasByName:{mediaName}", jsonResults);
                    return jsonResults;
                }
                catch (Exception ex)
                {
                    await Tracer.Error("GetMediasByName", ex.ToString());
                    return string.Empty;
                }
            });
        }
    }
}


