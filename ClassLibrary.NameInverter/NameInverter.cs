using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary.NameInverter
{
    public static class NameInverter
    {
        public static string Invert(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException($"{nameof(name)} cannot be null");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            var nameParts = BreakNameIntoPartsIgnoringWhitespace(name);

            return nameParts.Length < 2 ? nameParts[0] : Invert(WithoutHonorifics(nameParts));
        }

        private static string Invert(string[] nameParts)
        {
            var firstName = nameParts[0];
            var lastName = nameParts[1];
            var postNominals = String.Empty;

            postNominals = FindAndMergePostNominals(nameParts, postNominals);

            return $"{lastName}, {firstName} {postNominals}".Trim();
        }

        private static string FindAndMergePostNominals(string[] nameParts, string postNominals)
        {
            for (var index = 2; index < nameParts.Length; index++)
            {
                postNominals += nameParts[index] + " ";
            }
            return postNominals;
        }

        private static string[] WithoutHonorifics(string[] nameParts)
        {
            if (!IsHonorific(nameParts[0])) return nameParts;

            var namePartsList = nameParts.ToList();
            namePartsList.Remove(nameParts[0]);
            nameParts = namePartsList.ToArray();

            return nameParts;
        }

        private static bool IsHonorific(string namePart)
        {
            return Honorifics.IsHonorific(namePart);
        }

        private static string[] BreakNameIntoPartsIgnoringWhitespace(string name)
        {
            return Regex.Split(name.Trim(), RegularExpressionHelpers.AnyAmountOfWhitespace());
        }
    }
}
