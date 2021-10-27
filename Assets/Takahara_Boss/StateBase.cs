using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class StateBase<T, TEnum> : MonoBehaviour
    where T : class where TEnum : System.IConvertible
    {
        [SerializeField] protected List<State1<T>> stateList = new List<State1<T>>();
        [SerializeField] protected StateMachine1<T> stateMachine;



        public void ChangeStateNext(int index)
        {
            if (stateMachine != null && stateList[index] != null)
            {
                stateMachine.ChangeState(stateList[index]);
            }

        }
        public void Update()
        {
            stateMachine.Update();
        }







    }
}
