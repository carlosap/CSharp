using System.Collections.Generic;
using System.Linq;
using WebApi.Interfaces;
using WebApi.Model;
using System.Threading.Tasks;
using WebApi.Extensions.Strings;
namespace WebApi.Repository
{
    public class MediaRepository:IMedia
    {
        public async Task<List<Media>> Get(string mediaName)
        {
            return await Task.Run(async () =>
            {
                var medias = new List<Media>();
                var jsonResults = await mediaName.GetMediasByNameAsync();
                if (string.IsNullOrWhiteSpace(jsonResults)) return medias;
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
    }
}


