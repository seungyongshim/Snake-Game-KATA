using Akka.Actor;
using System;

namespace Snake
{
    internal class KeyBoardActor: ReceiveActor
    {
        internal static Props Props() =>
            Akka.Actor.Props.Create(() => new KeyBoardActor());
    }
}