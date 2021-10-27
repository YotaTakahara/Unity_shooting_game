using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class StateMachine1<T> : MonoBehaviour
    {
        [SerializeField] protected State1<T> currentState;
        public StateMachine1()
        {
            currentState = null;
        }
        public State1<T> CurrentState
        {
            get { return currentState; }
        }
        public void ChangeState(State1<T> state)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            currentState = state;
            currentState.Enter();
        }
        public void Update()
        {
            if (currentState != null)
            {
                currentState.Execute();
            }
        }

    }
}
