using System;

namespace ConsoleApp1
{
    class Program
    {

            static void Main(string[] args)
            {
                var list = new SkipList<int>();

                list.pushToList(1);
                list.pushToList(45);
                list.pushToList(42);
                list.pushToList(21);
                list.pushToList(2);
                list.pushToList(5);
                list.pushToList(14);
                list.pushToList(5);
               
                bool thing = list.Contains(0);


                foreach (int value in list)
                {
                    Console.WriteLine(value);
                }
            
        }
       
    }
}
