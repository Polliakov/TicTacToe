using System;

namespace Bl
{
    public class Game : IGameLogic
    {
        public Game()
        {
            settings = new Settings();
            player = Player.First;

            field = new CellState[settings.FieldHeight, settings.FieldWidth];
            checker = new Checker(field, settings);
        }

        public event Action FieldReseted;
        public event Action<int, int> FieldRecreated;
        public event Action<int, int, CellState> CellChanged;
        public event Action<string> PlayerChanged;
        public event Action<string> Win;

        private string CurrentPlayerName
        {
            get
            {
                return player == Player.First ? settings.Player1Name + " X" : settings.Player2Name + " O";
            }
        }
        private readonly Checker checker;
        private Settings settings;
        private CellState[,] field;
        private Player player;

        private enum Player
        {
            First,
            Second
        }

        public Settings GetSettings()
        {
            return new Settings(settings);
        }

        public void Turn(int x, int y)
        {
            if (x < 0 || y < 0 || x >= settings.FieldWidth || y >= settings.FieldHeight)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (field[y, x] != CellState.Empty) return;

            CellState cellState;

            cellState = (player == Player.First) ? CellState.Cross : CellState.Zero;

            field[y, x] = cellState;
            CellChanged?.Invoke(x, y, cellState);

            if (checker.CheckWin(x, y))
            {
                Win?.Invoke(CurrentPlayerName);
                ResetField();
                player = Player.First;
                PlayerChanged(CurrentPlayerName);
                return;
            }

            player = (player == Player.First) ? Player.Second : Player.First;
            PlayerChanged?.Invoke(CurrentPlayerName );
        }     

        public void AcceptSettings(Settings settings)
        {
            this.settings = settings;
            field = new CellState[this.settings.FieldHeight, this.settings.FieldWidth];
            checker.Update(field, this.settings);
            player = Player.First;

            FieldRecreated?.Invoke(settings.FieldHeight, settings.FieldWidth);
            PlayerChanged?.Invoke(CurrentPlayerName);
        }

        public void ResetField()
        {
            field = new CellState[settings.FieldHeight, settings.FieldWidth];
            checker.Update(field, settings);
            player = Player.First;

            FieldReseted.Invoke();
            PlayerChanged?.Invoke(CurrentPlayerName);
        }
    }
}
