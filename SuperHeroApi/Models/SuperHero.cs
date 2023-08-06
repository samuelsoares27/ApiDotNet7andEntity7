using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroApi.Models
{
    public class SuperHero
    {
        [Key()]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [ForeignKey("IdPlace")]
        public int IdPlace { get; set; }
        public virtual Place? Place { get; set; }
    }
}
