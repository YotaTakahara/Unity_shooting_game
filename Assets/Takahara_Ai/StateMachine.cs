using UnityEngine;

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
        currentState.Execute();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
}