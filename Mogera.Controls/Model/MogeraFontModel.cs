using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Mogera.Controls.Model
{
    /// <summary>
    /// font model
    /// </summary>
    public class MogeraFontModel
    {
        /// <summary>
        /// font name
        /// </summary>
        private string _fontName;

        public string FontName
        {
            get { return _fontName; }
            set { _fontName = value; }
        }

        /// <summary>
        /// font family
        /// </summary>
        private FontFamily _fontFamily;

        public FontFamily FontFamily
        {
            get { return _fontFamily; }
            set { _fontFamily = value; }
        }
    }
}
