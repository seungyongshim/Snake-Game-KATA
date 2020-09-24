using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        // https://stackoverflow.com/questions/10675451/iobservable-of-keys-pressed
        static IEnumerable<ConsoleKeyInfo> KeyPresses()
        {
            do
            {
                var key = Console.ReadKey();
                yield return key;
            } while (true);
        }

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

                        map.SnakeMove();

                    } while (map.IsNotGameOver);
                }
                catch (Exception)
                {
                }

                Console.WriteLine("GameOver");
            });

            var keys = KeyPresses().ToObservable();

            keys.Throttle(TimeSpan.FromMilliseconds(66))
                .Subscribe(key =>
                {
                    var direction = key.Key switch
                    {
                        ConsoleKey.UpArrow => Direction.Up,
                        ConsoleKey.DownArrow => Direction.Down,
                        ConsoleKey.LeftArrow => Direction.Left,
                        ConsoleKey.RightArrow => Direction.Right,
                        _ => map.Snake.Direction,
                    };

                    map.Snake.SetDirection(direction);
                });
        }
    }
}

