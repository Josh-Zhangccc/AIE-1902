using UnityEngine;
using UnityEngine.UI;

public class ToggleHotkey : MonoBehaviour
{
    [Header("Settings")]
    public KeyCode hotkey = KeyCode.Tab;

    [Header("Buttons")]
    public Button openButton;   // 打开设置按钮
    public Button closeButton;  // 关闭设置按钮

    private bool isOpen = false; // 当前状态

    void Update()
    {
        if (Input.GetKeyDown(hotkey))
        {
            if (isOpen)
            {
                // 当前是打开状态，触发关闭按钮
                if (closeButton != null)
                {
                    closeButton.onClick.Invoke();
                    Debug.Log("Settings closed via hotkey");
                }
            }
            else
            {
                // 当前是关闭状态，触发打开按钮
                if (openButton != null)
                {
                    openButton.onClick.Invoke();
                    Debug.Log("Settings opened via hotkey");
                }
            }

            // 切换状态
            isOpen = !isOpen;
        }
    }

    // 公开方法：强制设置状态
    public void ForceState(bool open)
    {
        isOpen = open;
    }
}