using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNumberer.Lib.FileNamers
{
    class DefaultFileNamer : IFileNamer
    {
        public string GetName(int index)
        {
            return index.ToString("D4");
        }
    }
}
