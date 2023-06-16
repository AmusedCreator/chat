using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(wcf_chat.ServiceChat)))
            {
                string exit;
                
                host.Open();
                Console.WriteLine("Host started...");
                Console.WriteLine("Logs will be saved in logs.txt");
                Console.WriteLine("Write 'exit' to stop host");
                exit = Console.ReadLine().ToLower();
                
                if(exit == "exit")
                {
                    host.Close();
                    Console.WriteLine("Host stopped...");
                    Console.WriteLine("Press any key to close");
                    Console.ReadLine();
                    return;
                }
                Console.ReadLine();
            }
        }
    }
}