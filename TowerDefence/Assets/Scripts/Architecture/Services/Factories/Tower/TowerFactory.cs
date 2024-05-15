using UnityEngine;
using Zenject;

namespace Architecture.Services.Factories.Tower
{
    public class TowerFactory : ITowerFactory
    {
        private readonly DiContainer _container;

        public TowerFactory(DiContainer container)
        {
            _container = container;
        }

        public GameObject CreateTower(GameObject prefab, Vector3 at, Quaternion rotation, Transform parent) => 
            _container.InstantiatePrefab(prefab, at, rotation, parent);
        
        public GameObject CreateTowerGhost(GameObject prefab) => 
            Object.Instantiate(prefab);
    }
}