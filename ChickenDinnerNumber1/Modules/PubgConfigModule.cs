using ChickenDinnerNumber1.Helpers;
using Pubg.Net;

namespace ChickenDinnerNumber1.Modules
{
    /// <summary>
    /// Module to read the api key from a resource manifest.
    /// </summary>
    public class PubgConfigModule : IConfigModule
    {
        public void Load()
        {
            // the api key is not empty, we already have it
            if (Settings.PubgApiKey == string.Empty)
            {
                Settings.PubgApiKey = ResourceManifestReader.ReadText("keys.pubgapi.txt");
            }

            PubgApiConfiguration.Configure(opt =>
            {
                opt.ApiKey = Settings.PubgApiKey;
            });
        }
    }
}
