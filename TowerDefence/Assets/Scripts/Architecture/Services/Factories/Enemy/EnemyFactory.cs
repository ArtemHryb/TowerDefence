using Architecture.Services.Interfaces;
using Data;
using Enemy.Main;
using UnityEngine;
using Zenject;

namespace Architecture.Services.Factories.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        public EnemyParent EnemyParent { get; private set; }
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _container;

        public EnemyFactory(IAssetProvider assetProvider, DiContainer container)
        {
            _assetProvider = assetProvider;
            _container = container;
        }
        public void CreateEnemyParent() =>
            EnemyParent = Object.Instantiate(_assetProvider.Initialize<EnemyParent>(AssetPath.EnemyParent));
        public void CreateEnemy(string path, Vector3 at, Quaternion rotation,EnemyParent parent)
        {
           global::Enemy.Enemy enemy = _container.InstantiatePrefabForComponent<global::Enemy.Enemy>(
                _assetProvider.Initialize<global::Enemy.Enemy>(path), at, rotation, parent.transform);

           parent.Enemies.Add(enemy);
        }
    }
}