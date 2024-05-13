using Architecture.Services.Interfaces;
using Data;
using UI;
using UI.InGame;
using UnityEngine;
using Zenject;

namespace Architecture.Services.Factories.UI
{
    public class UIFactory : IUIFactory
    {
        public Transform UIRoot { get; private set; }

        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;

        public UIFactory(IAssetProvider assetProvider, DiContainer container)
        {
            _assetProvider = assetProvider;
            _container = container;
        }
        
        public void CreateMainMenu()
        {
            UIRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));

            MainMenu mainMenu = _assetProvider.Initialize<MainMenu>(AssetPath.MainMenu);
            _container.InstantiatePrefabForComponent<MainMenu>(mainMenu, UIRoot);
        }

        public void CreateInGameMenu()
        {
            UIRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));
            
            _container.InstantiatePrefabForComponent<SpawnEnemy>
                (_assetProvider.Initialize<SpawnEnemy>(AssetPath.SpawnEnemy),UIRoot);
            
            _container.InstantiatePrefabForComponent<DisplayPlayerHp>
                (_assetProvider.Initialize<DisplayPlayerHp>(AssetPath.DisplayPlayerHp), UIRoot);
        }

        public void CreateLoseMenu()
        {
            UIRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));
            
            _container.InstantiatePrefabForComponent<LoseMenu>
                (_assetProvider.Initialize<LoseMenu>(AssetPath.LoseMenu), UIRoot);
            Time.timeScale = 0;
        }

        private void CreateUIElement<T>(string path) where T : Object => 
            _container.InstantiatePrefab(_assetProvider.Initialize<T>(path), UIRoot);

        private Transform CreateParent(Transform parent) => 
            Object.Instantiate(parent);
    }
}