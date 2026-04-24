using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制UI界面的显示与隐藏切换
/// </summary>
public class UIToggleController : MonoBehaviour
{
    // 需要显示/隐藏的UI面板（在Inspector中赋值）
    [Tooltip("拖入需要控制显示/隐藏的UI面板")]
    public GameObject targetUI;

    void Start()
    {
        // 初始化：确保面板有初始状态（可选，根据需求设置）
        if (targetUI != null)
        {
            // 默认隐藏面板（如果需要默认显示，改为true即可）
            targetUI.SetActive(false);
        }
        else
        {
            Debug.LogError("请在Inspector中给UIToggleController赋值targetUI！");
        }
    }

    /// <summary>
    /// 切换UI面板的显示/隐藏状态（绑定到按钮的点击事件）
    /// </summary>
    public void ToggleUI()
    {
        // 防止空引用错误
        if (targetUI == null)
        {
            Debug.LogError("targetUI未赋值！");
            return;
        }

        // 切换激活状态（显示→隐藏，隐藏→显示）
        bool isActive = targetUI.activeSelf;
        targetUI.SetActive(!isActive);
    }
}