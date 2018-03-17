using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace XUnitTestProject.ReverseNameTests
{
    public class NameInverter
    {
        public static string Invert(string name)
        {
            if (name == null)
            {//Result of T pattern rather than relying upon the framework aka name.trim() to throw uncontrolled exceptions.
                throw new ArgumentNullException();
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            var nameParts = BreakNameIntoPartsIgnoringWhitespace(name);

            if (nameParts.Length < 2)
            {
                return nameParts[0];
            }

            return Invert(WithoutHonorifics(nameParts));
        }

        private static string Invert(string[] nameParts)
        {
            var firstName = nameParts[0];
            var lastName = nameParts[1];
            string postNominals = "";

            postNominals = FindAndMergePostNominals(nameParts, postNominals);

            return $"{lastName}, {firstName} {postNominals}".Trim();
        }

        private static string FindAndMergePostNominals(string[] nameParts, string postNominals)
        {
            for (int index = 2; index < nameParts.Length; index++)
            {
                postNominals += nameParts[index] + " ";
            }
            return postNominals;
        }

        private static string[] WithoutHonorifics(string[] nameParts)
        {
            if (isHonorific(nameParts[0]))
            {
                var namePartsList = nameParts.ToList();
                namePartsList.Remove(nameParts[0]);
                nameParts = namePartsList.ToArray();
            }

            return nameParts;
        }

        private static bool isHonorific(string namePart)
        {
            return Honorifics.isHonorific(namePart);
        }

        private static string[] BreakNameIntoPartsIgnoringWhitespace(string name)
        {
            return Regex.Split(name.Trim(), RegularExpressionHelpers.AnyAmountOfWhitespace());
        }
    }
}