using System;
using System.Collections.Generic;

namespace Snake
{
    public enum Direction
    {
        Left, Right, Up, Down
    }

    public class Snake
    {
        public Snake(int initY, int initX)
        {
            Body.Enqueue((initY, initX));
        }

        public Queue<(int, int)> Body { get; set; } = new Queue<(int, int)>();

        public Direction Head { get; set; } = Direction.Right;

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}