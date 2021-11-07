using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicForStuding
{
    public class EndClass : IBaseStudingClass<EndClass>
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public EndClass Next { get; set; } = null;

        public (bool Next, bool Previous, bool Close) Execute() => default;
    }
}
