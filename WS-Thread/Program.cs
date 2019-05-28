using System;

namespace WS_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread t =
                new System.Threading.Thread (
                    x =>
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("Work...{0}",i);
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                );
        
          
            t.Start();
            Console.Read();
        }
    }
}