using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicForStuding
{
    public static class NullGuard
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the provided argument is null.
        /// </summary>
        /// <param name="argument">Argument to check.</param>
        /// <param name="name">Original name of the argument.</param>
        public static void ThrowExIfNull<T>(this T argument, string name) {
            if (argument == null) {
                throw new ArgumentNullException(name);
            }
        }
    }
}
