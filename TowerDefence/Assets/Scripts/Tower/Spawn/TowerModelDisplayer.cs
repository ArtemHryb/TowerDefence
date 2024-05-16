using System.Collections.Generic;
using System.Linq;
using Architecture.Services.Factories.Tower;
using Architecture.Services.Factories.UI;
using ModestTree;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Tower.Spawn
{
    public class TowerModelDisplayer : MonoBehaviour
    {
        private readonly Dictionary<TowerType, GameObject> _createdModel = new();

        private IUIFactory _uiFactory;
        private ITowerFactory _towerFactory;

        private Ray _ray;

        private Vector2 _screenPosition;
        private Vector3 _worldPosition;

        private bool _isModelCreated = false;

        private Camera _camera;

        [Inject]
        public void Construct(IUIFactory uiFactory, ITowerFactory towerFactory)
        {
            _uiFactory = uiFactory;
            _towerFactory = towerFactory;
        }

        private void Awake() =>
            _camera = Camera.main;

        private void LateUpdate()
        {
            if (_uiFactory.TowerSelection.SelectedButton != null) 
                GetWorldPosition(); 

            Show();
        }
        
        private void Show()
        {
            if (_uiFactory.TowerSelection.SelectedButton != null)
            {
                if (_isModelCreated == false)
                {
                    GameObject ghost = _towerFactory.CreateTowerGhost(_uiFactory.TowerSelection.SelectedButton.Tower.TowerGhostPrefab);
                    AddToSpawned(ghost);
                    _isModelCreated = true;
                }
                else
                    MoveModel();

                if (_createdModel.First().Key != _uiFactory.TowerSelection.SelectedButton.Tower.TowerType)
                    ChangeModel();
            }
            else
            {
                if (!_createdModel.IsEmpty())
                    DestroyModel();
            }
        }

        private void DestroyModel()
        {
            Destroy(_createdModel.First().Value);
            Cleanup();
            _isModelCreated = false;
        }

        private void ChangeModel()
        {
            Destroy(_createdModel.First().Value);
            Cleanup();
            GameObject ghost = _towerFactory.CreateTowerGhost(_uiFactory.TowerSelection.SelectedButton.Tower.TowerGhostPrefab);
            _createdModel.Add(_uiFactory.TowerSelection.SelectedButton.Tower.TowerType, ghost);
        }

        private void MoveModel()
        {
            GameObject model = _createdModel.First().Value;
            model.gameObject.transform.position = _worldPosition;
        }

        private void AddToSpawned(GameObject model)
        {
            Cleanup();
            _createdModel.Add(_uiFactory.TowerSelection.SelectedButton.Tower.TowerType, model);
            _isModelCreated = true;
        }

        private void GetWorldPosition()
        {
            _screenPosition = GetScreenPosition();
            _ray = _camera.ScreenPointToRay(_screenPosition);

            if (Physics.Raycast(_ray, out RaycastHit hit))
                _worldPosition = hit.point;
        }

        private Vector2 GetScreenPosition() =>
            Mouse.current.position.ReadValue();

        private void Cleanup() =>
            _createdModel.Clear();
    }
}