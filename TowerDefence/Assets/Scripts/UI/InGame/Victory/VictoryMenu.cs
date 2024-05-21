using Architecture.Services;
using Architecture.States;
using Architecture.States.Interfaces;
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
        [Inject]
        public void Construct(IStateMachine stateMachine, ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _stateMachine = stateMachine;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
        }
        private void Awake()
        {
            _mainMenuButton.onClick.AddListener(MainMenuButton);
            _nextLevelButton.onClick.AddListener(NextLevelButton);
        }

        private void NextLevelButton()
        {
            if (_currentLevelSettingsProvider
                    .GetCurrentLevelSettings().NextLevel == Levels.None)
                _stateMachine.Enter<LoadMainMenuState>();
            else
                _stateMachine
                    .Enter<LoadLevelState, string>(_currentLevelSettingsProvider
                        .GetCurrentLevelSettings().NextLevel.ToString());

            Time.timeScale = 1f;
        }

        private void MainMenuButton()
        {
            _stateMachine.Enter<LoadMainMenuState>();
            Time.timeScale = 1;
        }
    }
}