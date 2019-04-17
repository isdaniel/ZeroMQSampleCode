using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace ZeroMQDemo
{
    public class RequestResponse : IExecuteable
    {
        public void Execute()
        {
            using (var requester = new ZSocket(ZSocketType.REQ))
            {
                // Connect
                requester.Connect("tcp://127.0.0.1:5555");

                for (int n = 0; n < 10; ++n)
                {
                    string requestText = Console.ReadLine();
                    Console.WriteLine("Sending {0}...", requestText);

                    // Send
                    requester.Send(new ZFrame(requestText));

                    // Receive
                    using (ZFrame reply = requester.ReceiveFrame())
                    {
                        Console.WriteLine($"Receive Message from  Server: {reply.ReadString()}!");
                    }
                }
            }
        }
    }

    public interface IExecuteable
    {
        void Execute();
    }
}
