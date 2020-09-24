using Akka.Actor;
using System;

namespace Snake
{
    internal class ConsoleRenderActor : ReceiveActor
    {
        internal static Props Props() =>
            Akka.Actor.Props.Create(() => new ConsoleRenderActor());
    }
}