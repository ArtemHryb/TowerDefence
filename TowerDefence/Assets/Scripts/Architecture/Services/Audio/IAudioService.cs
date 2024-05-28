using Audio;

namespace Architecture.Services.Audio
{
    public interface IAudioService
    {
        void PlayMusic(MusicType musicType);
        void PlaySfx(SfxType sfxType);
        void StopMusic();
        void SetMusicEnabled(bool isEnabled);
        void SetSoundsEnabled(bool isEnabled);
    }
}