using System.Collections.Generic;

namespace ABMDeveloperTest.BLL.Interfaces
{
    public interface IDeclarationDocumentParser
    {
        List<KeyValuePair<string, string>> GetRefTextValuesFromRefCodes(List<string> refCodes);
    }
}
