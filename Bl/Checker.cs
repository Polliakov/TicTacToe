using System.Collections.Generic;

namespace Bl
{
    public class Checker
    {
        public Checker(CellState[,] field, Settings settings)
        {
            this.field = field;
            this.settings = settings;
        }

        private Settings settings;
        private CellState[,] field;

        public void Update(CellState[,] field, Settings settings)
        {
            this.field = field;
            this.settings = settings;
        }

        public bool CheckWin(int x, int y)
        {
            var cellState = field[y, x];
            var lines = GetLines(x, y);

            for (int i = 0; i < 4; i++)
            {
                if (CheckLine(lines[i], cellState)) return true;
            }

            return false;
        }

        private bool CheckLine(List<CellState> line, CellState cellState)
        {
            if (line.Count < settings.WinningScore) return false;

            int score = 0;
            for (int i = 0; i < line.Count; i++)
            {
                if (line[i] == cellState) score++;
                else score = 0;

                if (score == settings.WinningScore) return true;
            }

            return false;
        }

        private List<CellState>[] GetLines(int x, int y)
        {
            var lines = new List<CellState>[4];
            for (int i = 0; i < 4; i++)
            {
                lines[i] = new List<CellState>();
            }

            for (int i = -(settings.WinningScore - 1); i < settings.WinningScore; i++)
            {
                if (x + i >= 0 && x + i < settings.FieldWidth)
                {
                    lines[0].Add(field[y, x + i]);

                    if (y + i >= 0 && y + i < settings.FieldHeight)
                    {
                        lines[1].Add(field[y + i, x + i]);
                    }
                }

                if (y + i >= 0 && y + i < settings.FieldHeight)
                {
                    lines[2].Add(field[y + i, x]);

                    if (x - i >= 0 && x - i <settings.FieldWidth)
                    {
                        lines[3].Add(field[y + i, x - i]);
                    }
                }
            }

            return lines;
        }
    }
}
