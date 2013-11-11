using System;

namespace BalloonsPop
{
    internal class Playground
    {
        private byte[,] playGround;

        public byte this[int i, int j]
        {
            get
            {
                return playGround[i, j];
            }
        }

        public int Height
        {
            get
            {
                return this.playGround.GetLength(0);
            }
        }

        public int Width
        {
            get
            {
                return this.playGround.GetLength(1);
            }
        }

        /// <summary>
        /// Creates an instance of the playground class
        /// </summary>
        /// <param name="rows">The rows in the playground</param>
        /// <param name="columns">The columns in the playground</param>
        /// <param name="numberOfColors">The number of different colors of the balloons in the playground</param>
        internal Playground(byte rows, byte columns, byte numberOfColors)
        {
            this.playGround = new byte[rows, columns];
            for (byte row = 0; row < rows; row++)
            {
                for (byte column = 0; column < columns; column++)
                {
                    byte balloonColor = (byte)RandomGenerator.GetNext(1, numberOfColors);
                    this.playGround[row, column] = balloonColor;
                }
            }
        }

        /// <summary>
        /// Checks if the given position is in the playground
        /// </summary>
        public bool IsOnPlayground(int row, int column)
        {
            int rows = this.playGround.GetLength(0);
            int columns = this.playGround.GetLength(1);
            if ((row >= 0 && row < rows) && (column >= 0 && column < columns))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        internal bool IsPositionEmpty(int row, int column)
        {
            if (this.playGround[row, column] == 0)
            {
                return true;
            }

            return false;
        }
        
        internal bool IsPlaygroundEmpty()
        {
            bool isPlaygroundEmpty = true;
            int rows = this.playGround.GetLength(0);
            int columns = this.playGround.GetLength(1);
            bool stop = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (this.playGround[row, col] != 0)
                    {
                        isPlaygroundEmpty = false;
                        stop = true;
                        break;
                    }
                }

                if (stop)
                {
                    break;
                }
            }

            return isPlaygroundEmpty;
        }

        /// <summary>
        /// Pops a balloon at the given position
        /// </summary>
        internal void PopAtPosition(int row, int column)
        {
            byte searchedColor = this.playGround[row, column];
            this.playGround[row, column] = 0;
            this.CheckLeft(row, column, searchedColor);
            this.CheckRight(row, column, searchedColor);
            this.CheckUp(row, column, searchedColor);
            this.CheckDown(row, column, searchedColor);
        }

        /// <summary>
        /// Moves the ballons down if there is an empty spot
        /// </summary>
        internal void ReorderPlayground()
        {
            int rows = this.playGround.GetLength(0);
            int columns = this.playGround.GetLength(1);

            for (int col = 0; col < columns; col++)
            {
                byte[] reorderedColumn = new byte[rows];
                int currentRow = rows - 1;
                for (int row = rows - 1; row >= 0; row--)
                {
                    if (this.playGround[row, col] != 0)
                    {
                        reorderedColumn[currentRow] = this.playGround[row, col];
                        currentRow--;
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    this.playGround[row, col] = reorderedColumn[row];
                }
            }
        }

        /// <summary>
        /// Checks the left neighbour of a given baloon wether it's color is equal to the given one
        /// if true:  Pops a balloon at this position
        /// </summary>
        private void CheckLeft(int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow;
            int newColumn = currentColumn - 1;
            bool isOnPlayground = this.IsOnPlayground(newRow, newColumn);

            if (isOnPlayground && this.playGround[newRow, newColumn] == searchedColor)
            {
                this.playGround[newRow, newColumn] = 0;
                this.CheckLeft(newRow, newColumn, searchedColor);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Checks the right neighbour of a given baloon wether it's color is equal to the given one
        /// if true:  Pops a balloon at this position
        /// </summary>
        private void CheckRight(int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow;
            int newColumn = currentColumn + 1;
            bool isOnPlayground = this.IsOnPlayground(newRow, newColumn);

            if (isOnPlayground && this.playGround[newRow, newColumn] == searchedColor)
            {
                this.playGround[newRow, newColumn] = 0;
                this.CheckRight(newRow, newColumn, searchedColor);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Checks the top neighbour of a given baloon wether it's color is equal to the given one
        /// if true:  Pops a balloon at this position
        /// </summary>
        private void CheckUp(int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow + 1;
            int newColumn = currentColumn;
            bool isOnPlayground = this.IsOnPlayground(newRow, newColumn);

            if (isOnPlayground && this.playGround[newRow, newColumn] == searchedColor)
            {
                this.playGround[newRow, newColumn] = 0;
                this.CheckUp(newRow, newColumn, searchedColor);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Checks the bottom neighbour of a given baloon wether it's color is equal to the given one
        /// if true:  Pops a balloon at this position
        /// </summary>
        private void CheckDown(int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow - 1;
            int newColumn = currentColumn;
            bool isOnPlayground = this.IsOnPlayground(newRow, newColumn);

            if (isOnPlayground && this.playGround[newRow, newColumn] == searchedColor)
            {
                this.playGround[newRow, newColumn] = 0;
                this.CheckDown(newRow, newColumn, searchedColor);
            }
            else
            {
                return;
            }
        }
    }
}