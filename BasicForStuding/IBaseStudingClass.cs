using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicForStuding
{
    public interface IBaseStudingClass
    {
        string Description { get; set; }

        string Name { get; set; }

        IBaseStudingClass Next { get; set; }

        (bool Next, bool Previous, bool Close) Execute();
    }
}
