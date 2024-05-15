using Architecture.Services.Factories.Components;
using Architecture.Services.Factories.UI;
using Architecture.States.Interfaces;
using Data;
using SceneManagement;

namespace Architecture.States
{
    public class LoadGameState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IComponentFactory _componentFactory;

        public LoadGameState(ISceneLoader sceneLoader, IUIFactory uiFactory, 
            IComponentFactory componentFactory)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _componentFactory = componentFactory;
        }
        public void Exit()
        {
        }

        public void Enter() => 
            _sceneLoader.Load(Tags.Level1, InitGame);

        private void InitGame()
        {
            _uiFactory.CreateInGameMenu();
            _componentFactory.InstantiateComponents();
        }
    }
}