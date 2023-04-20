using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Browser.Policy.Razor.Pages
{
    public class MasterclassModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
