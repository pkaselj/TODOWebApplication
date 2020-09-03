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
    public class DeleteModel : PageModel
    {
        private readonly TODOWebApplication.Data.TODOWebApplicationContext _context;

        public DeleteModel(TODOWebApplication.Data.TODOWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TodoItem = await _context.Tasks.FindAsync(id);

            if (TodoItem != null)
            {
                _context.Tasks.Remove(TodoItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
