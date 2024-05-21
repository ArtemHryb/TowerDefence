using System;

namespace Architecture.Services.Player
{
    public interface IPlayerHpService
    {
        event Action OnHpChanged;
        int Hp { get; }
        void TakeDamage(int damage);
        void SetHp();
    }
}