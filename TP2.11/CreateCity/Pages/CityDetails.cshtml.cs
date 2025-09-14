using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CreateCity.Pages
{
    public class CityDetailsModel : PageModel
    {
        // Propriedade para exibir na p�gina
        public string CityName { get; set; } = string.Empty;

        // Recebe o par�metro via URL
        public void OnGet(string cityName)
        {
            CityName = cityName;
        }
    }
}
