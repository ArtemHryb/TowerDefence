using Architecture.Services.Interfaces;
using Data;
using Tower.Spawn;
using UnityEngine;
using Zenject;

namespace Architecture.Services.Factories.Components
{
    public class ComponentFactory : IComponentFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;

        public ComponentFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public void InstantiateComponents()
        {
            GameObject parent = Object.Instantiate(_assetProvider.Initialize<GameObject>(AssetPath.MainLevelComponentsParent));

            CreateComponent<TowerSpawner>(AssetPath.TowerSpawner, parent.transform);
        }

        private void CreateComponent<T>(string componentPath, Transform parent) where T : MonoBehaviour =>
            _container.InstantiatePrefab(_assetProvider.Initialize<T>(componentPath), parent);
    }
}