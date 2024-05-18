using Architecture.Services.Interfaces;
using Data;
using Data.LevelData;
using Tower.Selection;
using UI;
using UI.InGame;
using UnityEngine;
using Zenject;

namespace Architecture.Services.Factories.UI
{
    public class UIFactory : IUIFactory
    {
        public TowerSelection TowerSelection { get; private set; }
        public Transform UIRoot { get; private set; }
        private LevelSettings _levelsSettings;
        
        private readonly DiContainer _container;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;
        private readonly IAssetProvider _assetProvider;

        public UIFactory(IAssetProvider assetProvider, DiContainer container,ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _assetProvider = assetProvider;
            _container = container;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
            CacheVariables();
        }
        
        public void CreateMainMenu()
        {
            UIRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));

            MainMenu mainMenu = _assetProvider.Initialize<MainMenu>(AssetPath.MainMenu);
            _container.InstantiatePrefabForComponent<MainMenu>(mainMenu, UIRoot);
        }

        public void CreateInGameMenu()
        {
            CreateUIRoot();
            CreateSpawnEnemy();
            CreatePlayerHPView();
            CreatePlayerCoinsView();
            
            CreateTowerSelection(); 
            CreateTowerSelectionButtons(TowerSelection);
        }

        private void CreatePlayerCoinsView() =>
            _container.InstantiatePrefabForComponent<DisplayCoinsCount>
                (_assetProvider.Initialize<DisplayCoinsCount>(AssetPath.DisplayCoinsCount), UIRoot);

        private void CreatePlayerHPView() =>
            _container.InstantiatePrefabForComponent<DisplayPlayerHp>
                (_assetProvider.Initialize<DisplayPlayerHp>(AssetPath.DisplayPlayerHp), UIRoot);

        private void CreateSpawnEnemy() =>
            _container.InstantiatePrefabForComponent<SpawnEnemy>
                (_assetProvider.Initialize<SpawnEnemy>(AssetPath.SpawnEnemy),UIRoot);

        private void CreateUIRoot() => 
            UIRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));

        private void CreateTowerSelection() =>
           TowerSelection = _container.InstantiatePrefabForComponent<TowerSelection>
                (_assetProvider.Initialize<TowerSelection>(AssetPath.TowerSelection), UIRoot);

        private void CreateTowerSelectionButtons(TowerSelection towerSelection)
        {
            LevelData currentLevelSettings = _currentLevelSettingsProvider.GetCurrentLevelSettings();

            foreach (TowerSelectionButton button in currentLevelSettings.TowerSelectionButtons.Buttons)
            {
                TowerSelectionButtonHolder spawnedButton = _container
                    .InstantiatePrefabForComponent<TowerSelectionButtonHolder>(button.ButtonPrefab, towerSelection.transform);

                spawnedButton.Tower = button.Tower;
                towerSelection.Buttons.Add(spawnedButton);
            }
        }

        public void CreateLoseMenu()
        {
            Object.Destroy(UIRoot.gameObject);
            UIRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));
            
            _container.InstantiatePrefabForComponent<LoseMenu>
                (_assetProvider.Initialize<LoseMenu>(AssetPath.LoseMenu), UIRoot);
            Time.timeScale = 0;
        }
        
        private Transform CreateParent(Transform parent) => 
            Object.Instantiate(parent);
        
        private void CacheVariables()
        {
            _levelsSettings = _assetProvider.Initialize<LevelSettings>(AssetPath.LevelSettings);
        }
    }
}