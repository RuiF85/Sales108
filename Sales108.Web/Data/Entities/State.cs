using System.ComponentModel.DataAnnotations;

namespace Sales108.Web.Data.Entities
{
    public class State : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Estado/Província")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres!")]
        [Required]
        public string? Name { get; set; }

        public Country? Country { get; set; }

        public int CountryId { get; set; }

        public ICollection<City>? Cities { get; set; } = new List<City>();

        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
