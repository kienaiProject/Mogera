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
    /// MogeraControlDialog.xaml
    /// </summary>
    public partial class MogeraControlDialog : Window
    {
        /// <summary>
        /// display font
        /// </summary>
        public IEnumerable<CultureInfo> DisplayCultures
        {
            set
            {
                this._mogeraControl.DisplayCultures = value;
            }
        }

        /// <summary>
        /// selected font family.
        /// </summary>
        public FontFamily SelectedFontFamily
        {
            get
            {
                return this._mogeraControl.SelectedFontFamily;
            }
        }

        /// <summary>
        /// input font size.
        /// </summary>
        public int InputFontSize
        {
            get
            {
                return this._mogeraControl.InputFontSize;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MogeraControlDialog()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// called after clicking OK button.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void _okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
