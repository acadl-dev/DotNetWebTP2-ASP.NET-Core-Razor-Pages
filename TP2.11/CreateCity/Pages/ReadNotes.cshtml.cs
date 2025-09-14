using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CreateCity.Pages
{
    public class ReadNotesModel : PageModel
    {
        // Lista de arquivos dispon�veis
        public List<string> Files { get; set; } = new();

        // Conte�do do arquivo selecionado
        public string? SelectedContent { get; set; }

        // Nome do arquivo selecionado
        [BindProperty(SupportsGet = true)]
        public string? FileName { get; set; }

        public void OnGet()
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Lista apenas arquivos .txt
            Files = Directory.GetFiles(folderPath, "*.txt")
                             .Select(f => Path.GetFileName(f))
                             .ToList();

            // Se um arquivo foi selecionado via query string
            if (!string.IsNullOrEmpty(FileName))
            {
                var fullPath = Path.Combine(folderPath, FileName);
                if (System.IO.File.Exists(fullPath))
                {
                    SelectedContent = System.IO.File.ReadAllText(fullPath);
                }
            }
        }
    }
}
