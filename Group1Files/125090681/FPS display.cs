using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI fpsText;

    [Header("Settings")]
    public bool showFPS = true;

    float fps;
    float updateInterval = 0.5f;
    float timeSinceLastUpdate;

    void Start()
    {
        if (fpsText == null)
        {
            Debug.LogError("FPS Text not assigned!");
            return;
        }

        timeSinceLastUpdate = 0f;
        UpdateDisplay();
    }

    void Update()
    {
        // ✨ 新增：F2快捷键切换 ✨
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ToggleFPS();
        }

        if (!showFPS)
        {
            if (fpsText.gameObject.activeSelf)
                fpsText.gameObject.SetActive(false);
            return;
        }
        else
        {
            if (!fpsText.gameObject.activeSelf)
                fpsText.gameObject.SetActive(true);
        }

        // 计算FPS
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= updateInterval)
        {
            fps = 1f / Time.deltaTime;
            fpsText.text = $"FPS: {fps:F0}";
            timeSinceLastUpdate = 0f;
        }
    }

    // ✨ 新增：公开方法，用于切换 ✨
    public void ToggleFPS()
    {
        showFPS = !showFPS;
        UpdateDisplay();
        Debug.Log($"FPS Display: {(showFPS ? "ON" : "OFF")}");
    }

    public void SetFPSDisplay(bool show)
    {
        showFPS = show;
        UpdateDisplay();
    }

    public bool IsShowingFPS()
    {
        return showFPS;
    }

    void UpdateDisplay()
    {
        if (fpsText != null)
            fpsText.gameObject.SetActive(showFPS);
    }
}