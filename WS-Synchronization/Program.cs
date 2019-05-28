using System;

namespace WS_Synchronization
{
    class Program
    {
        private delegate void DELG(object state);

        private static int var = 0;
        private static System.Threading.Mutex mutex;

        static void Main(string[] args)
        {
            mutex = new System.Threading.Mutex(false);
            DELG d = (state) =>
            {
                string name_thread = (string) state;
                mutex.WaitOne();
                for (int i = 0; i < 3; i++)
                {
                    ++var;
                    Console.WriteLine("Thread -> {0} -- var -> {1}", name_thread, var.ToString());
                    System.Threading.Thread.Sleep(2000);
                }

                mutex.ReleaseMutex();
            };
            System.Threading.Thread t1 = new
                System.Threading.Thread(d.Invoke);
            System.Threading.Thread t2 = new
                System.Threading.Thread(d.Invoke);
            t1.Start(((object) ("T1")));
            t2.Start(((object) ("T2")));
            Console.Read();
        }
    }
}