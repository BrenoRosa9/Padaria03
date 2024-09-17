﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Padaria03.Data;
using Padaria03.Models;

namespace Padaria03.Pages.ProdutoCRUD
{
    public class IndexModel : PageModel
    {
        private readonly Padaria03.Data.ApplicationDbContext _context;

        public IndexModel(Padaria03.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Produto = await _context.Produto.ToListAsync();
        }
    }
}
