using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Padaria03.Data;
using Padaria03.Models;
using System.Threading.Tasks;

namespace Padaria03.Pages.VendaCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Venda Venda { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Venda == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var venda = await _context.Venda.FindAsync(id);

            if (venda != null)
            {
                _context.Venda.Remove(venda);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
