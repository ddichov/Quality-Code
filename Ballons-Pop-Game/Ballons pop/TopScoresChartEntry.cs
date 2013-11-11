using System;

namespace BalloonsPop
{
    public class TopScoresChartEntry : IComparable<TopScoresChartEntry>
    {
        public int Score { get; set; }

        public string Name { get; set; }

        public TopScoresChartEntry(int score, string name)
        {
            this.Score = score;
            this.Name = name;
        }

        public int CompareTo(TopScoresChartEntry other)
        {
            if (other == null)
            {
                return 1;
            }

            return Score.CompareTo(other.Score)*-1;
        }

        public override string ToString()
        {
            return String.Format("{0} with {1} moves.", this.Name, this.Score);
        }
    }
}