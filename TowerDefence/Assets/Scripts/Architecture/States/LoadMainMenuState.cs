using Architecture.Services.Audio;
using Architecture.Services.Factories.UI;
using Architecture.States.Interfaces;
using Audio;
using SceneManagement;

namespace Architecture.States
{
    public class LoadMainMenuState : IState
    {
        private const string Boot = "Boot";
        
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IAudioService _audioService;

        public LoadMainMenuState(ISceneLoader sceneLoader,IUIFactory uiFactory,IAudioService audioService)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _audioService = audioService;
        }
        public void Exit()
        {
            _audioService.StopMusic();
        }

        public void Enter()
        {
            _sceneLoader.Load(Boot,InitMainMenu);
            _audioService.PlayMusic(MusicType.MainMenu);
        }

        private void InitMainMenu()
        {
            _uiFactory.CreateMainMenu();
        }
    }
}