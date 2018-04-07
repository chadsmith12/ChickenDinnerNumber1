using ChickenDinnerNumber1.ViewModels;
using Ninject;
using Ninject.Modules;
using Xamarin.Forms;

namespace ChickenDinnerNumber1.Modules
{
    /// <summary>
    /// A class that loads/bootstraps out the configuration for your app.
    /// Setup the services and main page to be used at startup.
    /// Bootstrap your own startup logic by creating your own IConfigModules and passing them in.
    /// </summary>
    public class AppConfig
    {
        public AppConfig()
        {
            Kernel = new StandardKernel();
        }

        /// <summary>
        /// Gets the current main page for the application.
        /// </summary>
        public Page MainPage { get; private set; }

        /// <summary>
        /// The applications kernel.
        /// </summary>
        public IKernel Kernel { get; private set; }

        /// <summary>
        /// Register your InversionOfControl containers to get dependency injection ready.
        /// </summary>
        /// <param name="modules">The modules you want to load into the kernel.</param>
        /// <returns>This AppConfig instance.</returns>
        public AppConfig RegisterIocContainers(params INinjectModule[] modules)
        {
            Kernel.Load(modules);

            return this;
        }

        /// <summary>
        /// Setups your main page and gets the application ready to display the main page.
        /// </summary>
        /// <typeparam name="TViewModel">The type of view model your main page is.</typeparam>
        /// <param name="page">The main page.</param>
        /// <returns>This AppConfig instance.</returns>
        public AppConfig SetupMainPage<TViewModel>(Page page) where TViewModel : BaseViewModel
        {
            MainPage = new NavigationPage(page);
            
            // register the navigation module into our kernel for IOC.
            RegisterIocContainers(new NavigationModule(MainPage.Navigation));

            // Initalize the dialog service for this page.
            var viewModel = Kernel.Get<TViewModel>();
            MainPage.BindingContext = viewModel;
            viewModel.DialogService.Init(MainPage);

            return this;
        }

        /// <summary>
        /// Loads in config modules to add in your own startup logic that needs to be done.
        /// </summary>
        /// <param name="configModule">Config Module to load and execute.</param>
        /// <returns>This AppConfig instance.</returns>
        public AppConfig LoadConfigModule(IConfigModule configModule)
        {
            configModule.Load();

            return this;
        }
    }
}
