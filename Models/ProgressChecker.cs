using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOWebApplication.Interfaces;

namespace TODOWebApplication.Models
{
    public class ProgressChecker : IProgressChecker
    {
        private readonly TODOWebApplication.Data.TODOWebApplicationContext _context;
        public ProgressChecker(TODOWebApplication.Data.TODOWebApplicationContext context)
        {
            _context = context;
        }

        public float InProgress { get; set; }
        public float Completed { get; set; }
        public float Canceled { get; set; }

        private int Sum { get; set; }



        private int GetStatusCount(int state)
        {
            var tasks = from x in _context.Tasks
                        select x;

            tasks = tasks.Where(item => (int)item.Status == state);
            return tasks.Count();   
        }

        private void GetTaskCount()
        {
            var tasks = from x in _context.Tasks
                        select x;

            Sum = tasks.Count();
        }

        private float ToPercent( int state)
        {
            return GetStatusCount(state) * 100f / Sum;
        }

        public void Count()
        {
            GetTaskCount();

            InProgress = ToPercent(0);
            Completed = ToPercent(1);
            Canceled = ToPercent(2);
        }
    }
}
