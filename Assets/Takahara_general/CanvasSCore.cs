using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScore : SingletonMonoBehaviour<CanvasScore>

{
    public void Awake()
    {

        //Instance.transform.position.z = 0;
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

    }
}
