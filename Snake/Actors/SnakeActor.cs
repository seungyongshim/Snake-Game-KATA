using Akka.Actor;
using Snake.InternalMessages;
using System;

namespace Snake
{
    internal class SnakeActor : ReceiveActor
    {
        public SnakeActor(Snake snake)
        {
            Snake = snake;

            Receive<Direction>(Handle);
            Receive<Move>(Handle);
        }

        private void Handle(Move msg)
        {
            Snake.Move(msg.Apple);
            Sender.Tell(Snake.Clone());
        }

        private void Handle(Direction direciton)
        {
            Snake.Direction = direciton;
        }

        public Snake Snake { get; }

        internal static Props Props(Snake snake) =>
            Akka.Actor.Props.Create(() => new SnakeActor(snake));
    }
}