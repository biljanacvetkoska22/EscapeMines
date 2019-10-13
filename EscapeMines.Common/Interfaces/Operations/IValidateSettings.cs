using EscapeMines.Common.MinesGameModels;

namespace EscapeMines.Common.Interfaces.Operations
{
    public interface IValidateSettings
    {
        bool ValidateInputSettings();
        bool ValidatePointRangeSettings(Point point);
        bool ValidateStartPointSettings(Point startPoint, Point size);
    }
}