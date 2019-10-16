using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace GetListofAllNICS
{
    class Program
    {
        static void Main(string[] args)
        {

            NetworkInterface[] nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

            foreach(NetworkInterface item in nics)
            {
                IPInterfaceProperties properties = item.GetIPProperties();

                foreach (IPAddressInformation unicast in properties.UnicastAddresses)
                {
                    if (unicast.Address.AddressFamily.ToString() == "InterNetworkV6") continue;
                    Console.WriteLine();
                    Console.WriteLine("#####################");
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Description);
                    Console.WriteLine(item.Name);
                    Console.WriteLine();
                    Console.WriteLine(unicast.Address);
                    Console.WriteLine("#####################");
                }
            }
            Console.ReadLine();
        }
    }
}
