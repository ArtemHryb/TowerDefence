using UnityEngine;

namespace UI.Audio
{
    public class PauseMenu : AudioSettings
    {
        private void Awake()
        {
            UpdateMusicSprite(_musicToggle, PlayerPrefs.GetInt(MusicPrefKey, 1) == 1);
            UpdateSoundsSprite(_soundsToggle, PlayerPrefs.GetInt(SoundsPrefKey, 1) == 1);

            _musicToggle.onValueChanged.AddListener(SetMusicEnabled);
            _soundsToggle.onValueChanged.AddListener(SetSoundsEnabled);
        }
    }
}