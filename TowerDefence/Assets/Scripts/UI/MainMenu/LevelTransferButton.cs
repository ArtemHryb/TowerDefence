using Architecture.States;
using Architecture.States.Interfaces;
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

        [Inject]
        public void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake() =>
            _button.onClick.AddListener(OnClick);

        private void OnClick()
        {
            _stateMachine.Enter<LoadLevelState, string>(LevelId.ToString());
        }
    }
}