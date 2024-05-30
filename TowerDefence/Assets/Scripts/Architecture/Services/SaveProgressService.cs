using System;
using Architecture.Services.Interfaces;
using Data;
using Data.LevelData;
using UnityEngine;

namespace Architecture.Services
{
    public class SaveProgressService : ISaveProgressService
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        public SaveProgressService(IAssetProvider assetProvider, ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _assetProvider = assetProvider;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
        }

        public void SaveLevelProgress()
        {
            LevelSettings levels = _assetProvider.Initialize<LevelSettings>(AssetPath.LevelSettings);

            for (int i = 0; i < levels.Levels.Count - 1; i++)
            {
                if (levels.Levels[i].CurrentLevel == _currentLevelSettingsProvider.GetCurrentLevelSettings().CurrentLevel)
                {
                    levels.Levels[i + 1].IsLevelOpened = true;
                    SaveLevelStatus(levels.Levels[i + 1].CurrentLevel, levels.Levels[i + 1].IsLevelOpened);
                }
            }
        }

        public void LoadLevelProgress()
        {
            LevelSettings levels = _assetProvider.Initialize<LevelSettings>(AssetPath.LevelSettings);

            for (int i = 0; i < levels.Levels.Count; i++)
            {
                if (i == 0)
                    levels.Levels[i].IsLevelOpened = true;
                else
                    levels.Levels[i].IsLevelOpened = IsLevelOpened(levels.Levels[i].CurrentLevel);
            }
        }

        private void SaveLevelStatus(Enum levelId, bool isLevelOpened)
        {
            PlayerPrefs.SetInt(levelId.ToString(), isLevelOpened ? 1 : 0);
            PlayerPrefs.Save();
        }

        private bool IsLevelOpened(Enum levelId) => 
            PlayerPrefs.GetInt(levelId.ToString(), 0) == 1;
    }
}