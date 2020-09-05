using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOWebApplication.Interfaces;

namespace TODOWebApplication.Models
{
    public class ExpirationChecker
    {
        private readonly List<TodoItem> _tasks;

        public ExpirationChecker(List<TodoItem> tasks)
        {
            _tasks = tasks;
        }

        public void Expire()
        {
            foreach(var task in _tasks)
            {
                if (DateTime.Compare(task.AddedDate, task.ExpirationDate) > 0)
                    task.Status = TODOHelperLibrary.ItemStatus.Canceled;
            }
        }
    }
}
