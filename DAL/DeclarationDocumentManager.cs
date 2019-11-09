using System.Configuration;

namespace ABMDeveloperTest.DAL
{
    public abstract class DeclarationDocumentManager
    {
        public string DeclarationDocumentPath => ConfigurationManager.AppSettings["DeclarationDocumentPath"];
    }
}
