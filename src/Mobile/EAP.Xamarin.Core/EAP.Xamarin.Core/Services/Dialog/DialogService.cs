using System.Threading.Tasks;
using Acr.UserDialogs;

namespace EAP.Xamarin.Core.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public void ShowBusy()
        {
            UserDialogs.Instance.ShowLoading();
        }

        public void HideBusy()
        {
            UserDialogs.Instance.HideLoading();
        }

        public Task ShowAlertAsync(string message, string title = null, string buttonLabel = null)
        {
            return UserDialogs.Instance.AlertAsync(message, title ?? "Error", buttonLabel);
        }

        public async Task<bool> ConfirmAsync(string message, string title = null, string okText = null, string cancelText = null)
        {
            return await UserDialogs.Instance.ConfirmAsync(message, title ?? "Confirm", okText ?? "Ok", cancelText ?? "Cancel");
        }
    }
}
