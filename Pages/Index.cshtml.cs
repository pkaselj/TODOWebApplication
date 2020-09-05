using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TODOWebApplication.Data;
using TODOWebApplication.Interfaces;
using TODOWebApplication.Models;

namespace TODOWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TODOWebApplication.Data.TODOWebApplicationContext _context;
        public Interfaces.IProgressChecker _progress { get; set; }

        public IndexModel(TODOWebApplication.Data.TODOWebApplicationContext context)
        {
            _context = context;
            _progress = new ProgressChecker(context);
        }

        // #TODO Fix DI

        /*public IndexModel(TODOWebApplication.Data.TODOWebApplicationContext context)
            : this(context, new ProgressChecker(context))
        {
        }*/


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

            ExpirationChecker expirationChecker = new ExpirationChecker((List<TodoItem>)Tasks);
            expirationChecker.Expire();

            _ = await _context.SaveChangesAsync();

            _progress.Count();

        }
    }
}
