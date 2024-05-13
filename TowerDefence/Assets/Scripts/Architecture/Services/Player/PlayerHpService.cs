using System;
using UnityEngine;

namespace Architecture.Services.Player
{
    public class PlayerHpService : IPlayerHpService
    {
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;
        public event Action OnHpChanged;
        public int Hp { get; private set; }

        public PlayerHpService(ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
            SetHp();
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            OnHpChanged?.Invoke();
        }
        
        private void SetHp() => 
            Hp = _currentLevelSettingsProvider.GetCurrentLevelSettings().PlayerHp;
    }
}