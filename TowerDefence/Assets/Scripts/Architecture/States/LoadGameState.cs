using Architecture.Services.Factories.UI;
using Architecture.States.Interfaces;
using SceneManagement;
using UnityEngine;

namespace Architecture.States
{
    public class LoadGameState : IState
    {
        private const string Level1 = "Level1";
        
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public LoadGameState(ISceneLoader sceneLoader, IUIFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }
        public void Exit()
        {
        }

        public void Enter() => 
            _sceneLoader.Load(Level1, InitGame);

        private void InitGame()
        {
            Debug.Log("Level1");
            _uiFactory.CreateInGameMenu();
        }
    }
}