using System.Collections.Generic;
using UdemyProje3.Abstracts.StateMachines;

namespace UdemyProje3.StateMachines
{
    public class StateMachine 
    {
        List<StateTransition> _stateTransitions = new List<StateTransition>();
        List<StateTransition> _anyStateTransitions = new List<StateTransition>();

        IState _currentState;

        public void SetState(IState state)
        {
            if (state == _currentState) return;
            _currentState?.OnExit();
            _currentState = state;
            _currentState.OnEnter();
        }
        public void Ticks()
        {
            StateTransition _stateTransition = CheckForTransition();
            if (_stateTransition!=null)
            {
                SetState(_stateTransition.To);
            }
            _currentState.Tick();
        }

        private StateTransition CheckForTransition()
        {
            foreach (StateTransition anyStateTransition in _anyStateTransitions)
            {
                if (anyStateTransition.Condition.Invoke()) return anyStateTransition;
            }
            foreach (StateTransition stateTransition in _stateTransitions)
            {
                if (stateTransition.Condition()&&stateTransition.From==_currentState)
                {
                    return stateTransition;
                }
            }
            return null;
        }

        public void AddTransition(IState from,IState to,System.Func<bool> condition)
        {
            StateTransition statetransition = new StateTransition(from, to, condition);
            _stateTransitions.Add(statetransition);
        }

        public void AddAnyState(IState to,System.Func<bool> condition)
        {
            StateTransition anyStateTransition = new StateTransition(null, to, condition);
            _anyStateTransitions.Add(anyStateTransition);
        }
    }
}