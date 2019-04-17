using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace ZeroMQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var req = new PublisherSubscript();
            req.Execute();
            Console.ReadKey();
        }
    }
}
