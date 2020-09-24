using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal class ConsoleRenderActor : ReceiveActor
    {
        public ConsoleRenderActor(int height, int width)
        {
            Height = height;
            Width = width;

            Console.CursorVisible = false;
            Receive<List<string>>(Handle);
        }

        private void Handle(List<string> items)
        {
            
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    sb.Append(items[j * Width + i]);
                    sb.Append(' ');
                }
                sb.AppendLine();
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(sb.ToString());
        }

        public int Height { get; }
        public int Width { get; }

        internal static Props Props(int height, int width) =>
            Akka.Actor.Props.Create(() => new ConsoleRenderActor(height, width));


    }
}