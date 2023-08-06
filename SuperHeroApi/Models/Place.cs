using System.ComponentModel.DataAnnotations;

namespace SuperHeroApi.Models
{
    public class Place
    {
        [Key()]
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public virtual ICollection<SuperHero>? Heroes { get; set; }
    }
}
