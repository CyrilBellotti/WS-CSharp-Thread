using System;

namespace WS_Synchronization2
{
    class Program
    {
        private delegate void DELG(object state);
        private static string simu_cnx_db = "Utilisation de la base de données";
        private static System.Threading.Semaphore semaphore;

        static void Main(string[] args)
        {
            semaphore = new System.Threading.Semaphore(2, 2);
            DELG d = (state) =>
            {
                semaphore.WaitOne();
                for (int i = 0; i < 3; i++)
                {
                    string name_thread = (string)state;
                    Console.WriteLine("Thread -> {0} -- Etat -> {1}", name_thread, simu_cnx_db.ToString());
                    System.Threading.Thread.Sleep(2000);
                }
                semaphore.Release();
            };
            System.Threading.Thread t1 = new
                System.Threading.Thread(d.Invoke);
            System.Threading.Thread t2 = new
                System.Threading.Thread(d.Invoke);
            System.Threading.Thread t3 = new
                System.Threading.Thread(d.Invoke);
            t1.Start(((object)("T1")));
            t2.Start(((object)("T2")));
            t3.Start(((object)("T3")));
            Console.Read();
        }
    }
}
