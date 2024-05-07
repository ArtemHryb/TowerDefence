using Architecture.Services.Enemy;
using Architecture.States.Interfaces;
using SceneManagement;
using UnityEngine;

namespace Architecture.States
{
    public class LoadGameState : IState
    {
        private const string Level1 = "Level1";
        private readonly ISceneLoader _sceneLoader;
        private readonly IEnemySpawner _enemySpawner;

        public LoadGameState(ISceneLoader sceneLoader,IEnemySpawner enemySpawner)
        {
            _sceneLoader = sceneLoader;
            _enemySpawner = enemySpawner;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            _sceneLoader.Load(Level1, InitGame);
        }

        private void InitGame()
        {
            Debug.Log("Level1");
            _enemySpawner.SpawnEnemies(5);
        }
    }
}