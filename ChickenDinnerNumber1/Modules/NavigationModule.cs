using System;
using ChickenDinnerNumber1.Navigation;
using ChickenDinnerNumber1.ViewModels;
using Ninject.Modules;
using Xamarin.Forms;

namespace ChickenDinnerNumber1.Modules
{
    /// <summary>
    /// Module to bind the Navigation Mappings.
    /// Register your view mappings here.
    /// <example>navigationService.RegisterViewMapping(typeof(MyViewModel), typeof(Mypage));</example>
    /// </summary>
    public class NavigationModule : NinjectModule
    {
        private readonly INavigation _formsNavigation;

        public NavigationModule(INavigation formsNavigation)
        {
            _formsNavigation = formsNavigation;
        }

        public override void Load()
        {
            // make the navigation service to register the view model to view mappings
            var navigationService = new NavigationService { XamarinNavigation = _formsNavigation };

            // Register the view mappings here
            // Example:
            // navigationService.RegisterViewMapping(typeof(MyViewModel), typeof(MyPage));
            navigationService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));

            // Bind the navigation service so it gets injected into the view models.
            // You only ever want one navigation service and not multiple navigation services laying around so we make a rule that this is done in the SingletonScope
            Bind<INavigationService>().ToMethod(x => navigationService).InSingletonScope();
        }
    }
}
