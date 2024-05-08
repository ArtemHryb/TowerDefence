using Data.LevelData;

namespace Architecture.Services
{
    public interface ICurrentLevelSettingsProvider
    {
        LevelData GetCurrentLevelSettings();
    }
}