using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace Utility
{

    public interface IQueueObject
    {
        object Data { get; set; }

        void Resolve();
    }

    public class MessageQueue
    {
        private static Queue messageQueue = new Queue();

        private static Dictionary<string, Type> registedType = new Dictionary<string, Type>();

        public static void Enqueue(IQueueObject queryMessage)
        {
            lock (messageQueue)
            {
                messageQueue.Enqueue(queryMessage);
            }
        }

        public static void Dequeue()
        {
            lock (messageQueue)
            {
                if (messageQueue.Count > 0)
                {
                    IQueueObject entity = messageQueue.Dequeue() as IQueueObject;
                    if (entity != null)
                    {
                        entity.Resolve();
                    }
                }
            }
        }

        public static void CleanQueue()
        {
            while (messageQueue.Count > 0)
            {
                Dequeue();
            }
        }

        public static int Count()
        {
            return messageQueue.Count;
        }
    } 
}