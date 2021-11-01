using System;
using System.Drawing;
using System.Windows.Forms;

using Bl;

namespace UI.Forms
{
    public partial class GameForm : Form, IUserInterface
    {
        public GameForm(IGameLogic game)
        {
            InitializeComponent();
            
            fieldBuilder = new FieldBuilder(pnlField);

            game.UIAdded += Start;
            game.FieldReseted += ResetField;
            game.SettingsSent += GetNewSettings;
            game.SettingsAccepted += CreateField;
            game.FieldChanged += UpdateCell;
            game.PlayerChanged += ShowCurrentPlayer;
            game.Win += ShowWinner;
        }

        public event Action<int, int> Input;
        public event Action FieldReset;
        public event Action NededSettings;
        public event Action<Settings> SettingsRecived;

        private PictureBox[,] pictureBoxes;
        private FieldBuilder fieldBuilder;

        private void Start(Settings settings)
        {
            pictureBoxes = fieldBuilder.Create(settings.FieldHeight, settings.FieldWidth);
            SubscribeOnPbClick(settings);
        }

        private void UpdateCell(int x, int y, CellState cellState)
        {
            pictureBoxes[y, x].Image = (cellState == CellState.Cross) ?
                                       Properties.Resources.cross :
                                       Properties.Resources.zero;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Point point = (Point)(sender as PictureBox).Tag;
            Input?.Invoke(point.X, point.Y);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            NededSettings?.Invoke();
        }

        private void GetNewSettings(Settings settings)
        {
            var settingsForm = new SettingsForm(settings);

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                SettingsRecived?.Invoke(settingsForm.settings);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            FieldReset?.Invoke();
        }

        private void ShowCurrentPlayer(string playerName)
        {
            lblСurrentPlayer.Text = "Ходит: " + playerName;
        }

        private void ShowWinner(string winner)
        {
            MessageBox.Show(winner.ToString(), "Победитель");
        }

        private void CreateField(Settings settings)
        {
            pnlField.AutoSize = false;
            AutoSize = false;

            fieldBuilder.Delete(pictureBoxes);
            pictureBoxes = fieldBuilder.Create(settings.FieldHeight, settings.FieldWidth);
            SubscribeOnPbClick(settings);

            pnlField.AutoSize = true;
            AutoSize = true;
        }

        private void ResetField(Settings settings)
        {
            for (int i = 0; i < settings.FieldHeight; i++)
            {
                for (int j = 0; j < settings.FieldWidth; j++)
                {
                    pictureBoxes[i, j].Image = null;
                }
            }
        }

        private void SubscribeOnPbClick(Settings settings)
        {
            for (int i = 0; i < settings.FieldHeight; i++)
            {
                for (int j = 0; j < settings.FieldWidth; j++)
                {
                    pictureBoxes[i, j].Click += PictureBox_Click;
                }
            }
        }
    }
}
