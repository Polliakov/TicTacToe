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

        private CellState cellState;
        private int x;
        private int y;

        public void Update(CellState[,] field, Settings settings)
        {
            this.field = field;
            this.settings = settings;
        }

        public bool Check(int x, int y, CellState cellState)
        {
            this.x = x;
            this.y = y;
            this.cellState = cellState;

            if (y - (settings.WinningScore - 1) >= 0)
            {
                if (CheckLine(-1, 0)) return true;
            }
            if (y + settings.WinningScore <= settings.FieldHeight)
            {
                if (CheckLine(1, 0)) return true;
            }
            if (x - (settings.WinningScore - 1) >= 0)
            {
                if (CheckLine(0, -1)) return true;
            }
            if (x + settings.WinningScore <= settings.FieldWidth)
            {
                if (CheckLine(0, 1)) return true;
            }
            if (y - (settings.WinningScore - 1) >= 0 &&
                x - (settings.WinningScore - 1) >= 0)
            {
                if (CheckLine(-1, -1)) return true;
            }
            if (y - (settings.WinningScore - 1) >= 0 &&
                x + settings.WinningScore <= settings.FieldWidth)
            {
                if (CheckLine(-1, 1)) return true;
            }
            if (y + settings.WinningScore <= settings.FieldHeight &&
                x - (settings.WinningScore - 1) >= 0)
            {
                if (CheckLine(1, -1)) return true;
            }
            if (y + settings.WinningScore <= settings.FieldHeight &&
                x + settings.WinningScore <= settings.FieldWidth)
            {
                if (CheckLine(1, 1)) return true;
            }

            return false;
        }

        private bool CheckLine(int yDirection, int xDirection)
        {
            for (int i = 1; i < settings.WinningScore; i++)
            {
                if (field[y + i * yDirection, x + i * xDirection] != cellState) return false;
            }

            return true;
        }
        
    }
}
