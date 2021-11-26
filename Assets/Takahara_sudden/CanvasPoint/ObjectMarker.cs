using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMarker : MonoBehaviour
{
    [SerializeField] private GameObject airPlane;
    [SerializeField] private Camera _targetCamera;

    // UIを表示させる対象オブジェクト
    [SerializeField] private Transform _target;

    // 表示するUI
    [SerializeField] private Transform _targetUI;

    // オブジェクト位置のオフセット
    [SerializeField] private Vector3 _worldOffset;

    private RectTransform _parentUI;

    // 初期化メソッド（Prefabから生成する時などに使う）
    public void Initialize(Transform target, Camera targetCamera = null)
    {
        _target = target;
        _targetCamera = targetCamera != null ? targetCamera : Camera.main;

        OnUpdatePosition();
    }

    private void Awake()
    {
        airPlane = GameObject.Find("AirPlane");
        // カメラが指定されていなければメインカメラにする
        if (_targetCamera == null)
            _targetCamera = Camera.main;

        // 親UIのRectTransformを保持
        _parentUI = _targetUI.parent.GetComponent<RectTransform>();
    }

    // UIの位置を毎フレーム更新
    private void Update()
    {
        if(_target==null){
            Destroy(this.gameObject);
        }
        OnUpdatePosition();
    }

    // UIの位置を更新する
    private void OnUpdatePosition()
    {

        var cameraTransform = _targetCamera.transform;

        // カメラの向きベクトル
        var cameraDir = cameraTransform.forward;
        // オブジェクトの位置
        var targetWorldPos = _target.position + _worldOffset;
        // カメラからターゲットへのベクトル
        var targetDir = targetWorldPos - cameraTransform.position;

        // 内積を使ってカメラ前方かどうかを判定
        var isFront = Vector3.Dot(cameraDir, targetDir) > 0;

        // カメラ前方ならUI表示、後方なら非表示
        // _targetUI.gameObject.SetActive(isFront);
        _targetUI.gameObject.SetActive(isFront);
        if (!isFront) return;

        float distance = Vector3.Magnitude(airPlane.transform.position - _target.position);
        if(distance>100f){
            _targetUI.gameObject.SetActive(false);
            return;
        }
        // オブジェクトのワールド座標→スクリーン座標変換
        var targetScreenPos = _targetCamera.WorldToScreenPoint(targetWorldPos);

        // スクリーン座標変換→UIローカル座標変換
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _parentUI,
            targetScreenPos,
            _targetCamera,
            out var uiLocalPos
        );

        // RectTransformのローカル座標を更新
        _targetUI.localPosition = uiLocalPos;
    }
}
