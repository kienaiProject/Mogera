using Mogera.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mogera
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// on OK click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void _okButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = GetInitializedMogeraControlDialog();

            if (dialog.ShowDialog().GetValueOrDefault() == true)
            {
                var fontFamily = dialog.SelectedFontFamily;
                var fontSize = dialog.InputFontSize;

                string showMessage;

                if (fontFamily == null)
                {
                    showMessage = "No fonts selected.";    
                }
                else
                {
                    showMessage = "font family name is " + fontFamily.FamilyNames[fontFamily.FamilyNames.Keys.ElementAt(0)] + Environment.NewLine + "font size is " + fontSize + ".";
                }

                MessageBox.Show(showMessage, "Sample", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// returns initialized Mogera Control Dialog
        /// </summary>
        /// <returns>initialized Mogera Control Dialog</returns>
        private MogeraControlDialog GetInitializedMogeraControlDialog()
        {
            return new MogeraControlDialog()
            {
                Owner = this,
                DisplayCultures = new List<CultureInfo>()
                {
                    CultureInfo.CurrentUICulture
                }
            };
        }
    }
}
