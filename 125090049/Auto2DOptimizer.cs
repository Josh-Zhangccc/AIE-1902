using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Auto2DOptimizer : MonoBehaviour
{
    private void Awake()
    {
        Camera cam = GetComponent<Camera>();
        
        // 1. 相机切换为正交模式（2D视角）
        cam.orthographic = true;
        cam.orthographicSize = 5f; // 可根据场景大小调整
        
        // 2. 关闭所有后处理与渲染开销
        cam.allowHDR = false;
        cam.allowMSAA = false;
        cam.allowDynamicResolution = false;
        
        // 3. 全局关闭阴影、抗锯齿，提升帧率
        QualitySettings.shadows = ShadowQuality.Disable;
        QualitySettings.antiAliasing = 0;
        QualitySettings.vSyncCount = 0;
    }
}