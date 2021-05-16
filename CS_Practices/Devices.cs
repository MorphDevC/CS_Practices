using System;

namespace CS_Practices
{
    public class Devices
    {
        public  virtual void DeviceAction(string message){}
        internal class SMS:Devices
        {
            public override void DeviceAction(string message)
            {
                Console.WriteLine($"Отправка SMS: {message}");
            }
        };

        internal class Printer:Devices
        {
            public override void DeviceAction(string message)
            {
                Console.WriteLine($"Печать сообщения: {message}");
            }
        };
    }
}