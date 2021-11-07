using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicForStuding
{
    public interface IBaseStudingClass<TNext>
        where TNext : IBaseStudingClass<TNext>, new()
    {
        string Description { get; set; }

        string Name { get; set; }

        TNext Next { get; set; }

        (bool Next, bool Previous, bool Close) Execute();
    }
}
