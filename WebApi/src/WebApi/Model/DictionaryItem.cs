namespace WebApi.Model
{
    public class DictionaryItem
    {
        public string Name {get; set;}
        public string Value { get; set; }
        public DictionaryItem(string name, string text)
        {
            Name = name.Replace("\"", "").Trim();
            Value = text.Replace("\"", "").Trim();
        }

    }
}
