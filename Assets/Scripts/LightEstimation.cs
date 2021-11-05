using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.ARFoundation;

public class LightEstimation : MonoBehaviour
{
    public ARCameraManager cameraManager;
    Light light;

    // 起動時に呼ばれる
    void Awake ()
    {
        light = GetComponent<Light>();
    }

    // 有効時に呼ばれる
    void OnEnable()
    {
        if (cameraManager != null)
        {
            cameraManager.frameReceived += FrameChanged;
        }
    }

    // 無効時に呼ばれる
    void OnDisable()
    {
        if (cameraManager != null)
        {
            cameraManager.frameReceived -= FrameChanged;
        }
    }

    // フレーム変更時に呼ばれる
    void FrameChanged(ARCameraFrameEventArgs args)
    {
        // ライトの輝度
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            float? averageBrightness = args.lightEstimation.averageBrightness.Value;
            light.intensity = averageBrightness.Value;
        }

        // ライトの色温度
        if (args.lightEstimation.averageColorTemperature.HasValue)
        {
            float? averageColorTemperature = args.lightEstimation.averageColorTemperature.Value;
            light.colorTemperature = averageColorTemperature.Value;
        }

        // ライトの色
        if (args.lightEstimation.colorCorrection.HasValue)
        {
            Color? colorCorrection = args.lightEstimation.colorCorrection.Value;
            light.color = colorCorrection.Value;
        }
    }
}