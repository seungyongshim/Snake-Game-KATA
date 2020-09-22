using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map(10, 10);
            map.GenerateSnake();
            Console.CursorVisible = false;

            do
            {
                
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(map.ToString());

                var key = Console.ReadKey();

                var direction = key.Key switch
                {
                    ConsoleKey.UpArrow => Direction.Up,
                    ConsoleKey.DownArrow => Direction.Down,
                    ConsoleKey.LeftArrow => Direction.Left,
                    ConsoleKey.RightArrow => Direction.Right,
                    _ => map.Snake.Head,
                };

                map.Snake.Head = direction;

                map.SnakeMove();
                

            } while (true);
        }
    }
}
