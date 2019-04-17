using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZeroMQ;

namespace ZeroMQServerDemo
{
    public enum SubscriptType
    {
        ALL,
        One,
        Two
    }

    class Program
    {
        static void Main(string[] args)
        {
            var request = new PublisherSubscript(SubscriptType.ALL);
            request.Execute();
        }
    }
}
