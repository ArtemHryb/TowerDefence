using Architecture.Services.Player;
using Data;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyCollision : MonoBehaviour
    {
        private IPlayerHpService _playerHpService;
        
        [Inject]
        public void Construct(IPlayerHpService playerHpService) => 
            _playerHpService = playerHpService;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Finish))
            {
                _playerHpService.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}