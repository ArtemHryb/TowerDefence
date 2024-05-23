using Architecture.Services.Interfaces;
using Data;
using Data.LevelData;
using Data.Windows;
using Tower.Selection;
using UI.InGame;
using UI.InGame.Lose;
using UI.InGame.Victory;
using UI.MainMenu;
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

        public UIFactory(IAssetProvider assetProvider, DiContainer container
            ,ICurrentLevelSettingsProvider currentLevelSettingsProvider)
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
            CreatePlayerHPView();
            CreatePlayerCoinsView();
            CreateSpawnEnemy();

            CreateTowerSelection(); 
            CreateTowerSelectionButtons(TowerSelection);
        }

        private void CreatePlayerHPView()
        {
           DisplayPlayerHp playerHp =  _container.InstantiatePrefabForComponent<DisplayPlayerHp>
                (_assetProvider.Initialize<DisplayPlayerHp>(AssetPath.DisplayPlayerHp), UIRoot);
           
           playerHp.transform.localScale = Vector3.zero;
           
           LeanTween.scale(playerHp.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
               .setDelay(0.1f).setEaseOutElastic();
        }

        private void CreatePlayerCoinsView()
        {
            DisplayCoinsCount coins = _container.InstantiatePrefabForComponent<DisplayCoinsCount>
                (_assetProvider.Initialize<DisplayCoinsCount>(AssetPath.DisplayCoinsCount), UIRoot);
            
            coins.transform.localScale = Vector3.zero;
            
            LeanTween.scale(coins.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setDelay(0.2f).setEaseOutElastic();
        }

        private void CreateSpawnEnemy()
        {
            SpawnEnemy spawnEnemy = _container.InstantiatePrefabForComponent<SpawnEnemy>
                (_assetProvider.Initialize<SpawnEnemy>(AssetPath.SpawnEnemy), UIRoot);
            
            spawnEnemy.transform.localScale = Vector3.zero;
            
            LeanTween.scale(spawnEnemy.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setDelay(0.3f).setEaseOutElastic();
        }

        private void CreateUIRoot() => 
            UIRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));

        private void CreateTowerSelection()
        {
            TowerSelection = _container.InstantiatePrefabForComponent<TowerSelection>
                (_assetProvider.Initialize<TowerSelection>(AssetPath.TowerSelection), UIRoot);
            
            TowerSelection.transform.localScale = Vector3.zero;
            
            LeanTween.scale(TowerSelection.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setDelay(0.4f).setEaseOutElastic();
        }

        private void CreateTowerSelectionButtons(TowerSelection towerSelection)
        {
            LevelData currentLevelSettings = _currentLevelSettingsProvider.GetCurrentLevelSettings();

            foreach (TowerSelectionButton button in currentLevelSettings.TowerSelectionButtons.Buttons)
            {
                TowerSelectionButtonHolder spawnedButton = _container
                    .InstantiatePrefabForComponent<TowerSelectionButtonHolder>(button.ButtonPrefab, towerSelection.transform);

                spawnedButton.Tower = button.Tower;
                towerSelection.Buttons.Add(spawnedButton);
                
                spawnedButton.transform.localScale = Vector3.zero;
                
                LeanTween.scale(spawnedButton.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                    .setDelay(0.5f).setEaseOutElastic();
            }
        }

        public void CreateLoseMenu()
        {
            Object.Destroy(UIRoot.gameObject);
            UIRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));
            
            _container.InstantiatePrefabForComponent<LoseMenu>
                (_assetProvider.Initialize<LoseMenu>(AssetPath.LoseMenu), UIRoot);
        }

        public void CreateVictoryMenu()
        {
            Object.Destroy(UIRoot.gameObject);
            UIRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));
            
            _container.InstantiatePrefabForComponent<VictoryMenu>
                (_assetProvider.Initialize<VictoryMenu>(AssetPath.VictoryMenu), UIRoot);
        }

        public void CreateLevelSelection()
        {
            UIRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));
            
            LevelSelectionWindow window = _container.InstantiatePrefabForComponent<LevelSelectionWindow>
                (_assetProvider.Initialize<LevelSelectionWindow>(AssetPath.LevelSelectionWindow), UIRoot);

            window.transform.localScale = Vector3.zero;
            
            LeanTween.scale(window.gameObject, new Vector3(1f, 1f, 1f), 1.5f).setEaseOutElastic();
            
            CreateLevelTransferButtons(window);
        }

        private void CreateLevelTransferButtons(LevelSelectionWindow window)
        {
            foreach (LevelTransferButtonMarker marker in window.Markers)
            {
                foreach (LevelData level in _levelsSettings.Levels)
                {
                    if (level.CurrentLevel == marker.Id)
                        marker.IsOpened = level.IsLevelOpened;
                }

                if (marker.IsOpened)
                {
                    LevelTransferButton button = _container.InstantiatePrefabForComponent<LevelTransferButton>(marker.OpenedButton,
                        Vector3.zero, Quaternion.identity, marker.transform);
                    button.LevelId = marker.Id;

                    LeanTween.scale(button.gameObject, new Vector3(1f, 1f, 1f), 1.5f).setEaseOutElastic()
                        .setDelay(0.5f);
                }
                else 
                { 
                  GameObject closeButton =  _container.InstantiatePrefab(marker.ClosedButton,
                        Vector3.zero, Quaternion.identity, marker.transform);
                    
                  LeanTween.scale(closeButton.gameObject, new Vector3(1f, 1f, 1f), 1.5f).setEaseOutElastic()
                      .setDelay(0.6f);
                }
            }
        }

        private Transform CreateParent(Transform parent) => 
            Object.Instantiate(parent);
        
        private void CacheVariables() => 
            _levelsSettings = _assetProvider.Initialize<LevelSettings>(AssetPath.LevelSettings);
    }
}