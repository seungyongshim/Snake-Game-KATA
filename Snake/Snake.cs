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
            var (y, x) = Body.Last.Value;

            var newBody = Head switch
            {
                Direction.Left => (y, x - 1),
                Direction.Right => (y, x + 1),
                Direction.Up => (y - 1, x),
                Direction.Down => (y + 1, x),
                _ => throw new Exception()
            };

            Body.AddLast(newBody);

            if (apple == Apple.NonExist)
            {
                Body.RemoveFirst();
            }
        }
    }
}