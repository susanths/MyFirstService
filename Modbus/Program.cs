// See https://aka.ms/new-console-template for more information
using FieldTalk.Modbus.Master;
using Modbus;
using System.Text.Json;

class TcpSimpleApp
{

    
    public static void Main()
    {
        string fileName = "C:\\Susanth\\Study\\CSharp\\HMI Trunk\\MyFirstService\\Modbus\\modbusdeviceconfig.json";
        string jsonString = File.ReadAllText(fileName);
        CModbusSlave slave1 = JsonSerializer.Deserialize<CModbusSlave>(jsonString)!;

        Console.WriteLine($"Date: {slave1.IPAddress}");
        Console.WriteLine($"TemperatureCelsius: {slave1.Port}");
        Console.WriteLine($"Summary: {slave1.SlaveAddress}");
    }
}
