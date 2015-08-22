using System.Collections.Generic;
using System.IO;
using FileNumberer.Lib.Sequencers;
using FileNumberer.Lib.FileNamers;

namespace FileNumberer.Lib
{
    public class FileNumberer
    {
        IFileNamer fileNamer;
        FileNumbererArgs args;
        FileSequencer sequencer;

        public FileNumberer(FileNumbererArgs args)
        {
            this.args = args;
            this.fileNamer = new DefaultFileNamer();
            this.sequencer = SequencerFactory.GetSequencer(args.Method);
            this.sequencer.IncludeDirs(args.Directories.ToArray());
        }

        public void Process()
        {
            List<string> files = this.sequencer.Process(args.Recurse);

            int counter = args.StartNumber ;
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (!Directory.Exists(args.Target))
                {
                    Directory.CreateDirectory(args.Target);
                }

                File.Copy(file, Path.Combine(args.Target, fileNamer.GetName(counter++) + fi.Extension));
            }
        }
    }
}