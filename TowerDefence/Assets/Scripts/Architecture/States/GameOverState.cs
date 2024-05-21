using Architecture.Services.Audio;
using Architecture.Services.Factories.Enemy;
using Architecture.Services.Factories.UI;
using Architecture.States.Interfaces;
using Audio;

namespace Architecture.States
{
    public class GameOverState : IState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IAudioService _audioService;

        public GameOverState(IUIFactory uiFactory,IEnemyFactory enemyFactory
            ,IAudioService audioService)
        {
            _uiFactory = uiFactory;
            _enemyFactory = enemyFactory;
            _audioService = audioService;
        }
        public void Exit()
        {
        }
        public void Enter()
        {
            _audioService.StopMusic();
            _audioService.PlaySfx(SfxType.GameOver);
            _uiFactory.CreateLoseMenu();
            _enemyFactory.EnemyParent.DestroyEnemies();
        }
    }
}