using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNumberer.Lib.FileNamers
{
    interface IFileNamer
    {
        string GetName(int index);
    }
}