using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLUIWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BuiltinBrowser.DocumentTitleChanged += BuiltinBrowser_DocumentTitleChanged;
            BuiltinBrowser.ObjectForScripting = new Shell(this);
            BuiltinBrowser.Navigate(Program.BaseURL);
        }

        private void BuiltinBrowser_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = BuiltinBrowser.DocumentTitle;
        }
    }
}
