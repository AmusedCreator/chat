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
                host.Open();
                Console.WriteLine("Host started...");
                Console.WriteLine("Logs will be saved in logs.txt");
                Console.WriteLine("Write 'exit' to stop host");
                if(Console.ReadLine() == "exit" || Console.ReadLine() == "Exit" || Console.ReadLine() == "EXIT")
                {
                    host.Close();
                    return;
                }
                Console.ReadLine();
            }
        }

        public void Logs(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}