using System.Collections.Generic;
using System.Linq;

namespace GoWHunter.WinForm
{
    public static class Extensions
    {
        public static bool Contains(this string content, IEnumerable<string> keywords)
        {
            return keywords.All(content.Contains);
        }
    }
}