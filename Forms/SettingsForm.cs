using System;
using System.Windows.Forms;

using Bl;

namespace UI.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(Settings settings)
        {
            InitializeComponent();

            this.settings = new Settings
            {
                Player1Name = settings.Player1Name,
                Player2Name = settings.Player2Name,
                FieldHeight = settings.FieldHeight,
                FieldWidth = settings.FieldWidth,
                WinningScore = settings.WinningScore
            };

            tbPlayer1Name.Text = settings.Player1Name;
            tbPlayer2Name.Text = settings.Player2Name;
            tbFieldHeight.Text = settings.FieldHeight.ToString();
            tbFieldWidth.Text = settings.FieldWidth.ToString();
            tbWinningScore.Text = settings.WinningScore.ToString();
        }

        public Settings settings { get; private set; }

        private const int MAX_FIELD_HEIGHT = 50;
        private const int MAX_FIELD_WIDTH = 50;
        private const int MAX_WINNING_SCORE = 50;
        private const int MIN_FIELD_SIZE = 3;     

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (settings.WinningScore > settings.FieldHeight &&
                settings.WinningScore > settings.FieldWidth)
            {
                MessageBox.Show("Размер победного ряда должен быть меньше высоты или ширины поля.",
                                "Некорректные настройки");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void TbFieldHeight_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(tbFieldHeight.Text, out int value))
            {
                tbFieldHeight.Text = settings.FieldHeight.ToString();
                return;
            }

            if (value < MIN_FIELD_SIZE) value = MIN_FIELD_SIZE;         
            if (value > MAX_FIELD_HEIGHT) value = MAX_FIELD_HEIGHT;

            settings.FieldHeight = value;
            tbFieldHeight.Text = value.ToString();
        }

        private void TbFieldWidth_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(tbFieldWidth.Text, out int value))
            {
                tbFieldWidth.Text = settings.FieldWidth.ToString();
                return;
            }

            if (value < MIN_FIELD_SIZE) value = MIN_FIELD_SIZE;
            if (value > MAX_FIELD_WIDTH) value = MAX_FIELD_WIDTH;

            settings.FieldWidth = value;
            tbFieldWidth.Text = value.ToString();
        }

        private void TbWinningScore_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(tbWinningScore.Text, out int value))
            {
                tbWinningScore.Text = settings.WinningScore.ToString();
                return;
            }

            if (value < MIN_FIELD_SIZE) value = MIN_FIELD_SIZE;
            if (value > MAX_WINNING_SCORE) value = MAX_WINNING_SCORE;

            settings.WinningScore = value;
            tbWinningScore.Text = value.ToString();
        }

        private void TbPlayer1Name_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPlayer1Name.Text))
            {
                tbPlayer1Name.Text = settings.Player1Name;
                return;
            }

            settings.Player1Name = tbPlayer1Name.Text;
        }

        private void TbPlayer2Name_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPlayer2Name.Text))
            {
                tbPlayer2Name.Text = settings.Player2Name;
                return;
            }

            settings.Player2Name = tbPlayer2Name.Text;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
