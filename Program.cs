﻿using ABMDeveloperTest.BLL.Classes;
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
            //EdifactMessageParser edifactMessageParser = new EdifactMessageParser();
            //string[] message = edifactMessageParser.GetEdifactMessage();
            //List<string> locSegments = edifactMessageParser.GetLocSegments(message);
            //List<string> cleanLocSegments = edifactMessageParser.CleanLocSegments(locSegments);
            //string[] locSegmentElements = edifactMessageParser.GetLocSegmentElements(cleanLocSegments);

            //try
            //{
            //    for (int i = 0; i < locSegmentElements.Length; i++)
            //    {
            //        Console.WriteLine($"LOC {i + 1} elements are {locSegmentElements[i]}");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            // Test Exercise 2
            string DeclarationDocumentPath = ConfigurationManager.AppSettings["DeclarationDocumentPath"];
            string nodePattern = "InputDocument/DeclarationList/Declaration/DeclarationHeader/Reference";
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(DeclarationDocumentPath);
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(nodePattern);
            foreach (var item in from XmlNode item in xmlNodeList
                                 where item.Attributes["RefCode"].Value == "MWB" || item.Attributes["RefCode"].Value == "TRV" || item.Attributes["RefCode"].Value == "CAR"
                                 select item)
            {
                Console.WriteLine(item.InnerText);
            }

            Console.ReadKey();
        }
    }
}
