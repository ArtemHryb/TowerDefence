using Architecture.Services.Factories.Enemy;
using Architecture.Services.Player;
using Data;
using UnityEngine;
using Zenject;

namespace Enemy.Health
{
    public class EnemyCollision : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        
        private IPlayerHpService _playerHpService;
        private IEnemyFactory _enemyFactory;
        
        [Inject]
        public void Construct(IPlayerHpService playerHpService, IEnemyFactory enemyFactory)
        {
            _playerHpService = playerHpService;
            _enemyFactory = enemyFactory;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Finish))
            {
                _playerHpService.TakeDamage(1);
                _enemyFactory.EnemyParent.Enemies.Remove(_enemy);
                Destroy(gameObject);
            }
        }
    }
}