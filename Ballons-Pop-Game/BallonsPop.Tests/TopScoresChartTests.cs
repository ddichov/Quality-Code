using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalloonsPop;

namespace BallonsPop.Tests
{
    [TestClass]
    public class TopScoresChartTests
    {
        [TestMethod]
        public void TopScoresChartEntryTest()
        {
            TopScoresChart topscores = new TopScoresChart();
            int score = 123;
            string name = "Kaloyan";
            TopScoresChartEntry player = new TopScoresChartEntry(score, name);
            topscores.AddScore(player);
            Assert.IsTrue(topscores != null);
        }

        [TestMethod]
        public void AddEntryTest()
        {
            TopScoresChart topscores = new TopScoresChart();
            int score = 123;
            string name = "Kaloyan";
            TopScoresChartEntry player = new TopScoresChartEntry(score, name);
            topscores.AddScore(player);
            Assert.IsTrue(topscores != null);
        }

        [TestMethod]
        public void TopScoresChartCapacityTest()
        {
            byte chartCapacity = 6;
            TopScoresChart topscores = new TopScoresChart(chartCapacity);
            Assert.IsTrue(topscores != null);
        }

        [TestMethod]
        public void CheckIfHighScoreIsAchievedTest()
        {
            TopScoresChart topscores = new TopScoresChart();
            int score = 123;
            int scoreToCheck = 1234;
            string name = "Kaloyan";
            TopScoresChartEntry player = new TopScoresChartEntry(score, name);
            topscores.AddScore(player);
            topscores.AddScore(player);
            topscores.AddScore(player);
            topscores.AddScore(player);
            topscores.AddScore(player);
            bool scoreCheck = topscores.CheckIfHighScoreIsAchieved(scoreToCheck);
            Assert.IsTrue(scoreCheck);
        }

        [TestMethod]
        public void AddScoreFalceTest()
        {
            TopScoresChart topscores = new TopScoresChart();
            int score = 123;
            string name = "Kaloyan";
            int scoreSecondPlayer = 12;
            string nameSecondPLayer = "Petur";
            TopScoresChartEntry secondPlayer = new TopScoresChartEntry(scoreSecondPlayer, nameSecondPLayer);
            TopScoresChartEntry player = new TopScoresChartEntry(score, name);
            topscores.AddScore(player);
            topscores.AddScore(player);
            topscores.AddScore(player);
            topscores.AddScore(player);
            topscores.AddScore(player);
            topscores.AddScore(secondPlayer);
            Assert.IsTrue(topscores != null);
        }

        [TestMethod]
        public void TestAddingScoreWhenChartIsFull()
        {
            TopScoresChart chart = new TopScoresChart(3);
            chart.AddScore(new TopScoresChartEntry(4, "Stamat"));
            chart.AddScore(new TopScoresChartEntry(6, "Sulio"));
            chart.AddScore(new TopScoresChartEntry(3, "Pulio"));
            TopScoresChartEntry newPlayer = new TopScoresChartEntry(5, "Stamat");
            chart.AddScore(newPlayer);
            Assert.AreEqual(newPlayer, chart.TopPlayers[2]);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingNullScore()
        {
            TopScoresChart chart = new TopScoresChart(3);
            chart.AddScore(null);

        }
		
		


        [TestMethod]
        public void ToStringTest()
        {
            TopScoresChart topscores = new TopScoresChart();
            int score = 123;
            string name = "Kaloyan";
            TopScoresChartEntry player = new TopScoresChartEntry(score, name);
            topscores.AddScore(player);
            string toStringExpectedReturn = "1. Kaloyan with 123 moves.\r\n2. \r\n3. \r\n4. \r\n5. \r\n";
            string returnString = topscores.ToString();
            Assert.AreEqual(toStringExpectedReturn, returnString);
        }
    }
}
