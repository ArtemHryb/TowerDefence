using System.Collections;
using Architecture.Services.Factories.Enemy;
using Architecture.States;
using Architecture.States.Interfaces;
using ModestTree;
using UnityEngine;

namespace Architecture.Services.Victory
{
    public class VictoryChecker : IVictoryChecker
    {
        private const int CheckFrequency = 2;

        private readonly IEnemyFactory _enemyFactory;
        private readonly IStateMachine _stateMachine;

        public VictoryChecker(IStateMachine stateMachine, IEnemyFactory enemyFactory)
        {
            _stateMachine = stateMachine;
            _enemyFactory = enemyFactory;
        }

        public IEnumerator Check()
        {
            while (true)
            {
                if (CheckAreAllEnemiesDied())
                {
                    _stateMachine.Enter<VictoryState>();
                    yield break;
                }

                yield return new WaitForSeconds(CheckFrequency);
            }
        }

        private bool CheckAreAllEnemiesDied() =>
            _enemyFactory.EnemyParent.Enemies.IsEmpty();
    }
}