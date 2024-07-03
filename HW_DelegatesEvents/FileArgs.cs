using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_DelegatesEvents
{
    public class FileArgs : EventArgs
    {
        public string FilePath { get; set; }

        public FileArgs(string filePath)
        {
            FilePath = filePath;
        }
    }
}
