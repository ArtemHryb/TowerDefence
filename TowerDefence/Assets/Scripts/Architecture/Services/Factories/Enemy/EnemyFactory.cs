using Architecture.Services.Interfaces;
using Data;
using Enemy;
using UnityEngine;
using Zenject;

namespace Architecture.Services.Factories.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        public Transform EnemyParent { get; private set; }
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _container;

        public EnemyFactory(IAssetProvider assetProvider, DiContainer container)
        {
            _assetProvider = assetProvider;
            _container = container;
        }
        public void CreateEnemyParent() =>
            EnemyParent = Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.EnemyParent));
        public void CreateEnemy(string path, Vector3 at, Quaternion rotation,Transform parent) => 
            _container.InstantiatePrefab(_assetProvider.Initialize<GameObject>(path), at, rotation, EnemyParent);
    }
}