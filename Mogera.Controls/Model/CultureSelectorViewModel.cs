using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mogera.Controls.Model
{
    /// <summary>
    /// ViewModel of culture selector
    /// </summary>
    public class CultureSelectorViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// culture collection
        /// </summary>
        private ObservableCollection<CultureSelectorItemViewModel> _cultureItems;

        public ObservableCollection<CultureSelectorItemViewModel> CultureItems
        {
            get { return _cultureItems; }
            set 
            {
                if (value != _cultureItems)
                {
                    _cultureItems = value;
                    NotifyPropertyChanged("CultureItems");
                } 
            }
        }

        /// <summary>
        /// string for culture search.
        /// </summary>
        private string _searchWord = "";
        public string SearchWord
        {
            get
            {
                return _searchWord;
            }
            set
            {
                if (value != _searchWord)
                {
                    _searchWord = value;
                    var hashset = new HashSet<CultureInfo>();

                    var selectionList = _cultureItems.Where((elm) => elm.IsChecked == true);
                    foreach (var selection in selectionList)
                    {
                        hashset.Add(selection.CultureInfo);
                    }

                    SetCultures(hashset);
                    NotifyPropertyChanged("SearchWord");
                } 
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public CultureSelectorViewModel()
        {
            _cultureItems = new ObservableCollection<CultureSelectorItemViewModel>();
        }

        /// <summary>
        /// set culture selection.
        /// </summary>
        public void SetCultures(HashSet<CultureInfo> selectedCultures)
        {
            CultureItems.Clear();

            foreach (var culture in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
            {
                // Skip if NeutralCulture.
                if (culture.IsNeutralCulture)
                {
                    continue;
                }

                if (_searchWord.Length > 0)
                {
                    if (!culture.DisplayName.Contains(_searchWord))
                    {
                        continue;
                    }
                }

                if (selectedCultures.Contains(culture))
                {
                    // Checked items must be shown first.
                    CultureItems.Insert(0, new CultureSelectorItemViewModel(culture) { IsChecked = true });
                }
                else
                {
                    CultureItems.Add(new CultureSelectorItemViewModel(culture) { IsChecked = false });
                }
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
