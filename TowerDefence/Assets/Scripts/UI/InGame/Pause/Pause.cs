using Architecture.Services.Factories.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.InGame.Pause
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;

        [SerializeField] private Sprite _enablePause;
        [SerializeField] private Sprite _disablePause;

        private IUIFactory _uiFactory;
        
        [Inject]
        public void Construct(IUIFactory uiFactory) => _uiFactory = uiFactory;

        private void Awake()
        {
            _toggle.isOn = false;
            
            _toggle.onValueChanged.AddListener(PauseToggle);
        }

        private void PauseToggle(bool isEnabled)
        {
            UpdateToggleImage(_toggle, isEnabled);
            UpdatePauseMenu(isEnabled);
        }

        private void UpdateToggleImage(Toggle toggle, bool isEnabled) => 
            toggle.image.sprite = isEnabled ? _enablePause : _disablePause;

        private void UpdatePauseMenu(bool isEnabled)
        {
            if (isEnabled)
            {
                _uiFactory.CreatePauseMenu();
                //Time.timeScale = isEnabled ? 0 : 1;
            }
            else
            {
                 Destroy(_uiFactory.PauseMenu.gameObject);
                 Time.timeScale = 1f;
            }
        }
    }
}