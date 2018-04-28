using System;
using System.Collections.Generic;
using ClassLibrary.NameInverter;

namespace ConsoleApp.ReverseName
{
    class Program
    {
        static void Main(string[] args)
        {
            //This name inverter Kata is a great way for a developer to practice their TDD skills 
            //and hone their abilities to refactor their code with the safety net of the unit tests.
            //The code will take an input string and return a well formatted Name.
            //It will remove Honourifics as part of the business requirements if so detected [Mr. or Mrs.].
            //It will invert the first name as provided with the surname to give [Smith, John] to an input of [John Smith] and many other variations.
            //It will handle the correct removal of padding from the input string not only from the ends of the string but also in between word boundaries.

            var nameInverterUseCases = new List<(string NameToInvert, string ExpectedOutputOfTheNameInverter)>
            {
                ("", ""),
                ("", "       "),
                ("John", "John"),
                ("   John   ", "John"),
                ("John Smith", "Smith, John"),
                ("John      Smith", "Smith, John"),
                ("Mr. John Smith", "Smith, John"),
                ("Mrs. Sally Smith", "Smith, Sally"),
                ("John Smith Sr.", "Smith, John Sr."),
                ("John Smith Sr. PhD.", "Smith, John Sr. PhD."),
                ("Mr.    John Smith    Sr.     PhD.", "Smith, John Sr. PhD.")
            };

            foreach (var nameInverterUseCase in nameInverterUseCases)
            {
                Console.WriteLine($"The NameInverter is about to invert: {nameInverterUseCase.NameToInvert}");
                Console.WriteLine($"The expected output is: {NameInverter.Invert(nameInverterUseCase.NameToInvert)}");
            }

            Console.ReadLine();
        }
    }
}
