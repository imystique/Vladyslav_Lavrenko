using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class Get_File_ID_Fields
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Path_Lower { get; set; }
        public string Path_Display { get; set; }
        public string ID { get; set; }
        public string Client_Modified { get; set; }
        public string Server_Modified { get; set; }
        public string Rev { get; set; }
        public int Size { get; set; }
        public bool Is_Downloadable { get; set; }
        public string Content_Hash { get; set; }
    }
}
