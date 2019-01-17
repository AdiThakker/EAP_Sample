using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using EAP.Xamarin.Core.Services;
using EAP.Xamarin.Core.Utilities;

namespace EAP.Xamarin.Core.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy = false;
        private bool isDirty = false;
        private string title = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public bool IsDirty
        {
            get => isDirty;
            set => SetProperty(ref isDirty, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public IDataService DataService { get; private set; }

        public BaseViewModel()
        {
            DataService = AppContainer.Resolve<IDataService>();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;

            OnPropertyChanged(propertyName);

            onChanged?.Invoke();

            return true;
        }
    }
}
