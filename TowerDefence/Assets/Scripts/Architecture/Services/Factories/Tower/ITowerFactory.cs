using UnityEngine;

namespace Architecture.Services.Factories.Tower
{
    public interface ITowerFactory
    {
        GameObject CreateTower(GameObject prefab, Vector3 at, Quaternion rotation, Transform parent);
        GameObject CreateTowerGhost(GameObject prefab);
    }
}