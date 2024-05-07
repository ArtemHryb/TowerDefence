using Architecture.Services;
using Architecture.Services.Enemy;
using Architecture.Services.Factories.Enemy;
using Architecture.Services.Factories.UI;
using Architecture.Services.Interfaces;
using Architecture.States;
using Architecture.States.Interfaces;
using SceneManagement;
using UnityEngine;
using Zenject;

namespace Architecture.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private MyCoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            BindSceneLoader();
            BindCoroutineRunner();
            BindAssetProvider();
            BindUIFactory();
            BindEnemyFactory();
            BindEnemySpawner();
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