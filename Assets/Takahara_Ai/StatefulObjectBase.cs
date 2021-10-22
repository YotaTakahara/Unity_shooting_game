using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ai
{
    public abstract class StatefulObjectBase<T, TEnum> : MonoBehaviour
        where T : class where TEnum : IConvertible
    {
        protected List<State<T>> stageList = new List<State<T>>();
        protected StateMachine<T> stateMachine;

        public virtual void ChangeStateNext(int state)
        {
            if (stateMachine == null)
            {
                //Debug.Log("statemachine" + "null");
                return;
            }
            Debug.Log("stateMachine go well " + stateMachine);
            stateMachine.ChangeState(stageList[state]);
        }

        public virtual bool IsCurrentState(int state)
        {
            if (stateMachine == null)
            {
                return false;
            }

            return stateMachine.CurrentState == stageList[state];
        }

        protected virtual void Update()
        {
            if (stateMachine != null)
            {
                stateMachine.Update();
            }
        }
    }
}