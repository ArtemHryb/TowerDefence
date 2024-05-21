using System;
using Architecture.Services;
using Architecture.Services.Audio;
using Architecture.Services.Coin;
using Enemy.Main;
using UnityEngine;
using Zenject;

namespace Enemy.Health
{
    public class EnemyHealth : MonoBehaviour
    {
        public event Action OnHealthChanged;
        public event Action OnDied;

        public int CurrentHp { get; private set; }
        [SerializeField] private Enemy _enemy;
        [SerializeField] private EnemyMovement _enemyMovement;

        private int _maxHp;
        private int _minHp;

        private ICoinService _coinService;
        private ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        [Inject]
        public void Construct(ICoinService coinService, ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _coinService = coinService;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
        }

        private void Start() => Initialize();

        public void TakeDamage(int damage)
        {
            CurrentHp -= damage;
            OnHealthChanged?.Invoke();
            
            CheckForDeath();
        }

        private void CheckForDeath()
        {
            if (CurrentHp<=_minHp) 
                Die();
        }

        private void Die()
        {
            _coinService.GetBonus(_currentLevelSettingsProvider.GetCurrentLevelSettings().EnemyData.KillBonus);
            GetComponentInParent<EnemyParent>().Enemies.Remove(_enemy);
            _enemyMovement.enabled = false;
            Destroy(gameObject);
            OnDied?.Invoke();
        }

        private void Initialize()
        {
            _maxHp = _currentLevelSettingsProvider.GetCurrentLevelSettings().EnemyData.MaxHp;
            CurrentHp = _maxHp;
            _minHp = 0;
        }
    }
}