using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Tests
{
    [TestClass()]
    public class GameTests
    {
        //[TestMethod()]
        //public void GameTest()
        //{

        //}
        [TestMethod()]
        public void StartTest()
        {
            Game game = new Game(4);
            game.Start(0);
            Assert.AreEqual(1, game.GetDigitAt(0, 0));
            Assert.AreEqual(2, game.GetDigitAt(1, 0));
            Assert.AreEqual(5, game.GetDigitAt(0, 1));
            Assert.AreEqual(15, game.GetDigitAt(2, 3));
            Assert.AreEqual(0, game.GetDigitAt(3, 3));
        }
        [TestMethod()]
        public void PressAtTest()
        {
            Game game = new Game(4);
            game.Start(0);
            game.PressAt(2, 3);
            Assert.AreEqual(0, game.GetDigitAt(2, 3));
            Assert.AreEqual(15, game.GetDigitAt(3, 3));
            game.PressAt(2, 2);
            Assert.AreEqual(0, game.GetDigitAt(2, 2));
            Assert.AreEqual(11, game.GetDigitAt(2, 3));
        }
        [TestMethod()]
        public void GetDigitAtTest()
        {
            Game game = new Game(4);
            game.Start(0);
            Assert.AreEqual(0, game.GetDigitAt(-2, -93));
            Assert.AreEqual(0, game.GetDigitAt(16, 2));
        }
        [TestMethod()]
        public void SolvedTest()
        {
            Game game = new Game(4);
            game.Start(0);
            Assert.IsTrue(game.Solved());
            game.PressAt(2, 3);
            //Assert.IsTrue(game.Solved());
            game.PressAt(3, 3);
            Assert.IsTrue(game.Solved());
        }
    }
}