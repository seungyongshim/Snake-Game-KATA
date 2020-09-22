using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Snake.Tests
{
    public class MapSpec
    {
        [Fact]
        public void Should_Be_Make_Map()
        {
            // arrange 
            var map = new Map(5, 5);

            // act


            // assert
            map.ToString().Should().Be(". . . . . \n" +
                                       ". . . . . \n" +
                                       ". . . . . \n" +
                                       ". . . . . \n" +
                                       ". . . . . \n");
        }

        [Fact]
        public void Should_Be_Make_Snake()
        {
            // arrange 
            var map = new Map(5, 5);

            // act
            map.GenerateSnake();

            // assert
            map.ToString().Should().Be(". . . . . \n" +
                                       ". . . . . \n" +
                                       ". . O O . \n" +
                                       ". . . . . \n" +
                                       ". . . . . \n");
        }

        [Fact]
        public void Should_Be_Move_Snake()
        {
            // arrange 
            var map = new Map(5, 5);

            // act
            map.GenerateSnake();
            map.SnakeMove();

            // assert
            map.ToString().Should().Be(". . . . . \n" +
                                       ". . . . . \n" +
                                       ". . . O O \n" +
                                       ". . . . . \n" +
                                       ". . . . . \n");
        }

        
    }
}
