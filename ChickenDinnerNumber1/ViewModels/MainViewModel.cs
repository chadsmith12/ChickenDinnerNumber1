using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ChickenDinnerNumber1.DialogService;
using ChickenDinnerNumber1.Helpers;
using ChickenDinnerNumber1.Navigation;
using ChickenDinnerNumber1.NavigationParameters;
using Pubg.Net;
using PUBGLibrary.API;
using Xamarin.Forms;
using static ChickenDinnerNumber1.Enums.PubgRegion;

namespace ChickenDinnerNumber1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Private Fields

        private readonly PubgPlayerService _apiRequest;
        private readonly PubgMatchService _matchService;
        #endregion

        #region Constructors

        public MainViewModel(INavigationService navigationService, IDialogService dialogService, PubgPlayerService apiRequest, PubgMatchService matchService) : base(navigationService)
        {
            _apiRequest = apiRequest;
            _matchService = matchService;
            SelectedRegion = PcNorthAmerica;
            SubmitCommand = new Command(async () => await GetPlayerData());
        }

        #endregion

        #region Binding Properties

        public Enums.PubgRegion SelectedRegion { get; set; }
        public string UserName { get; set; }
        public ICommand SubmitCommand { get; }
        public string CurrentOperation { get; set; }
        #endregion

        public override async Task Init()
        {

        }

        private async Task GetPlayerData()
        {
            IsBusy = true;
            var playes = await _apiRequest.GetPlayersAsync(PubgRegion.PCNorthAmerica, new GetPubgPlayersRequest{PlayerNames = new []{UserName}});
            var player = playes.First();
            var matches = new List<PubgMatch>();
            foreach (var item in player.MatchIds.Take(5))
            {
                matches.Add(await _matchService.GetMatchAsync(PubgRegion.PCNorthAmerica, item));
            }

            await NavigationService.NavigateToAsync<MatchListViewModel, MatchListParams>(new MatchListParams(matches));
            IsBusy = false;
        }
    }
}
