using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProxyEditAssistant.Common
{
    public class ModelBase : INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> _propertyBackingDictionary = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
        }

        protected T GetPropertyValue<T>([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof (propertyName));
            object obj;
            return this._propertyBackingDictionary.TryGetValue(propertyName, out obj) ? (T) obj : default (T);
        }

        protected bool SetPropertyValue<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof (propertyName));
            if (EqualityComparer<T>.Default.Equals(newValue, this.GetPropertyValue<T>(propertyName)))
                return false;
            this._propertyBackingDictionary[propertyName] = (object) newValue;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}