using System;
using System.Linq;

namespace BalloonsPop
{
    static class ConsoleRenderer
    {
        public static void DrаwPlayground(Playground playground)
        {
            int rows = playground.Height;
            int columns = playground.Width;

            DrawFirstRow(columns);
            DrawHorizontalBorder(columns);

            for (byte row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                DrawRowContent(playground, columns, row);
                Console.WriteLine("| ");
            }

            DrawHorizontalBorder(columns);
        }

        public static void DrawRowContent(Playground playground, int columns, int row)
        {
            for (int col = 0; col < columns; col++)
            {
                if (playground[row, col] == 0)
                {
                    Console.Write("  ");
                    continue;
                }

                Console.Write("{0} ", playground[row, col]);
            }
        }

        public static void DrawFirstRow(int columns)
        {
            Console.Write("    ");
            for (byte column = 0; column < columns; column++)
            {
                Console.Write("{0} ", column);
            }

            Console.WriteLine();
        }

        public static void DrawHorizontalBorder(int columns)
        {
            string border = new string('-', (columns * 2 + 1));
            Console.WriteLine("   {0}", border);
        }

        /// <summary>
        /// Draws the top scores chart
        /// </summary>
        /// <param name="chart">The chart to draw</param>
        public static void DrawTopScoresChart(TopScoresChart chart)
        {
            Console.WriteLine("Top {0} scores:", chart.TopPlayers.Length);
            Console.WriteLine(chart.ToString());
        }
    }
}
