using ChickenDinnerNumber1.Modules;
using ChickenDinnerNumber1.ViewModels;
using Ninject.Modules;
using Xamarin.Forms;

namespace ChickenDinnerNumber1
{
	public partial class App : Application
	{
		public App (params INinjectModule[] platformModule)
		{
			InitializeComponent();

		    AppConfig = new AppConfig()
		        .RegisterIocContainers(platformModule)
		        .RegisterIocContainers(new ServiceModule(), new ViewModelModule())
		        .LoadConfigModule(new PubgConfigModule())
		        .SetupMainPage<MainViewModel>(new MainPage());

		    MainPage = AppConfig.MainPage;
		}

        /// <summary>
        /// The apps AppConfig.
        /// </summary>
        public AppConfig AppConfig { get; }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
