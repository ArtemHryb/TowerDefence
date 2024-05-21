using Audio;
using UnityEngine;

namespace Architecture.Services.Factories.Audio
{
    public interface IAudioFactory
    {
        AudioSource CreateAudioSource(AudioSourceType sourceType);
    }
}