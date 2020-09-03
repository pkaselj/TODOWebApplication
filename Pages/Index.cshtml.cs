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
    public class IndexModel : PageModel
    {
        private readonly TODOWebApplication.Data.TODOWebApplicationContext _context;

        public IndexModel(TODOWebApplication.Data.TODOWebApplicationContext context)
        {
            _context = context;
        }

        public IList<TodoItem> Tasks { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var tasks = from x in _context.Tasks
                        select x;

            if (!string.IsNullOrEmpty(SearchString))
            {
                tasks = tasks.Where(t => t.Title.Contains(SearchString) ||
                                        t.Description.Contains(SearchString));
            }

            Tasks = await tasks.ToListAsync();
        }
    }
}
