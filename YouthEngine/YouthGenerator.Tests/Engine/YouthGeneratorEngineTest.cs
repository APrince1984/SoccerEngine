using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using YouthGenerator.Data;
using YouthGenerator.Engine;

namespace YouthGenerator.Tests.Engine
{
    [TestFixture]
    public class YouthGeneratorEngineTest
    {
        private static readonly Random Rnd = new Random();

        [Test]
        [TestCase(Position.Goaly)]
        [TestCase(Position.Defence)]
        [TestCase(Position.Midfield)]
        [TestCase(Position.Forward)]
        public void CreatePlayer_ReturnsPlayerWithPositionsAndAttributes(int mainPosition)
        {
            var player = YouthGeneratorEngine.CreatePlayer(Rnd.Next(5, 25), mainPosition);
            Assert.IsNotNull(player);
            Assert.IsNotNull(player.MainPosition);
            Assert.IsNotEmpty(player.Positions);
            Assert.GreaterOrEqual(player.Positions.Count, 1);
            Assert.IsNotEmpty(player.PlayerAttributes);
            Assert.AreEqual(28, player.PlayerAttributes.Count);
        }

        [Test]
        [TestCase(Position.Goaly)]
        [TestCase(Position.Defence)]
        [TestCase(Position.Midfield)]
        [TestCase(Position.Forward)]
        public void SetPlayerAttributes_SetsAllPlayerAttributes(int mainPosition)
        {
            var player = new Player { MainPosition = mainPosition };
            YouthGeneratorEngine.SetPlayerAttributes(Rnd.Next(5,125), player);
            Assert.IsNotNull(player.PlayerAttributes);
            Assert.AreEqual(28, player.PlayerAttributes.Count);
            var fields = typeof(AttributeName.GoalyAttributes).GetFields();
            foreach (var field in fields)
                Assert.IsTrue(player.PlayerAttributes.Keys.Contains(field.Name));
        }

        [Test]
        [TestCase(typeof(PlayerPosition.DefensivePositions))]
        [TestCase(typeof(PlayerPosition.MidfieldPositions))]
        [TestCase(typeof(PlayerPosition.ForwardPositions))]
        public void SetPlayerPositions_SetsPlayerPositions(Type positionType)
        {
            var player = new Player{Positions = new List<int>()};
            YouthGeneratorEngine.SetPlayerPositions(player, positionType);
            Assert.IsNotEmpty(player.Positions);
            Assert.GreaterOrEqual(player.Positions.Count, 1);
        }

        [Test]
        [TestCase(Position.Goaly)]
        [TestCase(Position.Defence)]
        [TestCase(Position.Midfield)]
        [TestCase(Position.Forward)]
        public void SetPlayerPositionsByMainPosition_SetsPlayerPositionsByMainPosition(int mainPosition)
        {
            var player = new Player{MainPosition = mainPosition};
            YouthGeneratorEngine.SetPlayerPositionsByMainPosition(player);
            Assert.IsNotEmpty(player.Positions);
            Assert.GreaterOrEqual(player.Positions.Count, 1);
            switch (mainPosition)
            {
                case Position.Goaly:
                    Assert.AreEqual(1, player.Positions.Count);
                    Assert.IsTrue(player.Positions.Contains(PlayerPosition.Goaly));
                    break;
                case Position.Defence:
                    Assert.IsTrue(player.Positions.Contains(PlayerPosition.DefensivePositions.CenterBack) 
                                  || player.Positions.Contains(PlayerPosition.DefensivePositions.DefensiveMidfield)
                                  || player.Positions.Contains(PlayerPosition.DefensivePositions.RightBack)
                                  || player.Positions.Contains(PlayerPosition.DefensivePositions.LeftBack));
                    break;
                case Position.Midfield:
                    Assert.IsTrue(player.Positions.Contains(PlayerPosition.MidfieldPositions.CenterMidfield)
                                  || player.Positions.Contains(PlayerPosition.MidfieldPositions.DefensiveMidfield)
                                  || player.Positions.Contains(PlayerPosition.MidfieldPositions.AttackingMidfield)
                                  || player.Positions.Contains(PlayerPosition.MidfieldPositions.LeftMidfield)
                                  || player.Positions.Contains(PlayerPosition.MidfieldPositions.RightMidfield));
                    break;
                default:
                    Assert.IsTrue(player.Positions.Contains(PlayerPosition.ForwardPositions.Forward)
                                  || player.Positions.Contains(PlayerPosition.ForwardPositions.AttackingMidfield));
                    break;
            }
        }

        [Test]
        [TestCase(Position.Defence, PlayerPosition.DefensivePositions.CenterBack, typeof(PlayerPosition.DefensivePositions))]
        [TestCase(Position.Defence, PlayerPosition.DefensivePositions.DefensiveMidfield, typeof(PlayerPosition.DefensivePositions))]
        [TestCase(Position.Defence, PlayerPosition.DefensivePositions.RightBack, typeof(PlayerPosition.DefensivePositions))]
        [TestCase(Position.Defence, PlayerPosition.DefensivePositions.LeftBack, typeof(PlayerPosition.DefensivePositions))]
        [TestCase(Position.Midfield, PlayerPosition.MidfieldPositions.DefensiveMidfield, typeof(PlayerPosition.MidfieldPositions))]
        [TestCase(Position.Midfield, PlayerPosition.MidfieldPositions.CenterMidfield, typeof(PlayerPosition.MidfieldPositions))]
        [TestCase(Position.Midfield, PlayerPosition.MidfieldPositions.AttackingMidfield, typeof(PlayerPosition.MidfieldPositions))]
        [TestCase(Position.Midfield, PlayerPosition.MidfieldPositions.RightMidfield, typeof(PlayerPosition.MidfieldPositions))]
        [TestCase(Position.Midfield, PlayerPosition.MidfieldPositions.LeftMidfield, typeof(PlayerPosition.MidfieldPositions))]
        [TestCase(Position.Forward, PlayerPosition.ForwardPositions.Forward, typeof(PlayerPosition.ForwardPositions))]
        [TestCase(Position.Forward, PlayerPosition.ForwardPositions.AttackingMidfield, typeof(PlayerPosition.ForwardPositions))]
        public void GetNewPlayerPositionValueIfNeeded_PlayerHasPositionAlready_FillsOtherValue(int mainPosition, int position, Type type)
        {
            var player = new Player
            {
                MainPosition = mainPosition,
                Positions = new List<int> {position}
            };
            var newPosition = YouthGeneratorEngine.GetNewPlayerPositionValueIfNeeded(player, position,type.GetFields());
            Assert.AreNotEqual(position, newPosition);
        }
    }
}
