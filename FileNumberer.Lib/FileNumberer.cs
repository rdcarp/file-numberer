using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNumberer.Lib
{
    public class FileNumberer
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int NumberLength { get; set; }
        public ObservableCollection<string> Directories { get; set; }

        public FileNumberer() 
        {

        }

        public List<string> Process()
        {
          return new List<string>();
        }
    }
}