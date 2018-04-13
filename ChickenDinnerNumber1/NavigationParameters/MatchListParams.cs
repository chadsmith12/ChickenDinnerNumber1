using System.Collections.Generic;
using System.Linq;
using Pubg.Net;
using PUBGLibrary.API;

namespace ChickenDinnerNumber1.NavigationParameters
{
    public class MatchListParams
    {
        public MatchListParams(IEnumerable<PubgMatch> matches)
        {
            Matches = matches;
        }

        public IEnumerable<PubgMatch> Matches { get; set; }
    }
}
