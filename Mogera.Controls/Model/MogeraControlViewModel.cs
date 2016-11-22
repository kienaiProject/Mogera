using Mogera.Controls.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace Mogera.Controls.Model
{
    /// <summary>
    /// View model of font control
    /// </summary>
    public class MogeraControlViewModel :  INotifyPropertyChanged
    {
        /// <summary>
        /// displayable font items
        /// </summary>
        private ObservableCollection<FontItemViewModel> _fontItems;
        public ObservableCollection<FontItemViewModel> FontItems
        {
            get { return _fontItems; }
            set
            {
                if (value != _fontItems)
                {
                    _fontItems = value;
                    NotifyPropertyChanged("FontItems");
                }
            }
        }

        /// <summary>
        /// displayable cultures
        /// </summary>
        private ObservableCollection<CultureSelectorItemViewModel> _cultures;
        public ObservableCollection<CultureSelectorItemViewModel> Cultures
        {
            get { return _cultures; }
            set
            {
                if (value != _cultures)
                {
                    _cultures = value;
                    NotifyPropertyChanged("Cultures");
                }
            }
        }
        /// <summary>
        /// text for font comparison
        /// </summary>
        private string _sampleText;

        public string SampleText
        {
            get { return _sampleText; }
            set 
            { 
                if(value != _sampleText)
                {
                    _sampleText = value;
                    NotifyPropertyChanged("SampleText");
                }
                
            }
        }

        /// <summary>
        /// font size
        /// </summary>
        private int _fontSize;

        public int FontSize
        {
            get { return _fontSize; }
            set 
            {
                if (value == 0 || value > 99)
                {
                    throw new ArgumentOutOfRangeException(Resources.FontSizeRangeError_Text);
                }
                if (value != _fontSize)
                {
                    _fontSize = value;
                    NotifyPropertyChanged("FontSize");
                }
                
            }
        }

        /// <summary>
        /// string for search fonts.
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

                    LoadFontList();
                    NotifyPropertyChanged("SearchWord");
                }
            }
        }

        /// <summary>
        /// font item
        /// </summary>
        private FontItemViewModel _selectedFontItem;

        public FontItemViewModel SelectedFontItem
        {
            get
            {
                return _selectedFontItem;
            }
            set
            {
                if (value != _selectedFontItem)
                {
                    _selectedFontItem = value;
                    NotifyPropertyChanged("SelectedFontItem");
                }
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public MogeraControlViewModel()
        {
            FontItems = new ObservableCollection<FontItemViewModel>();
            Cultures = new ObservableCollection<CultureSelectorItemViewModel>();
        }


        /// <summary>
        /// load font list
        /// </summary>
        public void LoadFontList()
        {
            FontItems.Clear();

            var currentLanguages = Cultures.ToDictionary((e) => e.CultureInfo.Name);

            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                foreach (var culture in Cultures)
                {
                    XmlLanguage userLanguage = XmlLanguage.GetLanguage(culture.CultureInfo.Name);

                    LanguageSpecificStringDictionary dictionary = fontFamily.FamilyNames;

                    if (dictionary.ContainsKey(userLanguage) == false)
                    {
                        continue;
                    }

                    var fontName = dictionary[userLanguage];

                    if (_searchWord.Length > 0)
                    {
                        if (!fontName.Contains(_searchWord))
                        {
                            continue;
                        }
                    }

                    var fontModel = new MogeraFontModel()
                    {
                        FontFamily = fontFamily,
                        FontName = fontName,
                    };

                    FontItems.Add(new FontItemViewModel(fontModel));
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
