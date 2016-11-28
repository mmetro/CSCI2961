using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor2;

namespace RandomColor
{
    [Export(typeof(TextEditor2.IColorizePlugin))]
    [ExportMetadata("Symbol", '%')]
    public class RandomColor : IColorizePlugin
    {
        Color IColorizePlugin.Colorize(String input)
        {
            Random random = new Random();
            return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
