using System;
using UnityEngine;

namespace Data.LevelData
{
    [Serializable]
    public class LevelData
    {
        public Levels LevelId;
        
        [Header("Wave Settings")]
        public int EnemyCount;
        public int Waves;
        public float DelayBeforeNextWave;
        
        
    }
}