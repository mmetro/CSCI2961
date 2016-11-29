using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor2;

namespace FruitColor
{
    [Export(typeof(TextEditor2.IColorizePlugin))]
    [ExportMetadata("Symbol", '%')]
    public class FruitColor : IColorizePlugin
    {
        Color IColorizePlugin.Colorize(String input)
        {
            Color value;
            if (_fruitColors.TryGetValue(input, out value))
            {
                return value;
            }
            else
            {
                return Color.Black;
            }
        }

        private static readonly Dictionary<String, Color> _fruitColors
        = new Dictionary<String, Color>
        {
            { "apple", Color.Red },
            { "banana", Color.Yellow },
            { "orange", Color.Orange }
        };
    }
}
