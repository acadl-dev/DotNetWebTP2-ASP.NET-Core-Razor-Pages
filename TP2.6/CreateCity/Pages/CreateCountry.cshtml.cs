using CreateCity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static CreateCity.Pages.CityManager.CreateCityModel;

namespace CreateCity.Pages
{
    public class CreateCountryModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        // Aqui vou armazenar os países temporariamente
        public static List<Country> Countries { get; set; } = new();

        public void OnGet()
        {
        }

        // Método chamado ao submeter o formulário
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Retorna a página com mensagens de validação
            }

            // Criando uma instância de Country a partir do InputModel
            Country newCountry = new Country
            {
                Id = Countries.Count + 1, // Apenas como exemplo, gera um Id incremental
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };

            Countries.Add(newCountry); // Adiciona à lista (em um cenário real, salvar no banco)
            ModelState.Clear();

            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Nome do país é obrigatório")]
            [MinLength(2, ErrorMessage = "Nome do país deve ter no mínimo 2 caracteres")]
            public string CountryName { get; set; }

            [Required(ErrorMessage = "Código do país é obrigatório")]
            [RegularExpression(@"^[A-Za-z]{2}$", ErrorMessage = "O código do país deve ter exatamente 2 letras")]
            public string CountryCode { get; set; }
        }
    }
}
