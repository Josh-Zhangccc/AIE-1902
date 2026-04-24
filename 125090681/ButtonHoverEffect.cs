using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float normalScale = 1f;
    public float hoverScale = 1.2f;
    public float animationSpeed = 0.2f;

    private Vector3 targetScale;
    private RectTransform _myRect; // 修改了变量名，彻底避免冲突

    void Start()
    {
        // 获取组件
        _myRect = GetComponent<RectTransform>();
        targetScale = Vector3.one * normalScale;
    }

    void Update()
    {
        // 平滑缩放
        if (_myRect != null)
        {
            _myRect.localScale = Vector3.Lerp(_myRect.localScale, targetScale, Time.deltaTime / animationSpeed);
        }
    }

    // 鼠标进入
    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = Vector3.one * hoverScale;
    }

    // 鼠标离开
    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = Vector3.one * normalScale;
    }
}