using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace ZeroMQDemo
{
    public class PublisherSubscript : IExecuteable
    {
        public void Execute()
        {
        
            using (var subscriber = new ZSocket(ZSocketType.SUB))
            {
                string connectTo = "tcp://127.0.0.1:5556";
                Console.WriteLine("Connecting to {0}...", connectTo);
                subscriber.Connect(connectTo);

                // Subscribe to zipcode
                string zipCode = Console.ReadLine();
                Console.WriteLine("Subscribing to zip code {0}...", zipCode);
                subscriber.Subscribe(zipCode);

                // Process 10 updates
                int i = 0;
                for (; i < 20; ++i)
                {
                    using (var replyFrame = subscriber.ReceiveFrame())
                    {
                        string reply = replyFrame.ReadString();

                        Console.WriteLine(reply);
                    }
                }
            }
        }
    }
}
