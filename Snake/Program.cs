using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map(10, 10);
            map.GenerateSnake();

            do
            {
                
                map.ToString();


                

            } while (true);
        }
    }
}
