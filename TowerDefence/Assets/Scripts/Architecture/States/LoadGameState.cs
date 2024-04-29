using Architecture.States.Interfaces;
using SceneManagement;
using UnityEngine;

namespace Architecture.States
{
    public class LoadGameState : IState
    {
        private const string Level1 = "Level1";
        private readonly ISceneLoader _sceneLoader;

        public LoadGameState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
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
        }
    }
}