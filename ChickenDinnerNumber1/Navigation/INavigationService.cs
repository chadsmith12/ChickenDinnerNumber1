using System;
using System.ComponentModel;
using System.Threading.Tasks;
using ChickenDinnerNumber1.ViewModels;

namespace ChickenDinnerNumber1.Navigation
{
    /// <summary>
    /// Defines everything for all navigation.
    /// you can implement this to create your own navigation service that fits your needs and will be injected in automatically to your ViewModels.
    /// Navigation is ViewModel based.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Indicates whether we can go back on the navigation stack.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can go back; otherwise, <c>false</c>.
        /// </value>
        bool CanGoBack { get; }

        /// <summary>
        /// Goes back to the previous page in the navigation stack.
        /// </summary>
        /// <returns>A task to act off of.</returns>
        Task GoBackAsync();

        /// <summary>
        /// Navigates to the specified view model.
        /// Can pass in true to <paramref name="asModal"/> to navigate to it as a modal.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model. Must inherit from <see cref="BaseViewModel"/></typeparam>
        /// <param name="asModal">if set to <c>true</c> navigates to the view model as a modal.</param>
        /// <returns>A Task to act off of.</returns>
        Task NavigateToAsync<TViewModel>(bool asModal = false) where TViewModel : BaseViewModel;

        /// <summary>
        /// Navigates to the specified view model passing the specified parameter from <paramref name="parameter"/>.
        /// Can pass in true to <paramref name="asModal"/> to navigate to it as a modal.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model. Must inherit from <see cref="BaseViewModel"/></typeparam>
        /// <typeparam name="TParameter">The type of the parameter that are passing in.</typeparam>
        /// <param name="parameter">The parameter we are passing in to the view model.</param>
        /// <param name="asModal">if set to <c>true</c> navigates to the view model as a modal.</param>
        /// <returns>A Task to act off of.</returns>
        Task NavigateToAsync<TViewModel, TParameter>(TParameter parameter, bool asModal = false) where TViewModel : BaseViewModel;

        /// <summary>
        /// Removes the last view from the navigation stack.
        /// </summary>
        void RemoveLastView();

        /// <summary>
        /// Clears the back stack.
        /// </summary>
        void ClearBackStack();

        /// <summary>
        /// Navigates to the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>A task to act off of.</returns>
        Task NavigateToUriAsync(Uri uri);

        /// <summary>
        /// Event that is fired when you can go back on the navigation stack or not..
        /// </summary>
        event PropertyChangedEventHandler CanGoBackChanged;
    }
}
