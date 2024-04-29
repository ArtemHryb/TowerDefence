using Architecture.Services.Factories.UI;
using Architecture.States.Interfaces;
using SceneManagement;
using UnityEngine;

namespace Architecture.States
{
    public class LoadMainMenuState : IState
    {
        private const string Boot = "Boot";
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public LoadMainMenuState(ISceneLoader sceneLoader,IUIFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            _sceneLoader.Load(Boot,InitMainMenu);
        }

        private void InitMainMenu()
        {
            _uiFactory.CreateMainMenu();
        }
    }
}