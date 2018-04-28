using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.NameInverter
{
    public static class Honorifics
    {
        private static readonly IReadOnlyCollection<string> KnownHonorifics = new List<string>() { "Mr.", "Mrs." };

        public static bool IsHonorific(string value)
        {
            return KnownHonorifics.Contains(value);
        }
    }
}