﻿using System.Collections;
using Architecture.Services.Factories.Enemy;
using Architecture.States.Interfaces;
using Data;
using UnityEngine;

namespace Architecture.Services.Enemy
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly ICoroutineRunner _coroutineRunner;

        public EnemySpawner(IEnemyFactory enemyFactory,ICoroutineRunner coroutineRunner)
        {
            _enemyFactory = enemyFactory;
            _coroutineRunner = coroutineRunner;
        }
        public void SpawnEnemies(int count)
        {
            _enemyFactory.CreateEnemyParent();
            _coroutineRunner.StartCoroutine(SpawnEnemy(count));
        }

        public void SpawnEnemies(int count, int waves,float delay)
        {
            _enemyFactory.CreateEnemyParent();
            _coroutineRunner.StartCoroutine(SpawnWave(count, waves,delay));
        }

        private IEnumerator SpawnWave(int enemyCount,int waves,float delay)
        {
            delay += enemyCount;
            
            while (waves > 0)
            {
                _coroutineRunner.StartCoroutine(SpawnEnemy(enemyCount));
                waves--;
                yield return new WaitForSeconds(delay);
            }
        }

        private IEnumerator SpawnEnemy(int enemyCount)
        { 
            while (enemyCount > 0) 
            { 
                _enemyFactory.CreateEnemy(AssetPath.Solider, new Vector3(-151.94f, 0, -183.77f),
                    Quaternion.identity, null); 
                enemyCount--; 
                yield return new WaitForSeconds(1f);
            }
        }
    }
}