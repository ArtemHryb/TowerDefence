using Architecture.States;
using Architecture.States.Interfaces;
using Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Settings
{
    public class PauseSettings : SettingsBase
    {
        [SerializeField] private Button _mainMenuButton;
        
        private IStateMachine _stateMachine;
        
        [Inject]
        public void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        private void Awake()
        {
            UpdateMusicSprite(_musicToggle, PlayerPrefs.GetInt(MusicPrefKey, 1) == 1);
            UpdateSoundsSprite(_soundsToggle, PlayerPrefs.GetInt(SoundsPrefKey, 1) == 1);

            _musicToggle.onValueChanged.AddListener(SetMusicEnabled);
            _soundsToggle.onValueChanged.AddListener(SetSoundsEnabled);
            _mainMenuButton.onClick.AddListener(MainMenuButton);
        }

        private void MainMenuButton()
        {
            AudioService.PlaySfx(SfxType.Click);
            _stateMachine.Enter<LoadMainMenuState>();
            Time.timeScale = 1f;
        }
    }
}