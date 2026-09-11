using System.ComponentModel.DataAnnotations;

namespace Sales108.Web.Data.Entities
{
    public class City
    {

        public int Id { get; set; }


        [Display(Name = "Cidade")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres!")]
        [Required]
        public string? Name { get; set; }  

        public State? State { get; set; }

        public int StateId { get; set; }
    }
}
