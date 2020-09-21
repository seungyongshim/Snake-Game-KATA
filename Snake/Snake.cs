using System;
using System.Collections.Generic;

namespace Snake
{
    public enum Apple
    {
        Exist,
        NonExist
    }

    public enum Direction
    {
        Left, Right, Up, Down
    }

    public class Snake
    {
        public Snake(int initY, int initX)
        {
            Body.AddLast((initY, initX));
        }

        public LinkedList<(int Y, int X)> Body { get; set; } = new LinkedList<(int, int)>();

        public Direction Head { get; set; } = Direction.Right;

        public void Move(Apple apple = Apple.NonExist)
        {
            var last = Body.Last.Value;

            var newBody = Head switch
            {
                Direction.Left => (last.Y, last.X - 1),
                Direction.Right => (last.Y, last.X + 1),
                Direction.Up => (last.Y - 1, last.X),
                Direction.Down => (last.Y + 1, last.X),
                _ => throw new Exception()
            };

            Body.AddLast(newBody);
            Body.RemoveFirst();
        }
    }
}