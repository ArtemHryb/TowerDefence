using Architecture.States;
using Architecture.States.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        private IStateMachine _stateMachine;
        
        [Header("Buttons")] 
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        
        [Inject]
        public void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        private void Awake()
        {
            _playButton.onClick.AddListener(Play);
            _exitButton.onClick.AddListener(Exit);
        }

        private void Play()
        {
            _stateMachine.Enter<LoadGameState>();
        }

        private void Exit() => 
            Application.Quit();
    }
}