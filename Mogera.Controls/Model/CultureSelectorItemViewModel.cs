using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mogera.Controls.Model
{
    /// <summary>
    /// ViewModel of Culture Selector
    /// </summary>
    public class CultureSelectorItemViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// culture info
        /// </summary>
        private CultureInfo _cultureInfo;

        public CultureInfo CultureInfo
        {
            get { return _cultureInfo; }
            set { _cultureInfo = value; }
        }

        /// <summary>
        /// culture name
        /// </summary>
        public string CultureName
        {
            get { return _cultureInfo.DisplayName; }
        }

        
        /// <summary>
        /// check flag
        /// </summary>
        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (value != _isChecked)
                {
                    _isChecked = value;
                    NotifyPropertyChanged("IsChecked");
                }
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="cultureInfo">parent culture info</param>
        public CultureSelectorItemViewModel(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
        }


        #region == implement of INotifyPropertyChanged ==


        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// notification
        /// </summary>
        /// <param name="propertyName">Property name for event publish </param>
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
