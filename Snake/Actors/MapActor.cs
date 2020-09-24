using Akka.Actor;

namespace Snake
{
    internal class MapActor : ReceiveActor
    {
        public MapActor(Map map)
        {
            Map = map;
        }

        public Map Map { get; set; }

        internal static Props Props(Map map) =>
            Akka.Actor.Props.Create(() => new MapActor(map));
    }
}