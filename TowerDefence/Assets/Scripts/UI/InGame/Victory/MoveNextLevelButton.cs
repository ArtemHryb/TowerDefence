using Architecture.Services;
using Architecture.States;
using Architecture.States.Interfaces;
using Data.LevelData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.InGame.Victory
{
    public class MoveNextLevelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IStateMachine _stateMachine;
        private ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        [Inject]
        public void Construct(IStateMachine stateMachine, ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _stateMachine = stateMachine;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
        }

        private void Awake() =>
            _button.onClick.AddListener(EnterNextLevel);

        private void EnterNextLevel()
        {
            if (_currentLevelSettingsProvider
                    .GetCurrentLevelSettings().NextLevel == Levels.None)
                _stateMachine.Enter<LoadMainMenuState>();
            // else
            //     _stateMachine
            //         .Enter<LoadGameState, string>(_currentLevelSettingsProvider
            //             .GetCurrentLevelSettings().NextLevel.ToString());
        }
    }
}