using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modbus
{
    public class CModbusSlave
    {
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public int SlaveAddress { get; set; }
    }
}
