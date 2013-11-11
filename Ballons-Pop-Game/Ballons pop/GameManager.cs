using System;
using System.Linq;

namespace BalloonsPop
{
    /// <summary>
    /// A class the serves to manage all game logic related operations
    /// </summary>
    class GameManager
    {
        private const int PLAYGROUND_ROWS = 5;

        private const int PLAYGROUND_COLUMNS = 10;

        private const int BALLOON_COLORS_COUNT = 4;

        public int UserMoves
        {
            get;
            private set;
        }

        public Playground PlayGround
        {
            get;
            set;
        }

        public GameManager()
        {
            this.UserMoves = 0;
            this.PlayGround = new Playground(PLAYGROUND_ROWS, PLAYGROUND_COLUMNS, BALLOON_COLORS_COUNT);
        }

        public void PopAtPosition(int row, int column)
        {
            UserMoves++;
            this.PlayGround.PopAtPosition(row, column);
        }
    }
}
