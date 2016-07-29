using WebApi.Interfaces;
using WebApi.Model;
using WebApi.Extensions.Strings;
using System.Threading.Tasks;
namespace WebApi.Repository
{
    public class PageRepository : IPage
    {

        public async Task<Page> Get(string pageName)
        {
            return await Task.Run(async () =>
            {
                var pageResults = new Page();
                var jsonResults = await pageName.GetPageByNameAsync();
                if (string.IsNullOrWhiteSpace(jsonResults)) return pageResults;
                var jsPage = jsonResults.DeserializeObject<dynamic>();
                foreach (var props in jsPage)
                {
                    foreach (var item in props)
                    {
                        if (item.Name.ToString().ToLower() == "id") pageResults.Id = item.Value;
                        if (item.Name.ToString().ToLower() == "guid") pageResults.Guid = item.Value;
                        if (item.Name.ToString().ToLower() == "documenttype") pageResults.Type = item.Value;
                        if (item.Name.ToString().ToLower() == "name") pageResults.Name = item.Value;
                        if (item.Name.ToString().ToLower() == "displayorder") pageResults.DisplayOrder = item.Value;
                        if (item.Name.ToString().ToLower() == "urlsegment") pageResults.UrlSegment = item.Value;
                        if (item.Name.ToString().ToLower() == "hidden") pageResults.Hidden = item.Value == "1";
                        if (item.Name.ToString().ToLower() == "metatitle") pageResults.MetaKeywords = item.Value;
                        if (item.Name.ToString().ToLower() == "metadescription") pageResults.MetaDescription = item.Value;
                        if (item.Name.ToString().ToLower() == "isgallery") pageResults.IsGallery = item.Value == "1";
                        if (item.Name.ToString().ToLower() == "seotargetphrase") pageResults.SEoTargetPhrase = item.Value;
                        if (item.Name.ToString().ToLower() == "revealinnavigation")
                            pageResults.RevealInNavigation = item.Value == "1";
                        if (item.Name.ToString().ToLower() == "requiresssl") pageResults.RequiresSsl = item.Value == "1";
                        if (item.Name.ToString().ToLower() == "publishon") pageResults.PublishOn = item.Value;
                        if (item.Name.ToString().ToLower() == "blockanonymousaccess")
                            pageResults.BlockAnonymousAccess = item.Value == "1";
                        if (item.Name.ToString().ToLower() == "bodycontent") pageResults.BodyContent = item.Value;
                        if (item.Name.ToString().ToLower() == "metakeywords") pageResults.MetaKeywords = item.Value;
                        if (item.Name.ToString().ToLower() == "customfooterscripts")
                            pageResults.CustomFooterScripts = item.Value;
                        if (item.Name.ToString().ToLower() == "customheaderscripts")
                            pageResults.CustomHeaderScripts = item.Value;
                        if (item.Name.ToString().ToLower() == "pagetemplateid") pageResults.PageTemplateId = item.Value;
                        if (item.Name.ToString().ToLower() == "redirecturl") pageResults.RedirectUrl = item.Value;
                        if (item.Name.ToString().ToLower() == "permanent") pageResults.Permanent = item.Value;
                        if (item.Name.ToString().ToLower() == "featureimage") pageResults.FeatureImage = item.Value;
                        if (item.Name.ToString().ToLower() == "allowpaging") pageResults.AllowPaging = item.Value;
                        if (item.Name.ToString().ToLower() == "redirecturl") pageResults.RedirectUrl = item.Value;
                        if (item.Name.ToString().ToLower() == "thumbnailimage") pageResults.ThumbnailImage = item.Value;
                    }
                }
                return pageResults;
            });
        }
    }
}
