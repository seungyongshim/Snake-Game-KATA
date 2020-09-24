using Akka;
using Akka.Actor;
using System;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var akka = ActorSystem.Create("snake");

            var snakeActor = akka.ActorOf(SnakeActor.Props(new Snake(12, 12)));
            var consoleRenderActor = akka.ActorOf(ConsoleRenderActor.Props(25, 25));
            var gameActor = akka.ActorOf(GameActor.Props(new Map(25, 25), snakeActor, consoleRenderActor));
            

            while (true)
            {
                var key = Console.ReadKey();

                var direction = key.Key switch
                {
                    ConsoleKey.UpArrow => Direction.Up,
                    ConsoleKey.DownArrow => Direction.Down,
                    ConsoleKey.LeftArrow => Direction.Left,
                    ConsoleKey.RightArrow => Direction.Right,
                    _ => default,
                };

                snakeActor.Tell(direction);
            }
        }
    }
}
