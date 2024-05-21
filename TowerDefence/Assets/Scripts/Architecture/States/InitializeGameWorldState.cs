using Architecture.Services;
using Architecture.Services.Audio;
using Architecture.Services.Coin;
using Architecture.Services.Factories.Components;
using Architecture.Services.Factories.UI;
using Architecture.Services.Player;
using Architecture.States.Interfaces;

namespace Architecture.States
{
    public class InitializeGameWorldState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly IComponentFactory _componentFactory;
        private readonly ICoinService _coinService;
        private readonly IPlayerHpService _playerHpService;
        private readonly IAudioService _audioService;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        public InitializeGameWorldState(IStateMachine stateMachine, IUIFactory uiFactory, 
            IComponentFactory componentFactory, ICoinService coinService
            ,IPlayerHpService playerHpService, IAudioService audioService,
            ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _componentFactory = componentFactory;
            _coinService = coinService;
            _playerHpService = playerHpService;
            _audioService = audioService;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            InitGame();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGame()
        {
            _audioService.PlayMusic(_currentLevelSettingsProvider.GetCurrentLevelSettings().MusicType);
            _uiFactory.CreateInGameMenu();
            _componentFactory.InstantiateComponents();
            _coinService.SetCoins();
            _playerHpService.SetHp();
        }
    }
}