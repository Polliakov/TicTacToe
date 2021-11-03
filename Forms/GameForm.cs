using System;
using System.Drawing;
using System.Windows.Forms;

using Bl;

namespace UI.Forms
{
    public partial class GameForm : Form
    {
        public GameForm(IGameLogic game)
        {
            InitializeComponent();

            this.game = game;
            fieldBuilder = new FieldBuilder(pnlField);
            var settings = game.GetSettings();

            field = fieldBuilder.Create(settings.FieldHeight, settings.FieldWidth);
            SubscribeOnFieldClick(settings.FieldHeight, settings.FieldWidth);

            game.FieldReseted += ResetField;
            game.FieldRecreated += CreateNewField;
            game.CellChanged += SetCell;
            game.PlayerChanged += ShowCurrentPlayer;
            game.Win += ShowWinner;
        }

        private PictureBox[,] field;
        private FieldBuilder fieldBuilder;
        private IGameLogic game;

        private void SetCell(int x, int y, CellState cellState)
        {
            field[y, x].Image = (cellState == CellState.Cross) ?
                                    Properties.Resources.cross :
                                    Properties.Resources.zero;
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Point point = (Point)(sender as PictureBox).Tag;
            game.Turn(point.X, point.Y);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var settings = game.GetSettings();
            var settingsForm = new SettingsForm(settings);

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                game.AcceptSettings(settingsForm.settings);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            game.ResetField();
        }

        private void ShowCurrentPlayer(string playerName)
        {
            lblСurrentPlayer.Text = "Ходит: " + playerName;
        }

        private void ShowWinner(string winner)
        {
            MessageBox.Show(winner.ToString(), "Победитель");
        }

        private void CreateNewField(int fieldHeight, int fieldWidth)
        {
            pnlField.AutoSize = false;
            AutoSize = false;

            fieldBuilder.Delete(field);
            field = fieldBuilder.Create(fieldHeight, fieldWidth);
            SubscribeOnFieldClick(fieldHeight, fieldWidth);

            pnlField.AutoSize = true;
            AutoSize = true;
        }

        private void ResetField()
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    field[i, j].Image = null;
                }
            }
        }

        private void SubscribeOnFieldClick(int fieldHeight, int fieldWidth)
        {
            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    field[i, j].Click += Cell_Click;
                }
            }
        }
    }
}
