using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mogera.Controls.Model
{
    /// <summary>
    /// View Model of font item
    /// </summary>
    public class FontItemViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// parent font model
        /// </summary>
        private MogeraFontModel _fontModel;

        public MogeraFontModel FontModel
        {
            get { return _fontModel; }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="fontModel">font model</param>
        /// <param name="parent">parent font model</param>
        public FontItemViewModel(MogeraFontModel fontModel)
        {
            _fontModel = fontModel;
        }

        /// <summary>
        /// font name for display
        /// </summary>
        public string DisplayFontName
        {
            get
            {
                return _fontModel.FontName;
            }
        }

        #region == implement of INotifyPropertyChanged ==


        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
