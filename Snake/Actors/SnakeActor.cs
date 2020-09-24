using Akka.Actor;

namespace Snake
{
    internal class SnakeActor : ReceiveActor
    {
        public SnakeActor(Snake snake)
        {
            Snake = snake;
        }

        public Snake Snake { get; }

        internal static Props Props(Snake snake) =>
            Akka.Actor.Props.Create(() => new SnakeActor(snake));
    }
}