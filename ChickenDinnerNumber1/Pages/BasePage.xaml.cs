using ChickenDinnerNumber1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChickenDinnerNumber1.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasePage : ContentPage
	{
		public BasePage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = BindingContext as BaseViewModel;
            viewModel?.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            var viewModel = BindingContext as BaseViewModel;
            viewModel?.OnBackButtonPressed();

            return base.OnBackButtonPressed();
        }
    }
}