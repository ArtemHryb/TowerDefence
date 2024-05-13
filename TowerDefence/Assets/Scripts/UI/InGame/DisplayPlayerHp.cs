using Architecture.Services.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.InGame
{
    public class DisplayPlayerHp : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _hpText;
        private IPlayerHpService _playerHpService;
        
        [Inject]
        public void Construct(IPlayerHpService playerHpService) => 
            _playerHpService = playerHpService;

        private void Start()
        {
            _playerHpService.OnHpChanged += UpdatePlayerHp;
            UpdatePlayerHp();
        }

        private void UpdatePlayerHp() => 
            _hpText.text = _playerHpService.Hp.ToString();
    }
}