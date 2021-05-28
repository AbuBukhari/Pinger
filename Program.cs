using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
namespace Pinger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Pinger";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("IP » ");
            string ip = Console.ReadLine();
            Console.Clear();
            Ping ping = new Ping();
            while (true)
            {
                try
                {
                    PingReply reply = ping.Send(ip);
                    if (reply.Status == IPStatus.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"IP {ip} » {reply.Status} - ms {reply.RoundtripTime} - {reply.Address}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"IP {ip} » {reply.Status}");
                    }
                    Thread.Sleep(1000);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"IP {ip} » Some thing is wrong here");
                }
            }
        }
    }
}
