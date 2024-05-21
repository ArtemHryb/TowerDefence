using Architecture.States.Interfaces;
using SceneManagement;

namespace Architecture.States
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStateMachine _stateMachine;

        public LoadLevelState(IStateMachine stateMachine,ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        public void Exit()
        {
        }

        public void Enter(string nextScene)
        {
            _sceneLoader.Load(nextScene, OnLoaded);
        }

        private void OnLoaded() =>
            _stateMachine.Enter<InitializeGameWorldState>();
    }
}