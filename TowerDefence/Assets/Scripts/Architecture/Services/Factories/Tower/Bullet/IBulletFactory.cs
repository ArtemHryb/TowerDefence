using UnityEngine;

namespace Architecture.Services.Factories.Tower.Bullet
{
    public interface IBulletFactory
    {
        global::Tower.Bullets.Bullet CreateBullet(GameObject bullet, Vector3 at, Quaternion rotation, Transform parent);
    }
}