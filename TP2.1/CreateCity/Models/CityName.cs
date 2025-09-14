using System.ComponentModel.DataAnnotations;

namespace CreateCity.Models
{
    public class CityName
    {
        public int Id { get; set; }
        //Constraints
        [Display(Name = "Nome da cidade")]
        [Required(ErrorMessage = "Nome obrigatório")]
        [MinLength(2, ErrorMessage = "Nome tem no mínimo dois caracteres")]
        public string Nome { get; set; }

        

        public CityName() { }

        public CityName(int id, string nome)
        {
            Id = id;
            Nome = nome;
            
        }

        public override string ToString()
        {
            return "ID: " + Id + " nome da cidade: " + Nome;
        }
    }
}
