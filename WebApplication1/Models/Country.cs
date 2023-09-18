namespace WebApplication1.Models
{
    public class Country : IComparable<Country>
    {
        public NameCountry Name { get; set; } = new NameCountry();
        public List<string> Capital { get; set; } = new List<string>();
        public string Region { get; set; } = string.Empty;
        public Dictionary<string, string> Languages { get; set; } = new Dictionary<string, string>();
        public int CompareTo(Country country)
        {
            if (country == null)
            {
                return 1;
            }
            return Comparer<string>.Default.Compare(Name.Official, country.Name.Official);
        }
    }
    public class NameCountry
    {
        public string Common { get; set; }
        public string Official { get; set; }
    }
}
