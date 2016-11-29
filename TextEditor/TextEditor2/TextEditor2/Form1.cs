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
            catch(System.ComponentModel.Composition.ChangeRejectedException)
            {
                catalog.Catalogs.Clear();
                catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
                _container = new CompositionContainer(catalog);
                this._container.ComposeParts(this);
            }

            richTextBox1.ForeColor = normalColor = colorizePlugin.Colorize("");
        }

        private CompositionContainer _container;

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Open a File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        // https://stackoverflow.com/questions/21980554/color-specific-words-in-richtextbox
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.CheckKeyword("apple", colorizePlugin.Colorize("apple"));
            this.CheckKeyword("banana", colorizePlugin.Colorize("banana"));
            this.CheckKeyword("orange", colorizePlugin.Colorize("orange"));
        }

        //https://stackoverflow.com/questions/21980554/color-specific-words-in-richtextbox
        private void CheckKeyword(string word, Color color, int startIndex = 0)
        {
            if (this.richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = normalColor;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Open a File";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private Color normalColor;
    }


    [Export(typeof(IColorizePlugin))]
    class RedColorize : IColorizePlugin
    {
        Color IColorizePlugin.Colorize(String input)
        {
            return Color.FromArgb(255, 0, 0);
        }
    }
    
    
}
