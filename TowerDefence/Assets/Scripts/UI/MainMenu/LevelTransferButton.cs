using Architecture.Services.Audio;
using Architecture.States;
using Architecture.States.Interfaces;
using Audio;
using Data.LevelData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.MainMenu
{
    public class LevelTransferButton : MonoBehaviour
    {
        public Levels LevelId;

        [SerializeField] private Button _button;

        private IStateMachine _stateMachine;
        private IAudioService _audioService;

        [Inject]
        public void Construct(IStateMachine stateMachine, IAudioService audioService)
        {
            _stateMachine = stateMachine;
            _audioService = audioService;
        }

        private void Awake() =>
            _button.onClick.AddListener(OnClick);

        private void OnClick()
        {
            _stateMachine.Enter<LoadLevelState, string>(LevelId.ToString());
            _audioService.PlaySfx(SfxType.Click);
        }
    }
}