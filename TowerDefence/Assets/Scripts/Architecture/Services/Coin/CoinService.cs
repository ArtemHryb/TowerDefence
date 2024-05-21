using System;

namespace Architecture.Services.Coin
{
    public class CoinService : ICoinService
    {
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;
        
        public event Action OnCoinsChanged;
        public int Coins { get; private set; }

        public CoinService(ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
        }

        public void Buy(int price)
        {
            Coins -= price;
            OnCoinsChanged?.Invoke();
        }
        
        public void GetBonus(int bonus)
        {
            Coins += bonus;
            OnCoinsChanged?.Invoke();
        }

        public void SetCoins() => 
            Coins = _currentLevelSettingsProvider.GetCurrentLevelSettings().PlayerCoins;
    }
}