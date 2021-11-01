using System;

namespace Bl
{
    public interface IGameLogic
    {
        event Action<Settings> UIAdded;
        event Action<Settings> FieldReseted;
        event Action<Settings> SettingsSent;
        event Action<Settings> SettingsAccepted;
        event Action<int, int, CellState> FieldChanged;
        event Action<string> PlayerChanged;
        event Action<string> Win;
    }
}
