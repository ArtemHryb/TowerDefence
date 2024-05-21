using Architecture.Services.Audio;
using Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.MainMenu
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IAudioService _audioService;
        
        [Inject]
        public void Construct(IAudioService audioService)
        {
            _audioService = audioService;
        }
        private void Awake()
        {
            _button.onClick.AddListener(Close);
        }

        private void Close()
        {
            _audioService.PlaySfx(SfxType.Click);
            Destroy(gameObject);
        }
    }
}