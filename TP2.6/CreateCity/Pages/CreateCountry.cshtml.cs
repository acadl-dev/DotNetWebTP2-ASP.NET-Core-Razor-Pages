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

        // Aqui vou armazenar os pa�ses temporariamente
        public static List<Country> Countries { get; set; } = new();

        public void OnGet()
        {
        }

        // M�todo chamado ao submeter o formul�rio
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Retorna a p�gina com mensagens de valida��o
            }

            // Criando uma inst�ncia de Country a partir do InputModel
            Country newCountry = new Country
            {
                Id = Countries.Count + 1, // Apenas como exemplo, gera um Id incremental
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };

            Countries.Add(newCountry); // Adiciona � lista (em um cen�rio real, salvar no banco)
            ModelState.Clear();

            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Nome do pa�s � obrigat�rio")]
            [MinLength(2, ErrorMessage = "Nome do pa�s deve ter no m�nimo 2 caracteres")]
            public string CountryName { get; set; }

            [Required(ErrorMessage = "C�digo do pa�s � obrigat�rio")]
            [RegularExpression(@"^[A-Za-z]{2}$", ErrorMessage = "O c�digo do pa�s deve ter exatamente 2 letras")]
            public string CountryCode { get; set; }
        }
    }
}
