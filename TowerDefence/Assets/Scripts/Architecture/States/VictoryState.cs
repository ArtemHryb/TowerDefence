using Architecture.Services.Audio;
using Architecture.Services.Factories.UI;
using Architecture.Services.Interfaces;
using Architecture.States.Interfaces;
using Audio;

namespace Architecture.States
{
    public class VictoryState : IState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IAudioService _audioService;
        private readonly ISaveProgressService _saveProgressService;

        public VictoryState(IUIFactory uiFactory,IAudioService audioService, ISaveProgressService saveProgressService)
        {
            _uiFactory = uiFactory;
            _audioService = audioService;
            _saveProgressService = saveProgressService;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            _saveProgressService.SaveLevelProgress();
            _audioService.StopMusic();
            _audioService.PlaySfx(SfxType.Win);
            _uiFactory.CreateVictoryMenu();
        }
    }
}