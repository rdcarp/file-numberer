using System.Collections.Generic;

namespace FileNumberer.Lib
{
    public class Args
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int NumberOfDigits { get; set; }
        public List<string> Directories { get; set; }
        public bool Recurse { get; set; }
        public string Target { get; set; }
        public SequenceMethod Method { get; set; }
        public int StartNumber { get; set; }
    }
}
