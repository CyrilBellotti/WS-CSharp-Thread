using System;

namespace WS_AsyncDelegate
{
    class Program
    {
        delegate void DELG(object o);

        static void Main(string[] args)
        {
            IAsyncResult asrr;
            DELG d = (o) =>
            {
                short i = 10;
                string msg = (string)o;
                while (i > 0)
                {
                    Console.WriteLine("Work - > {0}::{1}",i,msg);
                    System.Threading.Thread.Sleep(1000);
                    i--;
                }
            };
            asrr = d.BeginInvoke(((object)("T1")),(async)=>
            {
                DELG dlg = (DELG)((System.Runtime.Remoting.Messaging.AsyncResult)async).AsyncDelegate;
                dlg.EndInvoke(async);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("callback");
                Console.ForegroundColor = ConsoleColor.Gray;
            },d);
            while (!asrr.IsCompleted)
            {
                Console.WriteLine("Le thread principal attend le callback end");
                System.Threading.Thread.Sleep(2000);
                if (asrr.IsCompleted) 
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("callback end msg");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.Read();
        }
    }
}