using System;
using System.Windows.Forms;

using UI.Forms;
using Bl;

namespace TicTacToe
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var game = new Game();
            var gameForm = new GameForm(game);

            Application.Run(gameForm);
        }
    }
}
