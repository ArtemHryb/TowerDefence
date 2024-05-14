using System;

namespace Architecture.Services.Coin
{
    public interface ICoinService
    {
        event Action OnCoinsChanged;
        int Coins { get; }
        void Buy(int price);
        void GetBonus(int bonus);
        void SetCoins();
    }
}