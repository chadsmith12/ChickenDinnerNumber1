using System.ComponentModel;
using System.Threading.Tasks;
using ChickenDinnerNumber1.DialogService;
using ChickenDinnerNumber1.Navigation;

namespace ChickenDinnerNumber1.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructors
        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            //DialogService = dialogService;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Indicates whether a task is running or something is busy.
        /// </summary>
        public bool IsBusy { get; set; }

        /// <summary>
        /// Indicates whether or not a list is currently being refreshed.
        /// </summary>
        public bool IsRefreshing { get; set; }

        /// <summary>
        /// The Dialog Service to help show dialog boxes.
        /// </summary>
        public IDialogService DialogService { get; set; }

        /// <summary>
        /// The Navigation service used to navigate from ViewModel to ViewModel.
        /// </summary>
        protected INavigationService NavigationService { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes a ViewModel.
        /// This is useful when a ViewModel needs to be refreshed or relaoded, you can quickly initailize the information.
        /// </summary>
        /// <returns></returns>
        public abstract Task Init();

        /// <summary>
        /// Called when a View/Page is appearing.
        /// </summary>
        public virtual void OnAppearing()
        {
            
        }

        /// <summary>
        /// CAlled when the back button is pressed.
        /// </summary>
        public virtual void OnBackButtonPressed()
        {
            
        }
        #endregion
    }

    /// <summary>
    /// Generic base class that all ViewModels inherit from.
    /// Generic to pass in information to a ViewModel.
    /// </summary>
    /// <typeparam name="TParameter">The type of paramter you're passing into the ViewModel</typeparam>
    public abstract class BaseViewModel<TParameter> : BaseViewModel
    {
        #region Constructors
        protected BaseViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes a ViewModel.
        /// This is useful when a ViewModel needs to be refreshed or relaoded, you can quickly initailize the information.
        /// </summary>
        public override async Task Init()
        {
            await Init(default(TParameter));
        }

        /// <summary>
        /// Initializes a ViewModel with the parameter passed in.
        /// This is useful when a ViewModel needs to be refreshed or relaoded, you can quickly initailize the information.
        /// </summary>
        /// <param name="parameter">The parameter we need when initializing the ViewModel.</param>
        public abstract Task Init(TParameter parameter);

        #endregion
    }
}
