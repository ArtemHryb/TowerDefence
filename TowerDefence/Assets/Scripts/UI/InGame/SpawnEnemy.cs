using Architecture.Services;
using Architecture.Services.Audio;
using Architecture.Services.Enemy;
using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI.InGame
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private Button _button;
    
        private IEnemySpawner _enemySpawner;
        private ICurrentLevelSettingsProvider _currentLevel;
        private IAudioService _audioService;
    
        [Inject]
        private void Construct(IEnemySpawner enemySpawner,ICurrentLevelSettingsProvider currentLevelSettingsProvider
        ,IAudioService audioService)
        {
            _enemySpawner = enemySpawner;
            _currentLevel = currentLevelSettingsProvider;
            _audioService = audioService;
        }
        private void Awake()
        {
            _button.onClick.AddListener(Spawn);
        }

        private void Spawn()
        {
            _audioService.PlaySfx(SfxType.StartAttack);
            _button.interactable = false;
            if (SceneManager.GetActiveScene().name == _currentLevel.GetCurrentLevelSettings().CurrentLevel.ToString())
            {
                _enemySpawner.SpawnEnemies(_currentLevel.GetCurrentLevelSettings().EnemyCount
                    ,_currentLevel.GetCurrentLevelSettings().Waves
                    ,_currentLevel.GetCurrentLevelSettings().DelayBeforeNextWave);   
            }
        }
    }
}
