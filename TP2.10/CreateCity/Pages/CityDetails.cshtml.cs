using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CreateCity.Pages
{
    public class CityDetailsModel : PageModel
    {
        // Propriedade para exibir na página
        public string CityName { get; set; } = string.Empty;

        // Recebe o parâmetro via URL
        public void OnGet(string cityName)
        {
            CityName = cityName;
        }
    }
}
