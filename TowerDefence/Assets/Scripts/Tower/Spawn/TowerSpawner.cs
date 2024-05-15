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
        private IAssetProvider _assetProvider;
        
        private Vector3 _worldPosition;

        [Inject]
        public void Construct(ITowerFactory towerFactory, ICoinService localCoinService,
            PlayerInput input, IUIFactory uiFactory, IAssetProvider assetProvider)
        {
            _towerFactory = towerFactory;
            _coinService = localCoinService;
            _uiFactory = uiFactory;
            _input = input;
            _assetProvider = assetProvider;
        }

        private void SpawnTower(InputAction.CallbackContext context)
        {
            if (IsPointerOverUI())
                return;
            
            _worldPosition = _spawnZoneChecker.CheckAccess().point;

            if (_worldPosition == default)
                return;

            if (_coinService.Coins > 0)
            {
                _coinService.Buy(1);
                _towerFactory.CreateTower(_assetProvider.Initialize<GameObject>(AssetPath.ArcherTower), _worldPosition, 
                    Quaternion.identity, transform);
                // Instantiate(_assetProvider.Initialize<GameObject>(AssetPath.ArcherTower)
                //     ,_worldPosition, Quaternion.identity, transform);
                Debug.Log("Tower spawned");
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