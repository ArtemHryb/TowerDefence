using UnityEngine;
using Zenject;

namespace Architecture.Services.Factories.Tower.Bullet
{
    public class BulletFactory : IBulletFactory
    {
        private readonly DiContainer _container;

        public BulletFactory(DiContainer container) => 
            _container = container;
        
        public global::Tower.Bullets.Bullet CreateBullet(GameObject bullet, Vector3 at, Quaternion rotation, Transform parent) => 
            _container.InstantiatePrefabForComponent<global::Tower.Bullets.Bullet>(bullet, at, rotation, parent);
    }
}