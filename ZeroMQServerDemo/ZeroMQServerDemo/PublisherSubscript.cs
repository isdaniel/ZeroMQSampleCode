using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace ZeroMQServerDemo
{
    public class PublisherSubscript : IExecuteable
    {
        private readonly SubscriptType _sendType;
        public PublisherSubscript(SubscriptType type)
        {
            _sendType = SubscriptType.ALL;
        }

        public void Execute()
        {
            using (var publisher = new ZSocket(ZSocketType.PUB))
            {
                string address = "tcp://*:5556";
                Console.WriteLine("Publisher.Binding on {0}", address);
                publisher.Bind(address);

                var rnd = new Random();

                while (true)
                {
                    int temperature = rnd.Next(-55, +45);

                    var update = $"{GetSubscriptType(_sendType)}{temperature}";
                    using (var updateFrame = new ZFrame(update))
                    {
                        publisher.Send(updateFrame);
                    }
                }
            }
        }

        private static string GetSubscriptType(SubscriptType type)
        {
            switch (type)
            {
                case SubscriptType.ALL:
                    return "[ALL]";
                case SubscriptType.One:
                    return "[One]";
                case SubscriptType.Two:
                    return "[Two]";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }

    public interface IExecuteable
    {
        void Execute();
    }
}
