using System;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    public class TopScoresChart
    {
        private const int TOP_SCORES_DEFAULT_CAPACITY = 5;

        private TopScoresChartEntry[] topPlayers;

        /// <summary>
        /// The top players in the score board. 
        /// </summary>
        /// <remarks>The players are automatically sorted when the value is set</remarks>
        public TopScoresChartEntry[] TopPlayers
        {
            get
            {
                return this.topPlayers;
            }

            private set
            {
                this.topPlayers = value;
            }
        }

        /// <summary>
        /// Creates a scoreboard with specified capacity
        /// </summary>
        /// <param name="capacity">The maximal number of entries in the scoreboard. Default value is 5</param>
        public TopScoresChart(byte capacity=TOP_SCORES_DEFAULT_CAPACITY)
        {
            this.TopPlayers = new TopScoresChartEntry[capacity];
        }

        private void SortScores()
        {
            //sort in DESCENDING order
            Array.Sort(this.TopPlayers);
            Array.Reverse(this.TopPlayers);
        }

        /// <summary>
        /// Check if the given score should be added in the chart
        /// </summary>
        /// <param name="score">The score to check</param>
        public bool CheckIfHighScoreIsAchieved(int score)
        {
            bool highScoreAchived=false;
            if (Array.IndexOf(this.TopPlayers, null)!=-1)
            {
                highScoreAchived=true;
            }
            else
            {
                highScoreAchived = Array.Exists(this.TopPlayers, entry => entry.Score < score);
            }

            return highScoreAchived;
        }

        /// <summary>
        /// Adds the entry to the scoreboard if the it's score is higher than any of the entries 
        /// </summary>
        /// <param name="newEntry">The entry to add</param>
        /// <returns>Whether the score was added or not</returns>
        public bool AddScore(TopScoresChartEntry newEntry)
        {
            if (newEntry==null)
            {
                throw new ArgumentNullException("Entry must not be null!");
            }

            bool entryShouldBeAdded = this.CheckIfHighScoreIsAchieved(newEntry.Score);
            if (entryShouldBeAdded)
            {
                this.AddEntry(newEntry);
                this.SortScores();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddEntry(TopScoresChartEntry newEntry)
        {
            int indexOfEmptyEntry = Array.IndexOf(this.TopPlayers, null);
            ////check if chart is full
            if (indexOfEmptyEntry != -1) ////chart is not full, we can freely add the entry
            {
                this.TopPlayers[indexOfEmptyEntry] = newEntry;
            }
            else ////chart is full and we need to replace an entry
            {
                int indexToReplace = -1;
                for (int i = 0; i < this.TopPlayers.Length; i++)
                {
                    if (TopPlayers[i].Score<=newEntry.Score)
                    {
                        indexToReplace = i;
                        break;
                    }
                }

                //// move scores with 1 index down AFTER the point of insertion
                for (int i = indexToReplace; i < this.TopPlayers.Length-1; i++)
                {
                    this.TopPlayers[i + 1] = this.TopPlayers[i];
                }

                this.TopPlayers[indexToReplace] = newEntry;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < this.TopPlayers.Length; i++)
            {
                output.AppendLine(String.Format("{0}. {1}", i + 1, this.TopPlayers[i]));
            }

            return output.ToString();
        }
    }
}
