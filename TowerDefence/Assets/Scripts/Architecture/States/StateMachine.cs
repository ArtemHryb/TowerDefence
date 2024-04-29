using System;
using System.Collections.Generic;
using Architecture.States.Interfaces;

namespace Architecture.States
{
    public class StateMachine : IStateMachine
    {
        public Dictionary<Type,IExitableState> States { get; set; } = new();
        private IExitableState _activeState;

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload)
            where TState : class, IExitableState, IPayLoadedState<TPayload>
        {
            TState state = GetState<TState>();
            state.Enter(payload);
        }
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }
        private TState GetState<TState>() where TState : class,IExitableState => 
            States[typeof(TState)] as TState;
    }
}