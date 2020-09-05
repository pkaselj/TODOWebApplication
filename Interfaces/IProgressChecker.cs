using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOWebApplication.Interfaces
{
    public interface IProgressChecker
    {
        float InProgress { get; set; }
        float Completed { get; set; }
        float Canceled { get; set; }

        void Count();
    }
}
