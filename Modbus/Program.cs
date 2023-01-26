using System;
using System.Text.Json;
using System.Threading;
using FieldTalk.Modbus.Master;
using Modbus;

class TcpSimpleApp
{

    MbusTcpMasterProtocol mbusProtocol = new MbusTcpMasterProtocol();


    void openProtocol()
    {
        int result;

        string fileName = "C:\\Susanth\\Study\\CSharp\\HMI Trunk\\MyFirstService\\Modbus\\modbusdeviceconfig.json";
        string jsonString = File.ReadAllText(fileName);
        CModbusDevice modbusDevice = JsonSerializer.Deserialize<CModbusDevice>(jsonString)!;

        Console.WriteLine($"Date: {modbusDevice.ModbusDevice.IPAddress}");

        result = mbusProtocol.openProtocol(modbusDevice.ModbusDevice.IPAddress);
        if (result != BusProtocolErrors.FTALK_SUCCESS)
        {
            Console.WriteLine("Error opening protocol: " + BusProtocolErrors.getBusProtocolErrorText(result));
            Environment.Exit(result);
        }
    }


    void closeProtocol()
    {
        mbusProtocol.closeProtocol();
    }


    void runPollLoop()
    {
        Int16[] dataArr = new Int16[10];

        for (; ; )
        {
            int result;

            result = mbusProtocol.readMultipleRegisters(1, 100, dataArr);
            if (result == BusProtocolErrors.FTALK_SUCCESS)
            {
                for (int i = 0; i < dataArr.Length; i++)
                    Console.WriteLine("[" + (100 + i) + "]: " + dataArr[i]);
            }
            else
            {
                Console.WriteLine(BusProtocolErrors.getBusProtocolErrorText(result) + "!");
                // Stop for fatal errors
                if ((result & BusProtocolErrors.FTALK_BUS_PROTOCOL_ERROR_CLASS) != BusProtocolErrors.FTALK_BUS_PROTOCOL_ERROR_CLASS)
                    return;
            }
            Thread.Sleep(1000);
        }
    }


    public static void Main()
    {
        TcpSimpleApp app = new TcpSimpleApp();

        app.openProtocol();
        app.runPollLoop();
        app.closeProtocol();
    }
}