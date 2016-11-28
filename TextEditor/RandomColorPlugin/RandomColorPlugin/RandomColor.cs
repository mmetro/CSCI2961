using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor2;

namespace RandomColorPlugin
{
    [Export(typeof(TextEditor2.IColorizePlugin))]
    [ExportMetadata("Symbol", '%')]
    public class RandomColor : TextEditor2.IColorizePlugin
    {
    }
}
