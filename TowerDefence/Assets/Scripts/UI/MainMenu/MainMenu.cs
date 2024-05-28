using Architecture.Services.Audio;
using Architecture.Services.Factories.UI;
using Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Menu Buttons")] 
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _settingsButton;
        
        private IUIFactory _uiFactory;
        private IAudioService _audioService;
        
        [Inject]
        public void Construct(IUIFactory uiFactory, IAudioService audioService)
        {
            _uiFactory = uiFactory;
            _audioService = audioService;
        }
        
        private void Awake()
        {
            _playButton.onClick.AddListener(Play);
            _exitButton.onClick.AddListener(Exit);
            _settingsButton.onClick.AddListener(Settings);
        }

        private void Settings() => _uiFactory.CreateSettingsMenu();

        private void Start()
        {
            _playButton.transform.localScale = Vector3.zero;
            _exitButton.transform.localScale = Vector3.zero;
            _settingsButton.transform.localScale = Vector3.zero;
            
            LeanTween.scale(_playButton.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setDelay(1.3f).setEaseOutElastic();
            
            LeanTween.scale(_exitButton.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setDelay(1.4f).setEaseOutElastic();
            
            LeanTween.scale(_settingsButton.gameObject, new Vector3(1f, 1f, 1f), 1.5f)
                .setDelay(1.5f).setEaseOutElastic();
        }

        private void Play()
        {
          _uiFactory.CreateLevelSelection();
          _audioService.PlaySfx(SfxType.Click);
        }

        private void Exit()
        {
            _audioService.PlaySfx(SfxType.Click);
            Application.Quit();
        }
    }
}