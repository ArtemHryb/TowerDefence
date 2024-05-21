using Architecture.Services.Audio;
using Architecture.States;
using Architecture.States.Interfaces;
using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI.InGame.Lose
{
    public class LoseMenu : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _restartButton;
        
        private IStateMachine _stateMachine;
        private IAudioService _audioService;
        
        [Inject]
        public void Construct(IStateMachine stateMachine, IAudioService audioService)
        {
            _stateMachine = stateMachine;
            _audioService = audioService;
        }
        private void Awake()
        {
            _mainMenuButton.onClick.AddListener(MainMenuButton);
            _restartButton.onClick.AddListener(RestartButton);
        }

        private void RestartButton()
        {
            _audioService.PlaySfx(SfxType.Click);
            _stateMachine.Enter<LoadLevelState,string>(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }

        private void MainMenuButton()
        {
            _audioService.PlaySfx(SfxType.Click);
            _stateMachine.Enter<LoadMainMenuState>();
            Time.timeScale = 1;
        }
    }
}