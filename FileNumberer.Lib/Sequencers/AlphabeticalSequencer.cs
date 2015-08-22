using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNumberer.Lib.Sequencers
{
    internal class AlphabeticalSequencer : FileSequencer
    {
        internal override List<string> Process(bool recurse)
        {
            SearchOption searchOption = recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            List<FileInfo> files = new List<FileInfo>();
            foreach (string dir in this.Directories)
            {
                foreach (string file in Directory.GetFiles(dir, "*", searchOption))
                {
                    files.Add(new FileInfo(file));
                }
            }

            return files.OrderBy(x => x.Name).ToList().Select(x => x.FullName).ToList();
        }
    }
}
