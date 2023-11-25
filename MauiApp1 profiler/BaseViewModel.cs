using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui;

namespace Studencki_USOS_PUT_MAUI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        #region default

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion

        #region myLogic

        public class ActivityIndicatorHandler : BaseViewModel
        {
            public bool IsActivityIndicatorVisible
            {
                get => isActivityIndicatorVisible;
                set
                {
                    SetProperty(ref isActivityIndicatorVisible, value);
                }

            }
            bool isActivityIndicatorVisible = true;

            public bool IsContentVisible
            {
                get => isContentVisible;
                set
                {
                    SetProperty(ref isContentVisible, value);
                }
            }
            bool isContentVisible = false;

            public bool IsEmptyViewVisible
            {
                get => isEmptyViewVisible;
                set
                {
                    SetProperty(ref isEmptyViewVisible, value);
                }
            }
            bool isEmptyViewVisible = false;

            public void ActivityIndicatorVisibility(bool visible)
            {
                IsActivityIndicatorVisible = visible;
                IsContentVisible = !visible;
                IsEmptyViewVisible = false;
            }

            public void EmptyViewVisibility(bool visible) 
            {
                IsEmptyViewVisible = visible;
                IsContentVisible = !visible;
                IsActivityIndicatorVisible = false;
            }
        }

#endregion
    }
}
