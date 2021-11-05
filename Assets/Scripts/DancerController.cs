using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

// ダンサーコントローラ
public class DancerController : MonoBehaviour
{
    // 状態定数
    public enum State {
        NONE,  // 非表示
        IDLE,  // 待機
        DANCE  // ダンス
    }

    // 情報
    Camera camera; // カメラ
    GameObject label; // ラベル
    State state = State.NONE; // 状態

    // 初期化時に呼ばれる
    void Start()
    {
        this.camera = (Camera)GameObject.Find("AR Camera").GetComponent<Camera>();
        this.label = GameObject.Find("Label");
        SetState(State.IDLE);
    }

    // フレーム毎に呼ばれる
    void Update()
    {
        // タッチ位置の取得
        Vector3? touchPosition = null;
        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.GetTouch(0).position;
        }

        // 待機
        if (this.state == State.IDLE)
        {
            if (touchPosition != null && HitTest((Vector3)touchPosition))
            {
                SetState(State.DANCE);
            }
        }
        // ダンス
        else if (this.state == State.DANCE)
        {
            if (touchPosition != null && HitTest((Vector3)touchPosition))
            {
                SetState (State.NONE);
            }
        }
    }

    // 状態の遷移
    public void SetState(State state)
    {
        if (this.state == state) return;
        this.state = state;
        GameObject sessionOrigin = GameObject.Find("AR Session Origin");
        Animator animater = GetComponent<Animator>();

        // 非表示
        if (state == State.NONE)
        {
            SetPlaneVisible(true);
            sessionOrigin.GetComponent<ARRaycastManager>().enabled = true;
            sessionOrigin.GetComponent<CreateObject>().enabled = true;
            this.label.SetActive(true);
            gameObject.SetActive(false);
        }
        // 待機
        else if (state == State.IDLE)
        {
            SetPlaneVisible(false);
            sessionOrigin.GetComponent<ARRaycastManager>().enabled = false;
            sessionOrigin.GetComponent<CreateObject>().enabled = false;
            this.label.SetActive(false);
            animater.CrossFade("idle", 0);
        }
        // ダンス
        else if (state == State.DANCE)
        {
            animater.CrossFade("dance", 0);
        }
    }

    // 平面の表示
    void SetPlaneVisible(bool visible)
    {
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("plane"))
        {
            plane.GetComponent<Renderer>().enabled = visible;
            plane.GetComponent<ARPlaneMeshVisualizer>().enabled = visible;
        }
    }

    // ヒット判定
    bool HitTest(Vector3 touchPosition)
    {
        if (touchPosition != null)
        {
            Ray ray = camera.ScreenPointToRay(touchPosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast (ray, out hit) &&
                hit.collider.gameObject == this.gameObject)
            {
                return true;
            }
        }
        return false;
    }
}
