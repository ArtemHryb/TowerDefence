using Enemy.Main;
using UnityEngine;

namespace Architecture.Services.Factories.Enemy
{
    public interface IEnemyFactory
    {
        EnemyParent EnemyParent { get; }
        void CreateEnemyParent();
        void CreateEnemy(string path, Vector3 at, Quaternion rotation,EnemyParent parent);
    }
}