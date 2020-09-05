using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TODOHelperLibrary;
using TODOWebApplication.Data;
using TODOWebApplication.Models;

namespace TODOWebApplication.Pages
{
    public class EditModel : PageModel
    {
        private readonly TODOWebApplication.Data.TODOWebApplicationContext _context;

        public EditModel(TODOWebApplication.Data.TODOWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TodoItem TodoItem { get; set; }
        public SelectList States { get; set; }

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

            States = new SelectList(ItemState.GetStateNames());
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TodoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(TodoItem.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TodoItemExists(int id)
        {
            return _context.Tasks.Any(e => e.ID == id);
        }
    }
}
