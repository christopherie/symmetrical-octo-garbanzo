using ABMDeveloperTest.BLL.Interfaces;
using ABMDeveloperTest.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ABMDeveloperTest.BLL.Classes
{
    public class EdifactMessageParser : MessageManager, IEdifactMessageParser
    {
        public string[] GetEdifactMessage()
        {
            try
            {
                return File.ReadAllLines(EdifactMessagePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<string> GetLocSegments(string[] edifactMessage)
        {
            try
            {
                return (from item in edifactMessage
                        where item.StartsWith("LOC")
                        select item).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<string> CleanLocSegments(List<string> locSegments)
        {
            try
            {
                return (from item in locSegments
                        select item.Substring(0, item.Length - 1)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string[] GetLocSegmentElements(List<string> cleanLocSegments)
        {
            try
            {
                List<string> v = (from item in cleanLocSegments
                                  let s = item.Split('+')
                                  let t = s[1] + "," + s[2]
                                  select t).ToList();
                return v.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
