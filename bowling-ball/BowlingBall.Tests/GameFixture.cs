using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BowlingBall.Model;
namespace rollingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        Game game;

        [TestInitialize]
        public void Setup()
        {
            game = new Game();
        }

        [TestMethod]
        public void Should_be_20()
        {
            List<Frame> rolling = GetRolling2();

            game.Execute(rolling);

            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void Knocks_down_normal_pins()
        {
            List<Frame> rolling = GetRolling();

            game.Execute(rolling);
            Assert.AreEqual(20, rolling[0].Score);
            Assert.AreEqual(35, rolling[1].Score);
            Assert.AreEqual(52, rolling[2].Score);
            Assert.AreEqual(61, rolling[3].Score);
            Assert.AreEqual(91, rolling[4].Score);
            Assert.AreEqual(120, rolling[5].Score);
            Assert.AreEqual(139, rolling[6].Score);
            Assert.AreEqual(148, rolling[7].Score);
            Assert.AreEqual(167, rolling[8].Score);
            Assert.AreEqual(187, rolling[9].Score);
        }



        [TestMethod]
        public void Knocks_down_all_10_pins()
        {
            List<Frame> rolling = GetRolling1();

            game.Execute(rolling);

            Assert.AreEqual(30, rolling[0].Score);
            Assert.AreEqual(60, rolling[1].Score);
            Assert.AreEqual(90, rolling[2].Score);
            Assert.AreEqual(120, rolling[3].Score);
            Assert.AreEqual(150, rolling[4].Score);
            Assert.AreEqual(180, rolling[5].Score);
            Assert.AreEqual(210, rolling[6].Score);
            Assert.AreEqual(240, rolling[7].Score);
            Assert.AreEqual(270, rolling[8].Score);
            Assert.AreEqual(300, rolling[9].Score);
        }

        private static List<Frame> GetRolling1()
        {
            return new List<Frame>() {
                new Frame { Roll1 = 10, FrameID = 1 },
                new Frame { Roll1 = 10,Roll2 = 0, FrameID = 2 },
                new Frame { Roll1 = 10,Roll2 = 0, FrameID = 3 },
                new Frame { Roll1 = 10,Roll2 = 0, FrameID = 4 },
                new Frame { Roll1 = 10, FrameID = 5 },
                new Frame { Roll1 = 10, FrameID = 6 },
                new Frame { Roll1 = 10, FrameID = 7 },
                new Frame { Roll1 = 10,Roll2=0, FrameID = 8 },
                new Frame { Roll1 = 10,Roll2 = 0, FrameID = 9 },
                new Frame { Roll1 = 10,Roll2 = 0, Extraroll=10, FrameID = 10 }
            };
        }

        private static List<Frame> GetRolling()
        {
            return new List<Frame>() {
                new Frame { Roll1 = 10, FrameID = 1 },
                new Frame { Roll1 = 9,Roll2 = 1, FrameID = 2 },
                new Frame { Roll1 = 5,Roll2 = 5, FrameID = 3 },
                new Frame { Roll1 = 7,Roll2 = 2, FrameID = 4 },
                new Frame { Roll1 = 10, FrameID = 5 },
                new Frame { Roll1 = 10, FrameID = 6 },
                new Frame { Roll1 = 10, FrameID = 7 },
                new Frame { Roll1 = 9,Roll2=0, FrameID = 8 },
                new Frame { Roll1 = 8,Roll2 = 2, FrameID = 9 },
                new Frame { Roll1 = 9,Roll2 = 1, Extraroll=10, FrameID = 10 }
            };
        }
        private static List<Frame> GetRolling2()
        {
            return new List<Frame>() {
                new Frame { Roll1 = 10, FrameID = 1 },
                new Frame { Roll1 = 0, FrameID = 2 },
                new Frame { Roll1 = 0, FrameID = 3 },
                new Frame { Roll1 = 0, FrameID = 4 },
                new Frame { Roll1 = 0, FrameID = 5 },
                new Frame { Roll1 = 0, FrameID = 6 },
                new Frame { Roll1 = 0, FrameID = 7 },
                new Frame { Roll1 = 0, FrameID = 8 },
                new Frame { Roll1 = 0, FrameID = 9 },
                new Frame { Roll1 = 0, FrameID = 10 }
            };
        }
    }
}
