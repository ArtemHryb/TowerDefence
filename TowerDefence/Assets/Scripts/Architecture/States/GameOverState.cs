using Architecture.Services.Factories.UI;
using Architecture.States.Interfaces;

namespace Architecture.States
{
    public class GameOverState : IState
    {
        private readonly IUIFactory _uiFactory;

        public GameOverState(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        public void Exit()
        {
        }
        public void Enter()
        {
            _uiFactory.CreateLoseMenu();
        }
    }
}