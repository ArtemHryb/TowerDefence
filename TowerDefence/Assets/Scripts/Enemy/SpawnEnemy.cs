using Architecture.Services;
using Architecture.Services.Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Button _button;
    
    private IEnemySpawner _enemySpawner;
    private ICurrentLevelSettingsProvider _currentLevel;
    
    [Inject]
    private void Construct(IEnemySpawner enemySpawner
        ,ICurrentLevelSettingsProvider currentLevelSettingsProvider)
    {
        _enemySpawner = enemySpawner;
        _currentLevel = currentLevelSettingsProvider;
    }
    private void Awake()
    {
        _button.onClick.AddListener(Spawn);
    }

    private void Spawn()
    {
        _button.interactable = false;
        if (SceneManager.GetActiveScene().name == _currentLevel.GetCurrentLevelSettings().LevelId.ToString())
        {
            _enemySpawner.SpawnEnemies(_currentLevel.GetCurrentLevelSettings().EnemyCount
                ,_currentLevel.GetCurrentLevelSettings().Waves
                ,_currentLevel.GetCurrentLevelSettings().DelayBeforeNextWave);   
        }
    }
}
