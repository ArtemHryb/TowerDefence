using Architecture.Services.Audio;
using Architecture.Services.Factories.UI;
using Architecture.States.Interfaces;
using Audio;

namespace Architecture.States
{
    public class VictoryState : IState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IAudioService _audioService;

        public VictoryState(IUIFactory uiFactory,IAudioService audioService)
        {
            _uiFactory = uiFactory;
            _audioService = audioService;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            _audioService.StopMusic();
            _audioService.PlaySfx(SfxType.Win);
            _uiFactory.CreateVictoryMenu();
        }
    }
}