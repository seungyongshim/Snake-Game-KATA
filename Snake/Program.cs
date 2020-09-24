using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
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

            var keys = KeyPresses().ToObservable(/*ThreadPoolScheduler.Instance*/);
            var render = Observable.Interval(TimeSpan.FromMilliseconds(60));

            render.Subscribe(x =>
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(map.ToString());

                map.SnakeMove();
            });

            keys.Throttle(TimeSpan.FromMilliseconds(60))
                .Select(x => x.Key switch 
                {
                    ConsoleKey.UpArrow => Direction.Up,
                    ConsoleKey.DownArrow => Direction.Down,
                    ConsoleKey.LeftArrow => Direction.Left,
                    ConsoleKey.RightArrow => Direction.Right,
                    _ => default,
                })
                .Subscribe(x =>
                {
                    map.Snake.SetDirection(x);
                });

            // 프로그램이 중단되지 않는 이유는 KeyPresses()가 MainThread에서 호출되기 때문
        }
    }
}

