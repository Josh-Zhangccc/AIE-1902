using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    [Header("显示开关")]
    public bool showFPS = true;

    [Header("文字样式")]
    public int fontSize = 40; // 保持40号
    public Color textColor = Color.red;
    public bool boldText = true;

    [Header("显示位置")]
    public FPSPosition position = FPSPosition.TopRight;
    // 针对40号字的最优偏移，完美显示
    public Vector2 offset = new Vector2(20, 20);

    public enum FPSPosition
    {
        TopLeft, TopRight, BottomLeft, BottomRight
    }

    private float deltaTime = 0.0f;
    private GUIStyle style;

    void Start()
    {
        style = new GUIStyle();
        // 用左上对齐，配合位置计算，绝对不会跑出屏幕
        style.alignment = TextAnchor.UpperLeft;
        style.clipping = TextClipping.Overflow;
        style.fontStyle = boldText ? FontStyle.Bold : FontStyle.Normal;
    }

    void Update()
    {
        if (!showFPS) return;
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        // 按F1一键开关FPS
        if (Input.GetKeyDown(KeyCode.F1))
        {
            showFPS = !showFPS;
        }
    }

    void OnGUI()
    {
        if (!showFPS) return;

        // 每帧更新样式，实时生效
        style.fontSize = fontSize;
        style.normal.textColor = textColor;

        // 固定适配40号字的显示区域，绝对够大
        float labelWidth = 300;
        float labelHeight = 100;
        Rect rect = new Rect(0, 0, labelWidth, labelHeight);

        switch (position)
        {
            case FPSPosition.TopRight:
                // 核心修复：用屏幕宽度减去文字宽度和偏移，保证文字完整显示
                rect.x = Screen.width - labelWidth - offset.x;
                rect.y = offset.y;
                break;
            case FPSPosition.TopLeft:
                rect.x = offset.x;
                rect.y = offset.y;
                break;
            case FPSPosition.BottomLeft:
                rect.x = offset.x;
                rect.y = Screen.height - labelHeight - offset.y;
                break;
            case FPSPosition.BottomRight:
                rect.x = Screen.width - labelWidth - offset.x;
                rect.y = Screen.height - labelHeight - offset.y;
                break;
        }

        float fps = 1.0f / deltaTime;
        float ms = deltaTime * 1000;
        string text = $"FPS: {fps:F1}\n帧时间: {ms:F1}ms";

        GUI.Label(rect, text, style);
    }
}