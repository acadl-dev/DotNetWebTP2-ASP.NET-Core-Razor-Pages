using CreateCity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static CreateCity.Pages.CityManager.CreateCityModel;

namespace CreateCity.Pages
{
    public class CreateCountryModel : PageModel
    {
        // Lista de InputModels para m�ltiplos pa�ses
        [BindProperty]
        public List<InputModel> Inputs { get; set; } = new();

        // Lista de pa�ses adicionados
        public static List<Country> Countries { get; set; } = new();

        public void OnGet()
        {
            // Inicializa 5 linhas vazias para o formul�rio
            if (!Inputs.Any())
            {
                for (int i = 0; i < 5; i++)
                    Inputs.Add(new InputModel());
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var input in Inputs)
            {
                if (!string.IsNullOrWhiteSpace(input.CountryName) && !string.IsNullOrWhiteSpace(input.CountryCode))
                {
                    var country = new Country
                    {
                        Id = Countries.Count + 1,
                        CountryName = input.CountryName,
                        CountryCode = input.CountryCode.ToUpper()
                    };
                    Countries.Add(country);
                }
            }

            // Limpa o formul�rio ap�s submit
            Inputs.Clear();
            for (int i = 0; i < 5; i++)
                Inputs.Add(new InputModel());

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
