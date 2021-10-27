using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss
{

    public abstract class State1<T> : MonoBehaviour
    {
        public T owner;

        public State1(T owner)
        {
            this.owner = owner;
        }
        public virtual void Enter() { }
        public virtual void Execute() { }
        public virtual void Exit() { }
    }
}
