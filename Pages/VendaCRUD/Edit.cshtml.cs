using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Padaria03.Data;
using Padaria03.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Padaria03.Pages.VendaCRUD
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Venda Venda { get; set; }

        public SelectList Clientes { get; set; }
        public SelectList Produtos { get; set; }

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

            Clientes = new SelectList(await _context.Clientes.ToListAsync(), "IdCliente", "Nome", Venda.ClienteId);
            Produtos = new SelectList(await _context.Produto.ToListAsync(), "IdProduto", "Nome", Venda.ProdutoId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Clientes = new SelectList(await _context.Clientes.ToListAsync(), "IdCliente", "Nome", Venda.ClienteId);
                Produtos = new SelectList(await _context.Produto.ToListAsync(), "IdProduto", "Nome", Venda.ProdutoId);
                return Page();
            }

            var produto = await _context.Produto.FindAsync(Venda.ProdutoId);
            if (produto != null)
            {
                Venda.ValorTotal = Venda.Quantidade * produto.Preco;
            }

            _context.Attach(Venda).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
