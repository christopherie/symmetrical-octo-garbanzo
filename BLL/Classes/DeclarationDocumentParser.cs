using ABMDeveloperTest.BLL.Interfaces;
using ABMDeveloperTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ABMDeveloperTest.BLL.Classes
{
    public class DeclarationDocumentParser : DeclarationDocumentManager, IDeclarationDocumentParser
    {
        public List<KeyValuePair<string, string>> GetRefTextValuesFromRefCodes(List<string> refCodes)
        {
            const string nodePattern = "InputDocument/DeclarationList/Declaration/DeclarationHeader/Reference";
            XmlDocument xmlDocument = new XmlDocument();
            List<KeyValuePair<string, string>> kvp = new List<KeyValuePair<string, string>>();

            try
            {
                xmlDocument.Load(DeclarationDocumentPath);
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes(nodePattern);

                foreach (string choice in refCodes)
                {
                    foreach (XmlNode item in from XmlNode item in xmlNodeList
                                             where item.Attributes["RefCode"].Value == choice
                                             select item)
                    {
                        kvp.Add(new KeyValuePair<string, string>(choice, item.InnerText));
                    }
                }
                return kvp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
