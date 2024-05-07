using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform _finish;

        private void Start()
        {
            MoveToFinish(_finish);
        }

        private void MoveToFinish(Transform finish)
        {
            _agent.SetDestination(finish.position);
        }
    }
}