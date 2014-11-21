using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileNumberer.WinFormApp
{
    using System.IO;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
                UpdateFolderList();
            }
        }

        private void UpdateFolderList()
        {
            string[] folders = Directory.GetDirectories(folderBrowserDialog1.SelectedPath);
            checkedListBox1.DataSource = folders;
            folder1.name = folders[0];
            folder1.Refresh();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
