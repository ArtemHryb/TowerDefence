using Architecture.Services;
using Architecture.Services.Audio;
using Architecture.States;
using Architecture.States.Interfaces;
using Audio;
using Data.LevelData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.InGame.Victory
{
    public class VictoryMenu : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _nextLevelButton;
        
        private IStateMachine _stateMachine;
        private ICurrentLevelSettingsProvider _currentLevelSettingsProvider;
        private IAudioService _audioService;
        
        [Inject]
        public void Construct(IStateMachine stateMachine, ICurrentLevelSettingsProvider currentLevelSettingsProvider,
            IAudioService audioService)
        {
            _stateMachine = stateMachine;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
            _audioService = audioService;
        }
        private void Awake()
        {
            _mainMenuButton.onClick.AddListener(MainMenuButton);
            _nextLevelButton.onClick.AddListener(NextLevelButton);
        }

        private void Start()
        {
            gameObject.transform.localScale = Vector3.zero;
            _mainMenuButton.transform.localScale = Vector3.zero;
            _nextLevelButton.transform.localScale = Vector3.zero;
            
            LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setEaseOutElastic();
            
            LeanTween.scale(_mainMenuButton.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setDelay(0.3f).setEaseOutElastic();
            
            LeanTween.scale(_nextLevelButton.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setDelay(0.4f).setEaseOutElastic();
        }

        private void NextLevelButton()
        {
            _audioService.PlaySfx(SfxType.Click);
            if (_currentLevelSettingsProvider
                    .GetCurrentLevelSettings().NextLevel == Levels.None)
                _stateMachine.Enter<LoadMainMenuState>();
            else
                _stateMachine
                    .Enter<LoadLevelState, string>(_currentLevelSettingsProvider
                        .GetCurrentLevelSettings().NextLevel.ToString());
        }

        private void MainMenuButton()
        {
            _audioService.PlaySfx(SfxType.Click);
            _stateMachine.Enter<LoadMainMenuState>();
        }
    }
}