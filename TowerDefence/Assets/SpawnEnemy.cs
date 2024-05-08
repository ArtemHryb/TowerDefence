using Architecture.Services.Enemy;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Button _button;
    
    private IEnemySpawner _enemySpawner;

    [Inject]
    private void Construct(IEnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
    }
    private void Awake()
    {
        _button.onClick.AddListener(Spawn);
    }

    private void Spawn()
    {
        _button.interactable = false;
        _enemySpawner.SpawnEnemies(3,3,3f);
    }
}
