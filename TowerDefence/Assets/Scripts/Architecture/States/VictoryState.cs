using Architecture.Services.Factories.UI;
using Architecture.States.Interfaces;

namespace Architecture.States
{
    public class VictoryState : IState
    {
        private readonly IUIFactory _uiFactory;

        public VictoryState(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            _uiFactory.CreateVictoryMenu();
        }
    }
}