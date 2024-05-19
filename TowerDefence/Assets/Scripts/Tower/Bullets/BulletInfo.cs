using System;
using UnityEngine;

namespace Tower.Bullets
{
    [Serializable]
    public class BulletInfo
    {
        public GameObject Prefab;
        public int Damage;
        public int Speed;
    }
}