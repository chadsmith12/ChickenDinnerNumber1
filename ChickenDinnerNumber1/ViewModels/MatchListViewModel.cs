using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChickenDinnerNumber1.DialogService;
using ChickenDinnerNumber1.Navigation;
using ChickenDinnerNumber1.NavigationParameters;
using Pubg.Net;
using PUBGLibrary.API;

namespace ChickenDinnerNumber1.ViewModels
{
    public class MatchListViewModel : BaseViewModel<MatchListParams>
    {
        public MatchListViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        public IList<PubgMatch> Matches { get; set; }
        public int TotalMatches { get; set; }

        public override async Task Init(MatchListParams parameter)
        {
            Matches = parameter.Matches.ToList();
            TotalMatches = Matches.Count;
        }
    }
}
