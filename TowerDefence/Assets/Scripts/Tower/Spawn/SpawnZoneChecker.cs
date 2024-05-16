using UnityEngine;
using UnityEngine.InputSystem;

namespace Tower.Spawn
{
    public class SpawnZoneChecker
    {
        private readonly LayerMask _spawnZoneLayer = 1<<6;
        private readonly LayerMask _towerLayer = 1<<7;

        private Ray _ray;
        private readonly int _maxRaycastDistance = 200;

        private Vector2 _mousePosition;

        public Camera Camera { get; set; }

        public RaycastHit CheckAccess()
        {
            GetMousePosition();

            if (Physics.Raycast(_ray, out RaycastHit hit, _maxRaycastDistance, _spawnZoneLayer) &&
                !Physics.Raycast(_ray, _maxRaycastDistance, _towerLayer))
                return hit;
            else
                return default;
        }

        private void GetMousePosition()
        {
            _mousePosition = Mouse.current.position.ReadValue();
            _ray = Camera.ScreenPointToRay(_mousePosition);
        }
    }
}