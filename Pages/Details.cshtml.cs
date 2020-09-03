using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TODOWebApplication.Data;
using TODOWebApplication.Models;

namespace TODOWebApplication.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly TODOWebApplication.Data.TODOWebApplicationContext _context;

        public DetailsModel(TODOWebApplication.Data.TODOWebApplicationContext context)
        {
            _context = context;
        }

        public TodoItem TodoItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TodoItem = await _context.Tasks.FirstOrDefaultAsync(m => m.ID == id);

            if (TodoItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
