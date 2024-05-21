using Architecture.Services.Interfaces;
using Audio;
using Data;
using UnityEngine;
using Zenject;

namespace Architecture.Services.Factories.Audio
{
    public class AudioFactory : IAudioFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;

        public AudioFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public AudioSource CreateAudioSource(AudioSourceType sourceType)
        {
            switch (sourceType)
            {
                case AudioSourceType.MusicAudioSource:
                    AudioSource musicSource = _container
                        .InstantiatePrefabForComponent<AudioSource>(_assetProvider
                            .Initialize<AudioSource>(AssetPath.MusicAudioSource));
                    return musicSource;
                
                case AudioSourceType.SfxAudioSource:
                    AudioSource sfxSource = _container
                        .InstantiatePrefabForComponent<AudioSource>(_assetProvider
                            .Initialize<AudioSource>(AssetPath.SfxAudioSource));
                    return sfxSource;
            }

            return null;
        }
    }
}