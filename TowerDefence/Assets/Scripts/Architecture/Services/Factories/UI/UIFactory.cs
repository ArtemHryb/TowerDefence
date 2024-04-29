using Architecture.Services.Interfaces;
using Data;
using UI;
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
        }

        private void CreateUIElement<T>(string path) where T : Object => 
            _container.InstantiatePrefab(_assetProvider.Initialize<T>(path), UIRoot);

        private Transform CreateParent(Transform parent) => 
            Object.Instantiate(parent);
    }
}