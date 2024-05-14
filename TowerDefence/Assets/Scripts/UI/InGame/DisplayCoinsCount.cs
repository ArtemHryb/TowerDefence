using Architecture.Services.Coin;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.InGame
{
    public class DisplayCoinsCount : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        private ICoinService _coinService;
        
        [Inject]
        public void Construct(ICoinService coinService) => 
            _coinService = coinService;

        private void Start()
        {
            _coinService.OnCoinsChanged += UpdateCoins;
            UpdateCoins();
        }

        private void UpdateCoins() => 
            _coinsText.text = _coinService.Coins.ToString();
    }
}