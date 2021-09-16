using System.Threading.Tasks;
using ApiSandbox.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace ApiSandbox.Pages.Shared
{
    /// <summary>Creates new books to add to our data.</summary>
    public class CreateModel : PageModel
    {
        private readonly ApiSandbox.Data.ApplicationDbContext context;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        public CreateModel(ApiSandbox.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.context = context;
            this.hubContext = hubContext;
            this.mapper = mapper;
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

            Book book = mapper.Map<Book>(Book);
            context.Book.Add(book);
            await this.context.SaveChangesAsync();
            await hubContext.Clients.All.SendAsync("AddedBook", Book);

            return RedirectToPage("./Index");
        }
    }
}
