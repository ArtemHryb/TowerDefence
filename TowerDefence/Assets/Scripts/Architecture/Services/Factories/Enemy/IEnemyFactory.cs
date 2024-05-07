using UnityEngine;

namespace Architecture.Services.Factories.Enemy
{
    public interface IEnemyFactory
    {
        Transform EnemyParent { get; }
        void CreateEnemyParent();
        void CreateEnemy(string path, Vector3 at, Quaternion rotation,Transform parent);
    }
}