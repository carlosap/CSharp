using System.Collections.Generic;
namespace WebApi.Model
{
    public class Menu
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public string Class { get; set; }
        public string Sprite { get; set; }
        public string Href { get; set; }
        public string LinkTo { get; set; }
        public string Action { get; set; }
        public string BadgeText { get; set; }
        public string BadgeClass { get; set; }
        public IList<Menu> Items { get; set; } =  new List<Menu>();
    }
}

