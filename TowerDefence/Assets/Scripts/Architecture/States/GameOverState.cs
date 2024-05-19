using Architecture.Services.Factories.Enemy;
using Architecture.Services.Factories.UI;
using Architecture.States.Interfaces;

namespace Architecture.States
{
    public class GameOverState : IState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IEnemyFactory _enemyFactory;

        public GameOverState(IUIFactory uiFactory,IEnemyFactory enemyFactory)
        {
            _uiFactory = uiFactory;
            _enemyFactory = enemyFactory;
        }
        public void Exit()
        {
        }
        public void Enter()
        {
            _uiFactory.CreateLoseMenu();
            _enemyFactory.EnemyParent.DestroyEnemies();
        }
    }
}