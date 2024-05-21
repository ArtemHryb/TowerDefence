using Architecture.Services;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        private ICurrentLevelSettingsProvider _currentLevelSettingsProvider;
        
        [Inject]
        public void Construct(ICurrentLevelSettingsProvider currentLevelSettingsProvider) => 
            _currentLevelSettingsProvider = currentLevelSettingsProvider;

        private void Start()
        {
            MoveToFinish(_currentLevelSettingsProvider.GetCurrentLevelSettings().Finish);
        }

        private void MoveToFinish(Vector3 finish) => 
            _agent.SetDestination(finish);
    }
}