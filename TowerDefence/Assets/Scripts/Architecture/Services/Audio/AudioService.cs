using System.Collections.Generic;
using Architecture.Services.Factories.Audio;
using Architecture.Services.Interfaces;
using Audio;
using Data;
using UnityEngine;

namespace Architecture.Services.Audio
{
    public class AudioService : IAudioService
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IAudioFactory _audioFactory;

        private readonly List<SfxData> _sfxDataList = new(); 
        private readonly List<MusicData> _musicDataList = new();

        private AudioSource _sfxAudioSource;
        private AudioSource _musicAudioSource;

        public AudioService(IAssetProvider assetProvider, IAudioFactory audioFactory)
        {
            _assetProvider = assetProvider;
            _audioFactory = audioFactory;
            InitializeSfxDataList();
            InitializeMusicDataList();
            InitializeSfxAudioSource();
            InitializeMusicAudioSource();
        }

        public void PlayMusic(MusicType musicType)
        {
            MusicData musicData = GetMusicData(musicType);
            _musicAudioSource.clip = musicData.Clip;
            _musicAudioSource.Play();
        }

        public void PlaySfx(SfxType sfxType)
        {
            var sfxData = GetSfxData(sfxType);
            _sfxAudioSource.PlayOneShot(sfxData.Clip);
        }

        public void StopMusic() =>
            _musicAudioSource.Stop();

        private MusicData GetMusicData(MusicType musicType)
        {
            MusicData result = _musicDataList.Find(data => data.MusicType == musicType);
            return result;
        }

        private SfxData GetSfxData(SfxType sfxType)
        {
            SfxData result = _sfxDataList.Find(data => data.SfxType == sfxType);
            return result;
        }

        private void InitializeSfxDataList()
        {
            SfxHolder sfxHolder = _assetProvider.Initialize<SfxHolder>(AssetPath.SfxHolder);

            foreach (SfxData sfx in sfxHolder.SoundEffects)
                _sfxDataList.Add(sfx);
        }

        private void InitializeMusicDataList()
        {
            MusicHolder musicHolder = _assetProvider.Initialize<MusicHolder>(AssetPath.MusicHolder);

            foreach (MusicData music in musicHolder.Musics)
                _musicDataList.Add(music);
        }

        private void InitializeSfxAudioSource() =>
            _sfxAudioSource = _audioFactory.CreateAudioSource(AudioSourceType.SfxAudioSource);

        private void InitializeMusicAudioSource() =>
            _musicAudioSource = _audioFactory.CreateAudioSource(AudioSourceType.MusicAudioSource);
    }
}