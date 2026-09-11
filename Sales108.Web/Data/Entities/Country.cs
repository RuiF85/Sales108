using System.ComponentModel.DataAnnotations;

namespace Sales108.Web.Data.Entities
{
    public class Country : IEntity
    {
        public int Id { get; set; }


        [Display(Name ="País")]
        [MaxLength(50, ErrorMessage = " O campo {0} deve ter no máximo {1} caracteres!")]
        [Required(ErrorMessage ="O campo {0} é obrigatorio!")]
        public string? Name { get; set; }

        public ICollection<State>? States { get; set; } = new List<State>();

        public int StatesNumber => States == null ? 0 : States.Count;
    }
}
