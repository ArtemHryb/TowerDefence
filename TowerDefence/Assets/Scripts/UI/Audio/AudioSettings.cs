using Architecture.Services.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Audio
{
    public abstract class AudioSettings : MonoBehaviour
    {
        protected const string MusicPrefKey = "MusicEnabled";
        protected const string SoundsPrefKey = "SoundsEnabled";

        [Header("Buttons")]
        [SerializeField] protected Toggle _musicToggle;
        [SerializeField] protected Toggle _soundsToggle;
        
        [Header("Music")]
        [SerializeField] protected Sprite _enabledMusicSprite;
        [SerializeField] protected Sprite _disabledMusicSprite;

        [Header("Sound")] 
        [SerializeField] protected Sprite _enabledSoundsSprite;
        [SerializeField] protected Sprite _disabledSoundsSprite;

        protected IAudioService AudioService;
        
        [Inject]
        public void Construct(IAudioService audioService) =>
            AudioService = audioService;

        protected void UpdateMusicSprite(Toggle toggle, bool isEnabled) => 
            toggle.image.sprite = isEnabled ? _enabledMusicSprite : _disabledMusicSprite;

        protected void UpdateSoundsSprite(Toggle toggle, bool isEnabled) => 
            toggle.image.sprite = isEnabled ? _enabledSoundsSprite : _disabledSoundsSprite;

        protected void SetMusicEnabled(bool isEnabled)
        {
            AudioService.SetMusicEnabled(isEnabled);
            UpdateMusicSprite(_musicToggle, isEnabled);
        }

        protected void SetSoundsEnabled(bool isEnabled)
        {
            AudioService.SetSoundsEnabled(isEnabled);
            UpdateSoundsSprite(_soundsToggle, isEnabled);
        }
        
    }
}