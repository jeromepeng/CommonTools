using System;
using System.Threading;
using Utility;

namespace FunctionTest
{
    public class MessageObject1 : IQueueObject
    {
        public object Data { get; set; }

        public void Resolve()
        {
            Console.WriteLine(Data as string);
        }
    }

    public class MessageObject2 : IQueueObject
    {
        public object Data { get; set; }

        public void Resolve()
        {
            int data = (int)Data;
            Console.WriteLine(data.ToString());
        }
    }
}


namespace MessageQueue
{
    class Program
    {
        public static void ThreadFunction1()
        {
            while (Utility.MessageQueue.Count() > 0)
            {
                Console.WriteLine("Thread1");
                Utility.MessageQueue.Dequeue();
            }
        }

        public static void ThreadFunction2()
        {
            while (Utility.MessageQueue.Count() > 0)
            {
                Console.WriteLine("Thread2");
                Utility.MessageQueue.Dequeue();
            }
        }

        public static void ThreadFunction3()
        {
            while (Utility.MessageQueue.Count() > 0)
            {
                Console.WriteLine("Thread3");
                Utility.MessageQueue.Dequeue();
            }
        }

        public static void ThreadFunction4()
        {
            while (Utility.MessageQueue.Count() > 0)
            {
                Console.WriteLine("Thread4");
                Utility.MessageQueue.Dequeue();
            }
        }

        public static void ThreadFunction5()
        {
            while (Utility.MessageQueue.Count() > 0)
            {
                Console.WriteLine("Thread5");
                Utility.MessageQueue.Dequeue();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for (int i = 0; i < 100; i++)
            {
                FunctionTest.MessageObject1 messageObject1 = new FunctionTest.MessageObject1();
                FunctionTest.MessageObject2 messageObject2 = new FunctionTest.MessageObject2();
                messageObject2.Data = i;
                messageObject1.Data = "String" + i;
                Utility.MessageQueue.Enqueue(messageObject1);
                Utility.MessageQueue.Enqueue(messageObject2);
            }
            Thread tr1 = new Thread(ThreadFunction1);
            Thread tr2 = new Thread(ThreadFunction2);
            Thread tr3 = new Thread(ThreadFunction3);
            Thread tr4 = new Thread(ThreadFunction4);
            Thread tr5 = new Thread(ThreadFunction5);
            tr1.Start();
            tr2.Start();
            tr3.Start();
            tr4.Start();
            tr5.Start();
        }
    }
}
