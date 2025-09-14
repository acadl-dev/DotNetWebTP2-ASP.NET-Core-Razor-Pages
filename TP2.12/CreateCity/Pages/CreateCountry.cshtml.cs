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
            // Valida Data Annotations primeiro
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Valida��o customizada: primeira letra do nome e c�digo deve ser igual
            if (!string.IsNullOrEmpty(Input.CountryName) && !string.IsNullOrEmpty(Input.CountryCode))
            {
                var firstLetterName = Input.CountryName[0].ToString().ToUpper();
                var firstLetterCode = Input.CountryCode[0].ToString().ToUpper();

                if (firstLetterName != firstLetterCode)
                {
                    // Adiciona erro espec�fico ao campo CountryCode
                    ModelState.AddModelError("Input.CountryCode", "A primeira letra do c�digo deve ser igual � do nome do pa�s.");
                    return Page();
                }
            }

            // Cria a inst�ncia do pa�s
            var newCountry = new Country
            {
                Id = Countries.Count + 1,
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode.ToUpper()
            };

            Countries.Add(newCountry);

            // Limpa o formul�rio
            ModelState.Clear();
            Input = new InputModel();

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
