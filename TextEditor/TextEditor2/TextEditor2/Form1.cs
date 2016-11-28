using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor2
{
    public interface IColorizePlugin
    {
        Color Colorize(String input);
    }

    public partial class Form1 : Form
    {
        [Import(typeof(IColorizePlugin))]
        public IColorizePlugin colorizePlugin;

        public Form1()
        {
            InitializeComponent();
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            try
            {
                catalog.Catalogs.Add(new DirectoryCatalog("Extensions"));
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show("The extensions directory was not found", "Directory not found");
            }

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }

            textBox1.ForeColor = colorizePlugin.Colorize("");
        }

        private CompositionContainer _container;
    }

    /*
    [Export(typeof(IColorizePlugin))]
    class RandomColorize : IColorizePlugin
    {
        Color IColorizePlugin.Colorize(String input)
        {
            Random random = new Random();
            return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
    */
}
