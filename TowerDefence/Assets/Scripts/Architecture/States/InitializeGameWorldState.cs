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

        public InitializeGameWorldState(IStateMachine stateMachine, IUIFactory uiFactory, 
            IComponentFactory componentFactory, ICoinService coinService, IPlayerHpService playerHpService)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _componentFactory = componentFactory;
            _coinService = coinService;
            _playerHpService = playerHpService;
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
            _uiFactory.CreateInGameMenu();
            _componentFactory.InstantiateComponents();
            _coinService.SetCoins();
            _playerHpService.SetHp();
        }
    }
}