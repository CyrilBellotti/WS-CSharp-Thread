using System;

namespace WS_ThreadPool
{
    class Program
    {
        delegate void DELG(object o);

        static void Main(string[] args)
        {
            System.Threading.Thread t1;
            DELG d = (o) =>
            {
                short i = 10;
                string msg = (string)o;
                while (i > 0)
                {
                    Console.WriteLine("Work - > {0}::{1}", msg,i);
                    System.Threading.Thread.Sleep(1000);
                    i--;
                }
            };
            t1 = new System.Threading.Thread(d.Invoke);
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                t1.Start(((object)("T1")));
            });
            Console.Read();
        }
    }
}