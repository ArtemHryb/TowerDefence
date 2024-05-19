using UnityEngine;

namespace Tower.Bullets
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private BulletCheckTarget _checkTarget;
        [SerializeField] private BulletHitTarget _hitTarget;

        private void Update() =>
            Move();

        private void Move()
        {
            if (_checkTarget.Target == null)
                return;

            Vector3 direction = _checkTarget.Target.position - transform.position;
            float distanceThisFrame = _bullet.BulletSpeed * Time.deltaTime;

            if (direction.magnitude <= distanceThisFrame)
            {
                _hitTarget.Hit();
                return;
            }

            transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        }
    }
}