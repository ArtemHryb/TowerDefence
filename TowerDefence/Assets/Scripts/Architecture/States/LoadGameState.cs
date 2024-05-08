using Architecture.Services;
using Architecture.Services.Enemy;
using Architecture.Services.Factories.UI;
using Architecture.Services.Interfaces;
using Architecture.States.Interfaces;
using Data;
using SceneManagement;
using UnityEngine;

namespace Architecture.States
{
    public class LoadGameState : IState
    {
        private const string Level1 = "Level1";
        
        private readonly ISceneLoader _sceneLoader;
        private readonly IEnemySpawner _enemySpawner;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;
        private readonly IUIFactory _uiFactory;
        private readonly IAssetProvider _assetProvider;

        public LoadGameState(ISceneLoader sceneLoader,IEnemySpawner enemySpawner,
            ICurrentLevelSettingsProvider currentLevelSettingsProvider, IUIFactory uiFactory, IAssetProvider assetProvider)
        {
            _sceneLoader = sceneLoader;
            _enemySpawner = enemySpawner;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
            _uiFactory = uiFactory;
            _assetProvider = assetProvider;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            _sceneLoader.Load(Level1, InitGame);
        }

        private void InitGame()
        {
            Debug.Log("Level1");
            _uiFactory.CreateInGameMenu();
            Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.Cube), 
                new Vector3(-123.9241f, 9.73f, -166f),Quaternion.identity);
            
            Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.Cube), 
                new Vector3(-123.9241f, 9.73f, -160f),Quaternion.identity);

            //_enemySpawner.SpawnEnemies(Count,Waves,Delay);

            // _enemySpawner.SpawnEnemies(_currentLevelSettingsProvider.GetCurrentLevelSettings().EnemyCount,
            //     _currentLevelSettingsProvider.GetCurrentLevelSettings().Waves,
            //     _currentLevelSettingsProvider.GetCurrentLevelSettings().DelayBeforeNextWave);
        }
    }
}