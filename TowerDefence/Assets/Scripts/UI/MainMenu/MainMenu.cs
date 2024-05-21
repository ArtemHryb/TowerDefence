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