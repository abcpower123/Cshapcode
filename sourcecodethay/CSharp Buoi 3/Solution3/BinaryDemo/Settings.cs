using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDemo
{
    [Serializable()]
    public class Settings
    {
        public string Background { get; set; }
        public float FontSize { get; set; }
        public string FontFamily { get; set; }

    }
}
