using System.Collections.Generic;
using System.IO;
using FileNumberer.Lib.Sequencers;

namespace FileNumberer.Lib
{
    public class FileNumberer
    {
        Args args;
        FileSequencer sequencer;

        public FileNumberer(Args args)
        {
            this.args = args;
            this.sequencer = SequencerFactory.GetSequencer(args.Method);
            this.sequencer.IncludeDirs(args.Directories.ToArray());
        }

        public void Process()
        {
            List<string> files = this.sequencer.Process();

            int counter = args.StartNumber ;
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (!Directory.Exists(args.Target))
                {
                    Directory.CreateDirectory(args.Target);
                }

                File.Copy(file, Path.Combine(args.Target, GenerateName(counter++)) + fi.Extension);
            }
        }

        private string GenerateName(int number)
        {
            return string.Format("{0}{1}{2}", args.Prefix, number, args.Suffix);
        }
    }
}