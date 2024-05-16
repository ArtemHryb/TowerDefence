using Architecture.Services.Coin;
using Architecture.Services.Factories.Tower;
using Architecture.Services.Factories.UI;
using Architecture.Services.Interfaces;
using Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

namespace Tower.Spawn
{
    public class TowerSpawner : MonoBehaviour 
    {
        private readonly SpawnZoneChecker _spawnZoneChecker = new();
        
        private ITowerFactory _towerFactory;
        private ICoinService _coinService;
        private IUIFactory _uiFactory;
        private PlayerInput _input;
        
        private Vector3 _worldPosition;

        [Inject]
        public void Construct(ITowerFactory towerFactory, ICoinService localCoinService,
            PlayerInput input, IUIFactory uiFactory)
        {
            _towerFactory = towerFactory;
            _coinService = localCoinService;
            _uiFactory = uiFactory;
            _input = input;
        }

        private void SpawnTower(InputAction.CallbackContext context)
        {
            if (IsPointerOverUI())
                return;
            
            _worldPosition = _spawnZoneChecker.CheckAccess().point;

            if (_worldPosition == default)
                return;

            if (_coinService.Coins >= _uiFactory.TowerSelection.SelectedButton?.Tower.Price)
            {
                _coinService.Buy(_uiFactory.TowerSelection.SelectedButton.Tower.Price);
                _towerFactory.CreateTower(_uiFactory.TowerSelection.SelectedButton.Tower.TowerPrefab, _worldPosition, 
                    Quaternion.identity, transform);
            }
            else
            {
                Debug.Log("Not enough money");
            }
        }

        private void Awake() => _spawnZoneChecker.Camera = Camera.main;
        private void OnEnable() => _input.Player.CreateTower.performed += SpawnTower; 
        private void OnDisable() => _input.Player.CreateTower.performed -= SpawnTower;
        
        private bool IsPointerOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return true;
            else
                return false;
        }
    }
}