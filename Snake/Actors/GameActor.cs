using Akka.Actor;
using Snake.InternalMessages;
using System;
using System.Linq;

namespace Snake
{
    using static TimeSpan;
    internal class GameActor : ReceiveActor
    {
        public GameActor(Map map, IActorRef snakeActor, IActorRef consoleRenderActor)
        {
            SnakeActor = snakeActor;
            ConsoleRenderActor = consoleRenderActor;
            Map = map;

            Context.System.Scheduler.ScheduleTellRepeatedly(FromMilliseconds(100),
                                                            FromMilliseconds(33),
                                                            Self,
                                                            TickGame.Instance,
                                                            Self);

            Receive<TickGame>(Handle);
            Receive<SnakeResult>(Handle);
        }

        private void Handle(SnakeResult msg)
        {
            Map.Update(msg.SnakePos);
            ConsoleRenderActor.Tell(Map.GetResult()
                                       .Select(x => x.ToString())
                                       .ToList());
        }

        public void Handle(TickGame _)
        {
            SnakeActor.Tell(new Move
            {
                Apple = Map.ApplePos
            });
        }

        public IActorRef SnakeActor { get; set; }
        public IActorRef ConsoleRenderActor { get; set; }

        public Map Map { get; set; }

        internal static Props Props(Map map, IActorRef snakeActor, IActorRef consoleRenderActor) =>
            Akka.Actor.Props.Create(() => new GameActor(map, snakeActor, consoleRenderActor));
    }
}