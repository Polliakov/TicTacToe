using System;

namespace Bl
{
    public class Settings
    {
        public Settings()
        {
            Player1Name = "Крестики";
            Player2Name = "Нолики";
            FieldHeight = 19;
            FieldWidth = 19;
            WinningScore = 5;
        }

        public Settings(Settings settings)
        {
            Player1Name = settings.Player1Name;
            Player2Name = settings.Player2Name;
            FieldHeight = settings.FieldHeight;
            FieldWidth = settings.FieldWidth;
            WinningScore = settings.WinningScore;
        }

        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int FieldHeight
        {
            get => fieldHeight;
            set
            {
                if (value < 1)
                    throw new ArgumentException("Property FieldHeight can't be less than 1.");
                fieldHeight = value;
            }
        }
        public int FieldWidth 
        { 
            get => fieldWidth; 
            set
            {
                if (value < 1)
                    throw new ArgumentException("Property FieldWidth can't be less than 1.");
                fieldWidth = value;
            } 
        }
        public int WinningScore { get; set; }

        private int fieldHeight;
        private int fieldWidth;
    }
}
