using Architecture.Services.Factories.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Buttons")] 
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        
        private IUIFactory _uiFactory;
        
        [Inject]
        public void Construct(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        private void Awake()
        {
            _playButton.onClick.AddListener(Play);
            _exitButton.onClick.AddListener(Exit);
        }

        private void Play()
        {
          _uiFactory.CreateLevelSelection();
        }

        private void Exit() => 
            Application.Quit();
    }
}