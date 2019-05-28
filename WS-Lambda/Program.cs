using System;

namespace WS_Lambda
{
    delegate int DELG(int v);
    
    class Program
    {
        static void Main(string[] args)
        {
            DELG d =  x => x * x;
            Console.WriteLine(d.Invoke(4).ToString());
            Console.Read();
        }
    }
}