namespace WebApi.Model
{
    public class Media
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string FileUrl { get; set; }
        public string FileExtension { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public string FileName { get; set; }
        public int DisplayOrder { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

    }
}


