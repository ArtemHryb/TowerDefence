using Architecture.Services.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.InGame.Pause
{
    public class PauseMenu : MonoBehaviour
    {
        private const string MusicPrefKey = "MusicEnabled";
        private const string SoundsPrefKey = "SoundsEnabled";
        
        [Header("Buttons")]
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Toggle _soundsToggle;

        [Header("Music")]
        [SerializeField] private Sprite _enabledMusicSprite;
        [SerializeField] private Sprite _disabledMusicSprite;
        
        [Header("Sound")]
        [SerializeField] private Sprite _enabledSoundsSprite;
        [SerializeField] private Sprite _disabledSoundsSprite;

        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService) => _audioService = audioService;

        private void Awake()
        {
            UpdateMusicSprite(_musicToggle, PlayerPrefs.GetInt(MusicPrefKey, 1) == 1);
            UpdateSoundsSprite(_soundsToggle, PlayerPrefs.GetInt(SoundsPrefKey, 1) == 1);

            _musicToggle.onValueChanged.AddListener(SetMusicEnabled);
            _soundsToggle.onValueChanged.AddListener(SetSoundsEnabled);
        }

        private void SetMusicEnabled(bool isEnabled)
        {
            _audioService.SetMusicEnabled(isEnabled);
            UpdateMusicSprite(_musicToggle, isEnabled);
        }

        private void SetSoundsEnabled(bool isEnabled)
        {
            _audioService.SetSoundsEnabled(isEnabled);
            UpdateSoundsSprite(_soundsToggle, isEnabled);
        }

        private void UpdateMusicSprite(Toggle toggle, bool isEnabled) => 
            toggle.image.sprite = isEnabled ? _enabledMusicSprite : _disabledMusicSprite;

        private void UpdateSoundsSprite(Toggle toggle, bool isEnabled) => 
            toggle.image.sprite = isEnabled ? _enabledSoundsSprite : _disabledSoundsSprite;
    }
}