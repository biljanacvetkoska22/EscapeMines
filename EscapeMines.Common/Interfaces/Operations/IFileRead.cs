using EscapeMines.Common.ReadModels;

namespace EscapeMines.Common.Inerfaces.Operations
{
    public interface IFileRead
    {
        ReadSettingsModel GetGameSettings();
    }
}