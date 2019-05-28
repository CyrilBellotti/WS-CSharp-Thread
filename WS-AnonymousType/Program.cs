using System;

namespace WS_AnonymousType
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = new { age = 42, nom = "Manu" };
            Console.WriteLine(o.age.ToString());
            Console.Read();
        }

    }
}