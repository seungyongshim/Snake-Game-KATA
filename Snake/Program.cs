using System;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map(25, 25);
            map.GenerateSnake();
            map.MakeApple();
            Console.CursorVisible = false;

            var drawTask = Task.Run(async () =>
            {
                try
                {
                    do
                    {
                        await Task.Delay(66);

                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine(map.ToString());

                    } while (map.SnakeMove());
                }
                catch (Exception)
                {
                }

                Console.WriteLine("GameOver");
            });

            while (true)
            {
                var key = Console.ReadKey();

                var direction = key.Key switch
                {
                    ConsoleKey.UpArrow => Direction.Up,
                    ConsoleKey.DownArrow => Direction.Down,
                    ConsoleKey.LeftArrow => Direction.Left,
                    ConsoleKey.RightArrow => Direction.Right,
                    _ => map.Snake.Direction,
                };

                map.Snake.SetDirection(direction);
            }
        }
    }
}
