using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ChickenDinnerNumber1.DialogService;
using ChickenDinnerNumber1.Helpers;
using Pubg.Net;
using ChickenDinnerNumber1.Navigation;
using Xamarin.Forms;
using static ChickenDinnerNumber1.Enums.PubgRegion;

namespace ChickenDinnerNumber1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly PubgPlayerService _playerService;
        public MainViewModel(INavigationService navigationService, IDialogService dialogService, PubgPlayerService pubgPlayerService) : base(navigationService, dialogService)
        {
            SelectedRegion = Enums.PubgRegion.PcNorthAmerica;
            SubmitCommand = new Command(async () => await GetPlayerData());
            _playerService = pubgPlayerService;
        }

        public Enums.PubgRegion SelectedRegion { get; set; }
        public string UserName { get; set; }
        public ICommand SubmitCommand { get; }

        public override async Task Init()
        {

        }

        private PubgRegion GetPubgRegion()
        {
            switch (SelectedRegion)
            {
                case XboxAsia:
                    return PubgRegion.XboxAsia;
                case XboxEurope:
                    return PubgRegion.XboxEurope;
                case XboxNorthAmerica:
                    return PubgRegion.XboxNorthAmerica;
                case XboxOceania:
                    return PubgRegion.XboxOceania;
                case PcKorea:
                    return PubgRegion.PCKoreaJapan;
                case PcNorthAmerica:
                    return PubgRegion.PCNorthAmerica;
                case PcEurope:
                    return PubgRegion.PCEurope;
                case PcOceania:
                    return PubgRegion.PCOceania;
                case PcKakao:
                    return PubgRegion.PCKakao;
                case PcSouthEastAsia:
                    return PubgRegion.PCSouthEastAsia;
                case PcSouthCentralAmerica:
                    return PubgRegion.PCSouthAndCentralAmerica;
                case PcAsia:
                    return PubgRegion.PCAsia;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async Task GetPlayerData()
        {
            var playerRequest = new GetPubgPlayersRequest
            {
                PlayerNames = new[] {UserName}
            };
            var playerData = await _playerService.GetPlayersAsync(GetPubgRegion(), playerRequest);
            var player = playerData.First();
        }
    }
}
