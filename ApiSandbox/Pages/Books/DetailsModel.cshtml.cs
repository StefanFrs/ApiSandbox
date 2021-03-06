using System.Threading.Tasks;
using ApiSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Pages.Shared
{
    /// <summary>Shows details about a book.</summary>
    public class DetailsModel : PageModel
    {
        private readonly ApiSandbox.Data.ApplicationDbContext context;

        public DetailsModel(ApiSandbox.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await this.context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
