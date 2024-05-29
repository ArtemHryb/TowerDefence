using UnityEngine;
using UnityEngine.UI;

namespace UI.Audio
{
    public class SettingsMenu : AudioSettings
    {
        [SerializeField] private Button _closeButton;
        
        private void Awake()
        {
            UpdateMusicSprite(_musicToggle, PlayerPrefs.GetInt(MusicPrefKey, 1) == 1);
            UpdateSoundsSprite(_soundsToggle, PlayerPrefs.GetInt(SoundsPrefKey, 1) == 1);

            _closeButton.onClick.AddListener(Close);
            _musicToggle.onValueChanged.AddListener(SetMusicEnabled);
            _soundsToggle.onValueChanged.AddListener(SetSoundsEnabled);
        }

        private void Close() => Destroy(gameObject);
    }
}