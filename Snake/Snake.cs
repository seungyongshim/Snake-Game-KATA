using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleToAttribute("Snake.Tests")]

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
        static readonly ReadOnlyDictionary<Direction, Direction> Opposition = 
            new ReadOnlyDictionary<Direction, Direction>(new Dictionary<Direction, Direction>
            {
                [Direction.Left] = Direction.Right,
                [Direction.Up] = Direction.Down,
                [Direction.Right] = Direction.Left,
                [Direction.Down] = Direction.Up,
            });

        public Snake(int initY, int initX)
        {
            Body.AddLast((initY, initX));
        }

        public LinkedList<(int Y, int X)> Body { get; set; } = new LinkedList<(int, int)>();

        internal Direction Direction { get; set; } = Direction.Right;

        public void SetDirection(Direction direction)
        {
            if (Opposition[Direction] == direction) return;

            Direction = direction;
        }

        public void Move(Apple apple = Apple.NonExist)
        {
            var (y, x) = Body.Last.Value;

            var newBody = Direction switch
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