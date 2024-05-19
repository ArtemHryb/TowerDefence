using Enemy.Health;
using UnityEngine;

namespace Tower.Bullets
{
    public class BulletHitTarget : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private BulletCheckTarget _checkTarget;
        [SerializeField] private BulletDestroyEffect _destroyEffect;

        public void Hit()
        {
            Destroy(gameObject);
            _destroyEffect.SpawnEffect();
            _checkTarget.Target.GetComponent<EnemyHealth>().TakeDamage(_bullet.Damage);
        }
    }
}