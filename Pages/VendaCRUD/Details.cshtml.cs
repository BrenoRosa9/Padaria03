using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Padaria03.Data;
using Padaria03.Models;
using System.Threading.Tasks;

namespace Padaria03.Pages.VendaCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Venda Venda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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
    }
}
