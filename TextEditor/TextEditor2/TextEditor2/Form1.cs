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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
        }
    }
}
