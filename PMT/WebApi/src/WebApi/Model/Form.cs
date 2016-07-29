using System.Collections.Generic;
namespace WebApi.Model
{
    public class Form
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public string Method { get; set; } = "GET";
        public string Target { get; set; } = "_self";
        public string Charset { get; set; }
        public string Enctype { get; set; } = "url-encoded";
        public string Autocomplete { get; set; } = "on";
        public bool Novalidate { get; set; } = true;
        public string CssClassName { get; set; }
        public string SpriteCssClassName { get; set; }
        public string DataAttributeValue { get; set; }
        public List<FormElement> Elements = new List<FormElement>();

    }
}
    