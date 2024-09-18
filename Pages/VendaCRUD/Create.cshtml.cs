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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList Clientes { get; set; }
        public SelectList Produtos { get; set; }

        [BindProperty]
        public Venda Venda { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Clientes = new SelectList(await _context.Clientes.ToListAsync(), "IdCliente", "Nome");
            Produtos = new SelectList(await _context.Produto.ToListAsync(), "IdProduto", "Nome");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Clientes = new SelectList(await _context.Clientes.ToListAsync(), "IdCliente", "Nome");
                Produtos = new SelectList(await _context.Produto.ToListAsync(), "IdProduto", "Nome");
                return Page();
            }

            var produto = await _context.Produto.FindAsync(Venda.ProdutoId);
            if (produto != null)
            {
                Venda.ValorTotal = Venda.Quantidade * produto.Preco;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Produto não encontrado.");
                Clientes = new SelectList(await _context.Clientes.ToListAsync(), "IdCliente", "Nome");
                Produtos = new SelectList(await _context.Produto.ToListAsync(), "IdProduto", "Nome");
                return Page();
            }

            _context.Venda.Add(Venda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
