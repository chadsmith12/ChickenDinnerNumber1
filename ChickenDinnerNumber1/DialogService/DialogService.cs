using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChickenDinnerNumber1.DialogService
{
    public class DialogService : IDialogService
    {
        #region Private Fields
        private Page _dialogPage;
        #endregion

        #region Methods
        public void Init(Page dialogPage)
        {
            _dialogPage = dialogPage;
        }

        public async Task ShowMessage(DialogType dialogType, string title, string message, string buttonText, Action hideCallback)
        {
            if (_dialogPage == null)
            {
                return;
            }

            if (dialogType == DialogType.Error)
            {
                await _dialogPage.DisplayAlert($"ERROR: {title}", message, buttonText);
            }
            else
            {
                await _dialogPage.DisplayAlert(title, message, buttonText);
            }

            hideCallback?.Invoke();
        }

        public async Task<bool> ShowMessage(string title, string message, string confirmText, string cancelText, Action<bool> hideCallBack)
        {
            if (_dialogPage == null)
            {
                return false;
            }

            var result = await _dialogPage.DisplayAlert(title, message, confirmText, cancelText);

            hideCallBack?.Invoke(result);

            return result;
        }
        #endregion
    }
}
