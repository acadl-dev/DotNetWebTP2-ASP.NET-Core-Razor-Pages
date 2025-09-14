using CreateCity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CreateCity.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        // Agora recebemos o valor direto como parâmetro
        public IActionResult OnPost(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                Message = "Nenhuma cidade foi informada.";
                return Page();
            }

            Message = $"Cidade cadastrada: {cityName}";
            return Page();
        }
    }
}
