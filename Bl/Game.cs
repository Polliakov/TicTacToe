using System;

namespace Bl
{
    public class Game : IGameLogic
    {
        public Game()
        {
            settings = new Settings
            {
                Player1Name = "Крестики",
                Player2Name = "Нолики",
                FieldHeight = 19,
                FieldWidth = 19,
                WinningScore = 5
            };
            player = Player.First;

            field = new CellState[settings.FieldHeight, settings.FieldWidth];
            checker = new Checker(field, settings);
        }

        public event Action<Settings> UIAdded;
        public event Action<Settings> FieldReseted;
        public event Action<Settings> SettingsSent;
        public event Action<Settings> SettingsAccepted;
        public event Action<int, int, CellState> FieldChanged;
        public event Action<string> PlayerChanged;
        public event Action<string> Win;

        private readonly Checker checker;
        private string CurrentPlayerName
        {
            get
            {
                return player == Player.First ? settings.Player1Name + " X" : settings.Player2Name + " O";
            }
        }
        private Settings settings;
        private CellState[,] field;
        private Player player;

        private enum Player
        {
            First,
            Second
        }

        public void AddUI(IUserInterface ui)
        {
            ui.Input += Turn;
            ui.SettingsRecived += AcceptSettings;
            ui.FieldReset += ResetField;
            ui.NededSettings += () => SettingsSent.Invoke(settings);

            UIAdded?.Invoke(settings);
            PlayerChanged(CurrentPlayerName);
        }

        private void Turn(int x, int y)
        {
            if (field[y, x] != CellState.Empty) return;

            CellState cellState;

            cellState = (player == Player.First) ? CellState.Cross : CellState.Zero;

            field[y, x] = cellState;
            FieldChanged?.Invoke(x, y, cellState);

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

        private void AcceptSettings(Settings settings)
        {
            this.settings = settings;
            field = new CellState[this.settings.FieldHeight, this.settings.FieldWidth];
            checker.Update(field, this.settings);
            player = Player.First;

            SettingsAccepted?.Invoke(settings);
            PlayerChanged?.Invoke(CurrentPlayerName);
        }

        private void ResetField()
        {
            field = new CellState[settings.FieldHeight, settings.FieldWidth];
            checker.Update(field, settings);
            player = Player.First;

            FieldReseted.Invoke(settings);
            PlayerChanged?.Invoke(CurrentPlayerName);
        }
    }
}
