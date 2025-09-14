using CreateCity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CreateCity.Pages
{
    public class CityManagerModel : PageModel
    {

        [BindProperty]
        public CityName CityName { get; set; }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            
        }
    }
}
