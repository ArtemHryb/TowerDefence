using Architecture.Services.Audio;
using Architecture.Services.Factories.UI;
using Architecture.Services.Interfaces;
using Architecture.States.Interfaces;
using Audio;
using SceneManagement;
using UI.Loading;
using UnityEngine;

namespace Architecture.States
{
    public class LoadMainMenuState : IState
    {
        private const string Boot = "Boot";
        
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IAudioService _audioService;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly ISaveProgressService _saveProgressService;

        public LoadMainMenuState(ISceneLoader sceneLoader,IUIFactory uiFactory,IAudioService audioService
        ,LoadingCurtain loadingCurtain, ISaveProgressService saveProgressService)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _audioService = audioService;
            _loadingCurtain = loadingCurtain;
            _saveProgressService = saveProgressService;
        }
        public void Exit()
        {
            _audioService.StopMusic();
        }

        public void Enter()
        {
            _saveProgressService.LoadLevelProgress();
            _loadingCurtain.Show();
            _loadingCurtain.Hide();
            _sceneLoader.Load(Boot,InitMainMenu);
            _audioService.PlayMusic(MusicType.MainMenu);
        }

        private void InitMainMenu()
        {
            _uiFactory.CreateMainMenu();
        }
    }
}