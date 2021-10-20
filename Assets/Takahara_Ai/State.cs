using UnityEngine;

public class State<T> : MonoBehaviour
{
    protected T owner;

    public State(T owner)
    {
        this.owner = owner;
    }

    //このステートに遷移するとき一度だけ呼ばれる
    public virtual void Enter(){}
    //このステートである間ずっと呼ばれる
    public virtual void Execute(){}
    //このステートから他のステートに遷移するとき一度だけ呼ばれる
    public virtual void Exit(){}
}
