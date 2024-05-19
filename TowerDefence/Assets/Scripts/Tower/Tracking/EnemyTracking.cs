using System.Collections;
using Architecture.Services.Factories.Enemy;
using Tower.Shooting;
using UnityEngine;
using Zenject;

namespace Tower.Tracking
{
    public class EnemyTracking : MonoBehaviour
    {
        private const float UpdateTargetFrequency = 0.2f;

        [SerializeField] private TowerCharacteristics _towerCharacteristics;
        [SerializeField] private TowerShooting _towerShooting;

        private float _fireCountDown = 0f;

        private IEnemyFactory _enemyFactory;

        public Transform Target { get; private set; }

        [Inject]
        public void Construct(IEnemyFactory enemyFactory) =>
            _enemyFactory = enemyFactory;

        private void Start() =>
            StartCoroutine(UpdateTarget());

        private void Update() =>
            Track();

        private IEnumerator UpdateTarget()
        {
            while (true)
            {
                float shortestDistance = Mathf.Infinity;
                GameObject nearestEnemy = null;

                shortestDistance = GetShortestDistance(shortestDistance, ref nearestEnemy);

                if (nearestEnemy != null && shortestDistance <= _towerCharacteristics.AttackRange)
                    Target = nearestEnemy.transform;
                else
                    Target = null;
                 
                yield return new WaitForSeconds(UpdateTargetFrequency);
            }
        }

        private float GetShortestDistance(float shortestDistance, ref GameObject nearestEnemy)
        {
            if (_enemyFactory.EnemyParent == null)
                return default;

            foreach (Enemy.Enemy enemy in _enemyFactory.EnemyParent.Enemies)
            {
                if (enemy == null)
                    return default;

                float distanceToEnemy = GetDistanceToEnemy(enemy.gameObject);

                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy.gameObject;
                }
            }

            return shortestDistance;
        }

        private void Track()
        {
            if (Target == null)
                return;

            if (_fireCountDown <= 0)
            {
                _towerShooting.Shoot();
                _fireCountDown = 1f / _towerCharacteristics.FireSpeed;
            }

            _fireCountDown -= Time.deltaTime;
        }

        private float GetDistanceToEnemy(GameObject enemy) =>
            Vector3.Distance(transform.position, enemy.transform.position);
    }
}