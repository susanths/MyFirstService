using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modbus
{
    public class CModbusSlaveParameters
    {
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public int SlaveAddress { get; set; }
    }

    public class CModbusDevice
    {
        
        public CModbusSlaveParameters ModbusDevice { get; set; }
    }
}
