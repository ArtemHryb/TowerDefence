using Architecture.Services.Factories.Tower.Bullet;
using Tower.Bullets;
using Tower.Tracking;
using UnityEngine;
using Zenject;

namespace Tower.Shooting
{
    public class TowerShooting : MonoBehaviour
    {
        [SerializeField] private Transform _bulletStartPoint;

        private IBulletFactory _bulletFactory;

        [SerializeField] private TowerCharacteristics _towerCharacteristics;
        [SerializeField] private EnemyTracking _enemyTracking;

        [Inject]
        public void Construct(IBulletFactory bulletFactory) => 
            _bulletFactory = bulletFactory;

        public void Shoot()
        {
            Bullet bullet = _bulletFactory
                .CreateBullet(_towerCharacteristics.Tower.Bullet.Prefab, _bulletStartPoint.position, _bulletStartPoint.rotation, transform);
            bullet.Damage = _towerCharacteristics.Damage;

            bullet.BulletCheckTarget.Seek(_enemyTracking.Target);
        }
    }
}