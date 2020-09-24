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
            var mapActor = akka.ActorOf(MapActor.Props(new Map(25, 25)));
            var keyboardActor = akka.ActorOf(KeyBoardActor.Props());
            var consoleRenderActor = akka.ActorOf(ConsoleRenderActor.Props());

            akka.WhenTerminated.Wait();
        }
    }
}
