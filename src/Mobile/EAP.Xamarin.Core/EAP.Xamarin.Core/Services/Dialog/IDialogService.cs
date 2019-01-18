using System.Threading.Tasks;

namespace EAP.Xamarin.Core.Services.Dialog
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title = null, string buttonLabel = null);

        void ShowBusy();

        void HideBusy();

        Task<bool> ConfirmAsync(string message, string title = null, string okText = null, string cancelText = null);
    }
}
