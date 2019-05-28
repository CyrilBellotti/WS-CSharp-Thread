using System;

namespace WS_Delegate
{
    class Program
    {
        delegate int DELG(int v1, int v2);

        static void Main(string[] args)
        {
            DELG d = new DELG(work.methode);
            Console.WriteLine(d.Invoke(1, 2).ToString());
            Console.Read();
        }

    }
    
    static class work
    {
        static public int methode(int v1, int v2)
        {
            return v1 + v2;
        }
    }
}