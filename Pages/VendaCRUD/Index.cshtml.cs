using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Padaria03.Data;
using Padaria03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Padaria03.Pages.VendaCRUD
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Venda> Venda { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Incluindo as tabelas relacionadas (Cliente e Produto)
            Venda = await _context.Venda
                                  .Include(v => v.Cliente)
                                  .Include(v => v.Produto)
                                  .ToListAsync();
        }
    }
}
