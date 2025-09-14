using System.ComponentModel.DataAnnotations;

namespace CreateCity.Models
{
    public class Country
    {
        public int Id { get; set; }


        //Constraints
        [Display(Name = "Nome do país")]
        [Required(ErrorMessage = "Nome obrigatório")]
        [MinLength(2, ErrorMessage = "Nome tem no mínimo dois caracteres")]
        public string CountryName { get; set; }
        public string CountryCode { get; set; }



        public Country() { }

        public Country(int id, string nome, string code)
        {
            Id = id;
            CountryName = nome;
            CountryCode = code;

        }

        public override string ToString()
        {
            return "ID: " + Id + " nome do país: " + CountryName + " código postal: " + CountryCode;
        }
    }
}
