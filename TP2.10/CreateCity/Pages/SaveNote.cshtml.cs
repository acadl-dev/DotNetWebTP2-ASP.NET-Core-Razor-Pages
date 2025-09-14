using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CreateCity.Pages
{
    public class SaveNoteModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        // Caminho do arquivo gerado
        public string? FilePath { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Diret�rio wwwroot/files
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Nome do arquivo com timestamp
            var fileName = $"note-{DateTime.Now:yyyyMMddHHmmss}.txt";
            var fullPath = Path.Combine(folderPath, fileName);

            // Escreve o conte�do no arquivo
            System.IO.File.WriteAllText(fullPath, Input.Content);

            // Salva o caminho relativo para link de download
            FilePath = $"/files/{fileName}";

            // Limpa o formul�rio
            ModelState.Clear();
            Input.Content = string.Empty;

            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "O conte�do da nota � obrigat�rio")]
            [MinLength(1, ErrorMessage = "O conte�do da nota n�o pode ser vazio")]
            public string Content { get; set; } = string.Empty;
        }
    }
}
