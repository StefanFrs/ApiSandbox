using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSandbox.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApiSandbox.Pages.Shared
{
    /// <summary>Model for main dashboard of books.</summary>
    public class IndexModel : PageModel
    {
        private readonly ApiSandbox.Data.ApplicationDbContext context;

        public IndexModel(ApiSandbox.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            Book = await this.context.Book.ToListAsync();
        }
    }
}
