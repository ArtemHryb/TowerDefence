using Architecture.Services.Interfaces;
using Data;
using Enemy;
using UnityEngine;

namespace Architecture.Services.Factories.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        public Transform EnemyParent { get; private set; }
        private readonly IAssetProvider _assetProvider;


        public EnemyFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        public void CreateEnemyParent() =>
            EnemyParent = Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.EnemyParent));
        public void CreateEnemy(string path, Vector3 at, Quaternion rotation,Transform parent)
        {
            Object.Instantiate(_assetProvider.Initialize<EnemyStats>(path), at, rotation, EnemyParent);
        }
    }
}