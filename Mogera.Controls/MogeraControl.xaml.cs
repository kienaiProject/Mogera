using Mogera.Controls.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mogera.Controls
{
    /// <summary>
    /// MogeraControl.xaml
    /// </summary>
    public partial class MogeraControl : UserControl
    {
        internal MogeraControlViewModel _viewModel;

        private IEnumerable<CultureInfo> _displayCultures;

        internal IEnumerable<CultureInfo> DisplayCultures
        {
            get
            {
                return _displayCultures;
            }
            set
            {
                if( _displayCultures != value)
                {
                    _displayCultures = value;
                }
            }
        }

        /// <summary>
        /// selected font family.
        /// </summary>
        public FontFamily SelectedFontFamily
        {
            get
            {
                var fontItem = _viewModel.SelectedFontItem;
                if (fontItem  == null)
                {
                    return null;
                }

                return fontItem.FontModel.FontFamily;
            }
        }

        /// <summary>
        /// input font size.
        /// </summary>
        public int InputFontSize
        {
            get
            {
                return _viewModel.FontSize;
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public MogeraControl()
        {
            DisplayCultures = new List<CultureInfo>();

            _viewModel = new MogeraControlViewModel()
            {
                FontSize = 28,
                SampleText = "Sample Text"
            };

            InitializeComponent();

            this.DataContext = _viewModel;
        }

        /// <summary>
        /// Set Default Languages
        /// </summary>
        private void SetCultures()
        {
            if (DisplayCultures.Count() == 0)
            {
                _viewModel.Cultures.Add(new CultureSelectorItemViewModel(CultureInfo.CurrentUICulture));

                // Selecting current culture and english on default.
                foreach (var culture in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
                {
                    // Skip if NeutralCulture.
                    if (culture.IsNeutralCulture)
                    {
                        continue;
                    }

                    if (culture.LCID == 1033)
                    {
                        _viewModel.Cultures.Add(new CultureSelectorItemViewModel(culture) { IsChecked = true });
                    }
                }
            }
            else
            {
                foreach(var culture in DisplayCultures)
                {
                    _viewModel.Cultures.Add(new CultureSelectorItemViewModel(culture) { IsChecked = true });
                }
            }
        }

        /// <summary>
        /// Called before changing font size
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void FontSizeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9]+"); 
            e.Handled = (re.IsMatch(e.Text));
        }

        /// <summary>
        /// Called after clicking culture config button
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void CultureConfigButton_Click(object sender, RoutedEventArgs e)
        {
            var cultureSelector = new CultureSelectorDialog();

            cultureSelector.SelectedCultureInfo = _viewModel.Cultures.Select((elm) => elm.CultureInfo);
            cultureSelector.Owner = Window.GetWindow(this);

            if (cultureSelector.ShowDialog() == true)
            {
                _viewModel.Cultures.Clear();
                foreach (var cultureInfo in cultureSelector.SelectedCultureInfo)
                {
                    _viewModel.Cultures.Add(new CultureSelectorItemViewModel(cultureInfo) { IsChecked = false });
                }

                _viewModel.LoadFontList();
            }
        }
        /// <summary>
        /// called after controller loading.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetCultures(); 
            _viewModel.LoadFontList();
        }
    }
}
