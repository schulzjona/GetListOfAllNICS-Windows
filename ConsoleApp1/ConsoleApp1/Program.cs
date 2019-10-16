using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkInterface[] nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            int i = 0;
            foreach (NetworkInterface item in nics)
            {
                Console.WriteLine("#####################");
                Console.WriteLine("Index: " + i);
                Console.WriteLine("Beschreibung: " + item.Description);
                Console.WriteLine("Name: " + item.Name);
                IPInterfaceProperties properties = item.GetIPProperties();

                foreach (IPAddressInformation unicast in properties.UnicastAddresses)
                {
                    if (unicast.Address.AddressFamily.ToString() == "InterNetworkV6") continue;
                    Console.WriteLine("IP Adresse: " + unicast.Address);
                }
                Console.WriteLine("#####################");
                Console.WriteLine();
                i++;
            }
            Console.ReadLine();
        }
    }
}
