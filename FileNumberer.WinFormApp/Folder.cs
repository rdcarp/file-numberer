using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileNumberer.WinFormApp
{
    public partial class Folder : UserControl
    {
        private bool isChecked;
        public string name;
        private int index;

        public Folder()
        {
        }

        public Folder(bool isChecked, string name, int index)
        {
            InitializeComponent();
        }
    }
}
