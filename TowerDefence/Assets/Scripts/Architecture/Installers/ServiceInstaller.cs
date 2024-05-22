using Architecture.Services;
using Architecture.Services.Audio;
using Architecture.Services.Coin;
using Architecture.Services.Enemy;
using Architecture.Services.Factories.Audio;
using Architecture.Services.Factories.Components;
using Architecture.Services.Factories.Enemy;
using Architecture.Services.Factories.Tower;
using Architecture.Services.Factories.Tower.Bullet;
using Architecture.Services.Factories.UI;
using Architecture.Services.Interfaces;
using Architecture.Services.Player;
using Architecture.Services.Victory;
using Architecture.States;
using Architecture.States.Interfaces;
using Data.LevelData;
using SceneManagement;
using UI.Loading;
using UnityEngine;
using Zenject;

namespace Architecture.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private MyCoroutineRunner _coroutineRunner;
        [SerializeField] private LevelSettings _levelData;
        [SerializeField] private LoadingCurtain _loadingCurtain;

        public override void InstallBindings()
        {
            BindLoadingCurtain();
            BindSceneLoader();
            BindCoroutineRunner();
            BindAssetProvider();

            BindAudioFactory();
            BindAudioService();
            
            BindUIFactory();
            BindLevelsSettings();
            BindCurrentLevelSettingsProvider();
            
            BindPlayerHpService();
            BindCoinService();
            BindPlayerInput();
            
            BindComponentFactory();
            BindEnemyFactory();
            BindTowerFactory();
            BindBulletFactory();
            BindEnemySpawner();
            BindVictoryChecker();
        }

        private void BindLoadingCurtain()
        {
            LoadingCurtain loadingCurtain = Container
                .InstantiatePrefabForComponent<LoadingCurtain>(_loadingCurtain);

            Container
                .Bind<LoadingCurtain>()
                .FromInstance(loadingCurtain)
                .AsSingle();
        }

        private void BindAudioService()
        {
            Container
                .Bind<IAudioService>()
                .To<AudioService>()
                .AsSingle();
        }

        private void BindAudioFactory()
        {
            Container
                .Bind<IAudioFactory>()
                .To<AudioFactory>()
                .AsSingle();
        }

        private void BindVictoryChecker()
        {
            Container
                .Bind<IVictoryChecker>()
                .To<VictoryChecker>()
                .AsSingle();
        }

        private void BindBulletFactory()
        {
            Container
                .Bind<IBulletFactory>()
                .To<BulletFactory>()
                .AsSingle();
        }

        private void BindComponentFactory()
        {
            Container.
                Bind<IComponentFactory>()
                .To<ComponentFactory>()
                .AsSingle();
        }

        private void BindTowerFactory()
        {
            Container
                .Bind<ITowerFactory>()
                .To<TowerFactory>()
                .AsSingle();
        }

        private void BindPlayerInput()
        {
            PlayerInput input = new PlayerInput();
            
            input.Enable();
            
            Container
                .Bind<PlayerInput>()
                .FromInstance(input)
                .AsSingle();
        }

        private void BindCoinService()
        {
            Container
                .Bind<ICoinService>()
                .To<CoinService>()
                .AsSingle();
        }

        private void BindPlayerHpService()
        {
            Container
                .Bind<IPlayerHpService>()
                .To<PlayerHpService>()
                .AsSingle();
        }

        private void BindLevelsSettings()
        {
            Container
                .Bind<LevelSettings>()
                .FromScriptableObject(_levelData)
                .AsSingle();
        }

        private void BindCurrentLevelSettingsProvider()
        {
            Container
                .Bind<ICurrentLevelSettingsProvider>()
                .To<CurrentLevelSettingsProvider>()
                .AsSingle();
        }

        private void BindEnemySpawner()
        {
            Container
                .Bind<IEnemySpawner>()
                .To<EnemySpawner>()
                .AsSingle();
        }

        private void BindEnemyFactory()
        {
            Container
                .Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle();
        }

        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle();
        }

        private void BindAssetProvider()
        {
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }
        private void BindCoroutineRunner()
        {
            MyCoroutineRunner runner = Container
                .InstantiatePrefabForComponent<MyCoroutineRunner>(_coroutineRunner);

            Container
                .Bind<ICoroutineRunner>()
                .To<MyCoroutineRunner>()
                .FromInstance(runner);
        }
    }
}