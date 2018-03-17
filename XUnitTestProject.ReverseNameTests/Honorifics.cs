using System.Collections.Generic;
using System.Linq;

namespace XUnitTestProject.ReverseNameTests
{
    public class Honorifics
    {
        private static readonly IReadOnlyCollection<string> knownHonorifics = new List<string>() { "Mr.", "Mrs." };

        public static bool isHonorific(string value)
        {
            return knownHonorifics.Contains(value);
        }
    }
}