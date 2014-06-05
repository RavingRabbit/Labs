using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Lab4.ResourceLocking;

namespace Lab4.TestResourceLocker
{
    internal static class Program
    {
        private static readonly IPAddress[] LocalIpAddresses = Dns.GetHostAddresses(Dns.GetHostName());

        private static void Main()
        {
            DisplayLocalIpAddresses();

            var resourceAccessArbiter = new ResourceAccessArbiter();

            string resourceId = "a.txt";
            Console.WriteLine("Trying lock {0}.", resourceId);
            bool accessGranted = resourceAccessArbiter.TryGetAccess(resourceId);
            Console.WriteLine("Is locked - {0}.", accessGranted);
            if (!accessGranted)
            {
                Action callback = () => MessageBox.Show(string.Format("Access to {0} is granted!", resourceId));
                resourceAccessArbiter.RegisterCallbackOnResourceAccessGranted(resourceId, callback);
            }
            Console.ReadKey();

            Console.WriteLine("Release all resources.");
            resourceAccessArbiter.Dispose();
            Console.ReadKey();
        }

        private static void DisplayLocalIpAddresses()
        {
            string addresses = LocalIpAddresses.Aggregate(String.Empty,
                (current, ipAddress) => current + (ipAddress + Environment.NewLine));
            Console.WriteLine(addresses);
        }
    }
}