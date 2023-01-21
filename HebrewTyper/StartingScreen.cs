using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HebrewTyper
{
    public partial class StartingScreen : Form
    {

        string[] filePaths = { "" };
        public StartingScreen()
        {
            InitializeComponent();
        }
        Typer t;
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void SelectTextsButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.Multiselect = true;
            openFileDialog.ShowDialog();
            filePaths = openFileDialog.FileNames;
            GenerateButton.Enabled = true;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            GenerateText gen = new GenerateText(filePaths);
            if (t!=null)
            {
                t.TextToType.Text=gen.GenerateWithoutParams();
                t.currentIndex = 0;
                t.Show();
                t.Focus();
                return;
            }
                
            
            t=new Typer(gen.GenerateWithoutParams(),this);
            t.Show();
            this.Hide();
            
        }
    }
}
