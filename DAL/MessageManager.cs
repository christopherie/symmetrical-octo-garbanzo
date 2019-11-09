using System.Configuration;

namespace ABMDeveloperTest.DAL
{
    public abstract class MessageManager
    {
        public string EdifactMessagePath => ConfigurationManager.AppSettings["EdifactMessagePath"];

    }
}
