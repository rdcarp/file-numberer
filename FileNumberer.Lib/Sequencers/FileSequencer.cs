using System;
using System.Collections.Generic;
using System.IO;

namespace FileNumberer.Lib.Sequencers
{
    internal abstract class FileSequencer
    {
        protected List<string> Directories { get; set; }

        internal FileSequencer()
        {
            this.Directories = new List<string>();
        }

        internal void IncludeDirs(params string[] dirs)
        {
            foreach (string dir in dirs)
            {
                if (Directory.Exists(dir))
                    this.Directories.Add(dir);
                else
                    throw new NotImplementedException("Not implemented correct exception");
            }
        }

        internal abstract List<string> Process();
    }
}