using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptFileDemo
{
    [Serializable()]
    public class FileData
    {
        public byte[] data;
        public string Password = "";
        public string GiDo = "";
    }
}
