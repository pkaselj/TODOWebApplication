using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TODOHelperLibrary;
using TODOWebApplication.Data;
using TODOWebApplication.Models;

namespace TODOWebApplication.Pages
{
    public class CreateModel : PageModel
    {
        private readonly TODOWebApplication.Data.TODOWebApplicationContext _context;

        public CreateModel(TODOWebApplication.Data.TODOWebApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            States = new SelectList(ItemState.GetStateNames());
            return Page();
        }

        [BindProperty]
        public TodoItem TodoItem { get; set; }
        public SelectList States { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tasks.Add(TodoItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
