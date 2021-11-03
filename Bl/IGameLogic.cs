using System;

namespace Bl
{
    public interface IGameLogic
    {
        event Action FieldReseted;
        event Action<int, int> FieldRecreated; // int FieldHeight, int FieldWidth
        event Action<int, int, CellState> CellChanged; // int X, int Y
        event Action<string> PlayerChanged;
        event Action<string> Win;

        Settings GetSettings();
        void Turn(int x, int y);
        void AcceptSettings(Settings settings);
        void ResetField();
    }
}
