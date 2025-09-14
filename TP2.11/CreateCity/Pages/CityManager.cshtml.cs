using CreateCity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CreateCity.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();
        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Message = $"Cidade cadastrada: {Input.CityName}";
            return Page();
        }
        // Classe aninhada para representar os dados de entrada
        public class InputModel
        {
            [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
            [MinLength(3, ErrorMessage = "O nome da cidade deve ter no mínimo 3 caracteres.")]
            public string CityName { get; set; } = string.Empty;
        }
    }
}
