using Data.LevelData;
using UnityEngine.SceneManagement;

namespace Architecture.Services
{
    public class CurrentLevelSettingsProvider : ICurrentLevelSettingsProvider
    {
        private readonly LevelSettings _levelSettings;

        public CurrentLevelSettingsProvider(LevelSettings levelSettings)
        {
            _levelSettings = levelSettings;
        }
        
        public LevelData GetCurrentLevelSettings()
        {
            LevelData levelData = new LevelData();
            
            foreach (LevelData level in _levelSettings.Levels)
            {
                if (level.LevelId.ToString() == SceneManager.GetActiveScene().name)
                {
                    levelData = level;
                    return levelData;
                }
            }

            return levelData;
        }
    }
}