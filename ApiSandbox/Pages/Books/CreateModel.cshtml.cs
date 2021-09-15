using System.Threading.Tasks;
using ApiSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiSandbox.Pages.Shared
{
    /// <summary>Creates new books to add to our data.</summary>
    public class CreateModel : PageModel
    {
        private readonly ApiSandbox.Data.ApplicationDbContext context;

        public CreateModel(ApiSandbox.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this.context.Book.Add(Book);
            await this.context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
