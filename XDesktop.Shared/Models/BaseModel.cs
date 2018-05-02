using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

#if __MAC__
using Foundation;
#endif

namespace XDesktop.Shared.Models
{
    public class BaseModel : INotifyPropertyChanged
#if __MAC__
    , NSObject
#endif
    {
        public BaseModel()
        {

        }

        protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName]string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

#if __MAC__
            WillChangeValue(propertyName);
#endif

            backingStore = value;

#if __MAC__
            DidChangeValue(propertyName);
#endif

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
    }
}
