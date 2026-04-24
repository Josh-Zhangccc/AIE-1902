using UnityEngine;

public class PhoneUIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject hudPanel;      // 左上角小手机按钮所在 HUD
    public GameObject phonePanel;    // 全屏手机界面

    [Header("Player")]
    public PlayerMovement playerMovement;  // 把角色的 PlayerMovement 拖进来

    void Start()
    {
        if (hudPanel != null) hudPanel.SetActive(true);
        if (phonePanel != null) phonePanel.SetActive(false);
    }

    // 小手机按钮调用
    public void OpenPhone()
    {
        if (hudPanel != null) hudPanel.SetActive(false);
        if (phonePanel != null) phonePanel.SetActive(true);

        // ★ 关键：锁定玩家移动
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
    }

    // 手机界面里的 Exit 按钮调用
    public void ClosePhone()
    {
        if (hudPanel != null) hudPanel.SetActive(true);
        if (phonePanel != null) phonePanel.SetActive(false);

        // ★ 关键：恢复玩家移动
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }
}

