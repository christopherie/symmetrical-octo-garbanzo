using ABMDeveloperTest.BLL.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ABMDeveloperTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Test Exercise 1
            // Please note that Exception handling should be persisted to a Database
            // I have used methods with Exception handling messages output to the console for demo purposes.
            SetForegroundColor("Exercise 1");

            EdifactMessageParser edifactMessageParser = new EdifactMessageParser();
            string[] message = edifactMessageParser.GetEdifactMessage();
            List<string> locSegments = edifactMessageParser.GetLocSegments(message);
            List<string> cleanLocSegments = edifactMessageParser.CleanLocSegments(locSegments);
            string[] locSegmentElements = edifactMessageParser.GetLocSegmentElements(cleanLocSegments);

            try
            {
                for (int i = 0; i < locSegmentElements.Length; i++)
                {
                    Console.WriteLine($"LOC {i + 1} elements are {locSegmentElements[i]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            SetForegroundColor("Exercise 2");

            // Test Exercise 2
            DeclarationDocumentParser declarationDocumentParser = new DeclarationDocumentParser();
            List<string> choices = new List<string>() { "MWB", "TRV", "CAR" };
            List<KeyValuePair<string, string>> kvp = declarationDocumentParser.GetRefTextValuesFromRefCodes(choices);

            try
            {
                foreach (var t in kvp)
                {
                    Console.WriteLine($"RefText value for {t.Key} is {t.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void SetForegroundColor(string exercise)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(exercise);
            Console.ResetColor();
        }
    }
}
