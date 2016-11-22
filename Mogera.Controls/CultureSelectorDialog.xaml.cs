using Mogera.Controls.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mogera.Controls
{
    /// <summary>
    /// CultureSelectorDialog.xaml
    /// </summary>
    public partial class CultureSelectorDialog : Window
    {
        internal CultureSelectorViewModel _viewModel;

        private HashSet<CultureInfo> _currentSelections;


        /// <summary>
        /// Selecting culture on a check list box.
        /// </summary>
        internal IEnumerable<CultureInfo> SelectedCultureInfo
        {
            set 
            {
                _currentSelections = new HashSet<CultureInfo>();

                foreach(var culture in value)
                {
                    _currentSelections.Add(culture);
                }

                _viewModel.SetCultures(_currentSelections);
            }
            get
            {
                return _viewModel.CultureItems.Where((e => e.IsChecked)).Select((e) => e.CultureInfo);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CultureSelectorDialog()
        {
            InitializeComponent();

            InitCultureSelectorViewModel();

            DataContext = _viewModel;
        }

        /// <summary>
        /// Initialize ViewModel.
        /// </summary>
        private void InitCultureSelectorViewModel()
        {
            _viewModel = new CultureSelectorViewModel();

            _viewModel.SetCultures(new HashSet<CultureInfo>());
        }


        /// <summary>
        /// Called by OK button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
