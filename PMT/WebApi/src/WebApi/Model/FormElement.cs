using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;

namespace WebApi.Model
{
    public class FormElement
    {
        public int DisplayedOrder { get; set; }
        public string ElementType { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public bool IsRequired { get; set; }
        public string CssClassName { get; set; }
        public string SpriteCssClassName { get; set; }
        public string Placeholder { get; set; }
        public string Icon { get; set; }
        public string Value { get; set; }
        public bool IsDisabled { get; set; } = false;
        public string ImgUrl { get; set; }
        public string DataSource { get; set; }
        public string DataAttributeValue { get; set; }
        public List<SelectListItem> SelectList { get; set; } = new List<SelectListItem>();


    }
}
