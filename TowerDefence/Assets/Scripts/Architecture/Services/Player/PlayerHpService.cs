using System;
using Architecture.States;
using Architecture.States.Interfaces;

namespace Architecture.Services.Player
{
    public class PlayerHpService : IPlayerHpService
    {
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;
        private readonly IStateMachine _stateMachine;
        public event Action OnHpChanged;
        public int Hp { get; private set; }

        public PlayerHpService(ICurrentLevelSettingsProvider currentLevelSettingsProvider,
            IStateMachine stateMachine)
        {
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
            _stateMachine = stateMachine;
            SetHp();
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            OnHpChanged?.Invoke();
            if (Hp<= 0) 
                _stateMachine.Enter<GameOverState>();
        }
        
        private void SetHp() => 
            Hp = _currentLevelSettingsProvider.GetCurrentLevelSettings().PlayerHp;
    }
}