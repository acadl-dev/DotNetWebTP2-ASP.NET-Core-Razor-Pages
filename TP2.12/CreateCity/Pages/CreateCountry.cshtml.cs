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
            // Valida Data Annotations primeiro
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Validação customizada: primeira letra do nome e código deve ser igual
            if (!string.IsNullOrEmpty(Input.CountryName) && !string.IsNullOrEmpty(Input.CountryCode))
            {
                var firstLetterName = Input.CountryName[0].ToString().ToUpper();
                var firstLetterCode = Input.CountryCode[0].ToString().ToUpper();

                if (firstLetterName != firstLetterCode)
                {
                    // Adiciona erro específico ao campo CountryCode
                    ModelState.AddModelError("Input.CountryCode", "A primeira letra do código deve ser igual à do nome do país.");
                    return Page();
                }
            }

            // Cria a instância do país
            var newCountry = new Country
            {
                Id = Countries.Count + 1,
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode.ToUpper()
            };

            Countries.Add(newCountry);

            // Limpa o formulário
            ModelState.Clear();
            Input = new InputModel();

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
