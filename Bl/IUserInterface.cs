using System;

namespace Bl
{
    public interface IUserInterface
    {
        event Action<int, int> Input;
        event Action FieldReset;
        event Action NededSettings;
        event Action<Settings> SettingsRecived;
    }
}
