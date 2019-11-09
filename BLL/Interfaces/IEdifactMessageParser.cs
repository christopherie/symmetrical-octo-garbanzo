using System.Collections.Generic;

namespace ABMDeveloperTest.BLL.Interfaces
{
    internal interface IEdifactMessageParser
    {
        string[] GetEdifactMessage();
        List<string> GetLocSegments(string[] edifactMessage);
        List<string> CleanLocSegments(List<string> locSegments);
        string[] GetLocSegmentElements(List<string> cleanLocSegments);
    }
}
