using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CreateCity.Pages
{
    public class CitiesListModel : PageModel
    {
        // Lista de cidades
        public List<string> Cities { get; set; } = new List<string>
        {
            "Rio",
            "São Paulo",
            "Brasília"
        };
    }
}
