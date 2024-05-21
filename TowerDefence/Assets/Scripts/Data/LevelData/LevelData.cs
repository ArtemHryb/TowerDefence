﻿using System;
using Audio;
using Data.TowerSelection;
using UnityEngine;

namespace Data.LevelData
{
    [Serializable]
    public class LevelData
    {
        [Header("Level Settings")]
        public Levels CurrentLevel;
        public Levels NextLevel;
        
        public bool IsLevelOpened;
        
        public Vector3 Start;
        public Vector3 Finish;
        
        [Header("Player Settings")]
        public int PlayerHp;
        public int PlayerCoins;

        [Header("Enemy Settings")] 
        public EnemyData EnemyData;
        
        [Header("Tower selection buttons")]
        public TowerSelectionButtonsHolder TowerSelectionButtons;
        
        [Header("Wave Settings")]
        public int EnemyCount;
        public int Waves;
        public float DelayBeforeNextWave;
        
        [Header("Music")]
        public MusicType MusicType;
    }
}