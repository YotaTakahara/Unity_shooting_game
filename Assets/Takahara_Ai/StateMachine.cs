using UnityEngine;

namespace Ai
{
    public class StateMachine<T> : MonoBehaviour
    {
        [SerializeField] private State<T> currentState;

        public StateMachine()
        {
            currentState = null;
        }

        public State<T> CurrentState
        {
            get { return currentState; }
        }

        public void ChangeState(State<T> state)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            currentState = state;
            Debug.Log("Change State にはおかしなところはない");
            Debug.Log("state " + state);

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