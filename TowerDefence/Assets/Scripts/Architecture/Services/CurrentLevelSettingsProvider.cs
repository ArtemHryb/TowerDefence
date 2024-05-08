using Data.LevelData;
using UnityEngine.SceneManagement;

namespace Architecture.Services
{
    public class CurrentLevelSettingsProvider : ICurrentLevelSettingsProvider
    {
        private readonly LevelDataHolder _levelDataHolder;

        public CurrentLevelSettingsProvider(LevelDataHolder levelDataHolder)
        {
            _levelDataHolder = levelDataHolder;
        }
        
        public LevelData GetCurrentLevelSettings()
        {
            LevelData levelData = new LevelData();
            
            foreach (LevelData level in _levelDataHolder.Levels)
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