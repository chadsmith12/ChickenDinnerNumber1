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
            Settings.PubgApiKey = ResourceManifestReader.ReadText("keys.pubgapi.txt");
            PubgApiConfiguration.Configure((setings =>
            {
                setings.ApiKey = Settings.PubgApiKey;
            }));
        }
    }
}
