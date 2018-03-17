using System;
using Xunit;

namespace XUnitTestProject.ReverseNameTests
{
    public class NameInverterTests
    {
        [Fact]
        public void Invert_null_shouldThrowNullReferenceException()
        {
            Assert.Throws<ArgumentNullException>(() => NameInverter.Invert(null));
        }

        [Fact]
        public void Invert_emptyString_shouldReturnEmptyString()
        {
            Assert.Equal("", NameInverter.Invert(""));
        }

        [Fact]
        public void Invert_manyEmptyWhitspaceCharacters_shouldReturnEmptyString()
        {
            Assert.Equal("", NameInverter.Invert("     "));
        }

        [Fact]
        public void Invert_firstName_shouldReturnFirstName()
        {
            Assert.Equal("John", NameInverter.Invert("John"));
        }

        [Fact]
        public void Invert_firstNameWithWhitespace_shouldReturnFirstName()
        {
            Assert.Equal("John", NameInverter.Invert("   John   "));
        }

        [Fact]
        public void Invert_firstNameThenLast_shouldReturnLastNameCommaFirstName()
        {
            Assert.Equal("Smith, John", NameInverter.Invert("John Smith"));
        }

        [Fact]
        public void Invert_firstNameThenLastWithWhitespace_shouldReturnLastNameCommaFirstName()
        {
            Assert.Equal("Smith, John", NameInverter.Invert("John      Smith"));
        }

        [Fact]
        public void Invert_honorificsMrFirstNameThenLastName_shouldReturnLastNameCommaFirstName()
        {
            Assert.Equal("Smith, John", NameInverter.Invert("Mr. John Smith"));
        }

        [Fact]
        public void Invert_honorificsMrsFirstNameThenLastName_shouldReturnLastNameCommaFirstName()
        {
            Assert.Equal("Smith, John", NameInverter.Invert("Mrs. John Smith"));
        }

        [Fact]
        public void Invert_FirstNameThenLastNamePostNominals_shouldReturnLastNameCommaFirstNamePostNominals()
        {
            Assert.Equal("Smith, John Sr.", NameInverter.Invert("John Smith Sr."));
        }

        [Fact]
        public void Invert_FirstNameThenLastNameMultiplePostNominals_shouldReturnLastNameCommaFirstNamePostNominals()
        {
            Assert.Equal("Smith, John Sr. PhD.", NameInverter.Invert("John Smith Sr. PhD."));
        }

        [Fact]
        public void Invert_FirstNameThenLastNameAcceptanceTest_shouldReturnLastNameCommaFirstNamePostNominals()
        {
            Assert.Equal("Smith, John Sr. PhD.", NameInverter.Invert("Mr.    John Smith    Sr.     PhD."));
        }
    }
}