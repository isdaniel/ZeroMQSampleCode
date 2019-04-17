using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZeroMQ;

namespace ZeroMQServerDemo
{
    public class RequestResponse : IExecuteable
    {
        public void Execute()
        {
            using (var responder = new ZSocket(ZSocketType.REP))
            {
                // Bind
                responder.Bind("tcp://*:5555");

                while (true)
                {
                    // Receive
                    using (ZFrame request = responder.ReceiveFrame())
                    {
                        Console.WriteLine("Received {0}", request.ReadString());

                        // Do some work
                        Thread.Sleep(1);

                        string sendText = Console.ReadLine();

                        Console.WriteLine($"sending text :{sendText}");
                        // Send
                        responder.Send(new ZFrame(sendText));
                    }
                }
            }

            
        }
    }
}
