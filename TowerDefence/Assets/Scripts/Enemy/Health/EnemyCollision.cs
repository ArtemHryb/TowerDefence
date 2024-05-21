using Architecture.Services.Audio;
using Architecture.Services.Factories.Enemy;
using Architecture.Services.Player;
using Audio;
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
        private IAudioService _audioService;
        
        [Inject]
        public void Construct(IPlayerHpService playerHpService, IEnemyFactory enemyFactory, IAudioService audioService)
        {
            _playerHpService = playerHpService;
            _enemyFactory = enemyFactory;
            _audioService = audioService;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Finish))
            {
                _audioService.PlaySfx(SfxType.PlayerGetsDamage);
                _playerHpService.TakeDamage(1);
                _enemyFactory.EnemyParent.Enemies.Remove(_enemy);
                Destroy(gameObject);
            }
        }
    }
}