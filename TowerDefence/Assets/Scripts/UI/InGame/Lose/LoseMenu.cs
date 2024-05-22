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

        private void Start()
        {
            gameObject.transform.localScale = Vector3.zero;
            _mainMenuButton.transform.localScale = Vector3.zero;
            _restartButton.transform.localScale = Vector3.zero;
            
            LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setEaseOutElastic();
            
            LeanTween.scale(_mainMenuButton.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setDelay(0.3f).setEaseOutElastic();
            
            LeanTween.scale(_restartButton.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setDelay(0.4f).setEaseOutElastic();
        }

        private void RestartButton()
        {
            _audioService.PlaySfx(SfxType.Click);
            _stateMachine.Enter<LoadLevelState,string>(SceneManager.GetActiveScene().name);
        }

        private void MainMenuButton()
        {
            _audioService.PlaySfx(SfxType.Click);
            _stateMachine.Enter<LoadMainMenuState>();
        }
    }
}