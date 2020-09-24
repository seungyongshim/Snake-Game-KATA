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
        public void Make_Map()
        {
            // arrange 
            var map = new Map(5, 5);

            // act


            // assert
            map.ToString().Should().Be(".,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.,.");
        }

        [Fact]
        public void Make_Snake()
        {
            // arrange 
            var map = new Map(5, 5);

            // act
            map.GenerateSnake();

            // assert
            map.ToString().Should().Be(".,.,.,.,.,.,.,.,.,.,.,.,O,O,.,.,.,.,.,.,.,.,.,.,.");
        }

        [Fact]
        public void Move_Snake()
        {
            // arrange 
            var map = new Map(5, 5);

            // act
            map.GenerateSnake();
            map.SnakeMove();

            // assert
            map.ToString().Should().Be(".,.,.,.,.,.,.,.,.,.,.,.,.,O,O,.,.,.,.,.,.,.,.,.,.");
        }

        [Fact]        
        public void Make_Apple()
        {
            // arrange 
            var map = new Map(5, 5);

            // act
            map.GenerateSnake();
            map.MakeApple();

            // assert
            map.ApplePos.Should().NotBe(default);
        }

        [Fact]
        public void TupleDefaultUnderstanding()
        {
            (0, 0).Should().Equals(default);
        }
    }
}
