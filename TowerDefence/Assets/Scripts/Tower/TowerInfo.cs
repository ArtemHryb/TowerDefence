using System;
using Tower.Bullets;
using UnityEngine;

namespace Tower
{
    [Serializable]
    public class TowerInfo
    {
        public TowerType TowerType;

        public GameObject TowerPrefab;
        public GameObject TowerGhostPrefab;
        public int Price;
        public int AttackRange;
        public float FireSpeed;

        public BulletInfo Bullet;
    }
}