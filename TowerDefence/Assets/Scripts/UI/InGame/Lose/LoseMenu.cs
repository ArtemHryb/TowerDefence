using Architecture.States;
using Architecture.States.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.InGame.Lose
{
    public class LoseMenu : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _restartButton;
        private IStateMachine _stateMachine;
        
        [Inject]
        public void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        private void Awake()
        {
            _mainMenuButton.onClick.AddListener(MainMenuButton);
            _restartButton.onClick.AddListener(RestartButton);
        }

        private void RestartButton()
        {
            _stateMachine.Enter<LoadGameState>();
            Time.timeScale = 1;
        }

        private void MainMenuButton()
        {
            _stateMachine.Enter<LoadMainMenuState>();
            Time.timeScale = 1;
        }
    }
}