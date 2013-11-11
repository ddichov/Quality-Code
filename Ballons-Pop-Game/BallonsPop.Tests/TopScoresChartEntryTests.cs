using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalloonsPop;

namespace BallonsPop.Tests
{
    [TestClass]
    public class TopScoresChartEntryTests
    {
        [TestMethod]
        public void TopScoresChartEntryConstructorTest()
        {
            int score = 123;
            string name = "Kaloyan";
            TopScoresChartEntry player = new TopScoresChartEntry(score, name);
            Assert.AreEqual(player.Name, name);
        }

        [TestMethod]
        public void CompareToTest()
        {
            int score = 123;
            string name = "Kaloyan";
            TopScoresChartEntry player1 = new TopScoresChartEntry(score, name);
            int scoreSP = 234;
            string nameSP = "Petur";
            TopScoresChartEntry player2 = new TopScoresChartEntry(scoreSP, nameSP);
            Assert.IsFalse(player1.Score == player2.Score);
        }

        [TestMethod]
        public void CompareToNullTest()
        {
            int score = 123;
            string name = "Kaloyan";
            TopScoresChartEntry player = new TopScoresChartEntry(score, name);
            int result = player.CompareTo(null);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void ToStringTest()
        {
            int score = 123;
            string name = "Kaloyan";
            TopScoresChartEntry player = new TopScoresChartEntry(score, name);
            string toStringReturn = "Kaloyan with 123 moves.";
            string returnString = player.ToString();
            Assert.AreEqual(toStringReturn, returnString);
        }


    }
}
