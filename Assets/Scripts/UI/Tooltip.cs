using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject uiElement;  // 拖入你希望显示的 UI 元素
    public Vector2 offset = new Vector2(-96, 48);  // 用来调整两个 UI 元素之间的间距，防止重叠
    private bool isMouseOver = false;

    void Start()
    {
        uiElement.SetActive(false);  // 将 UI 元素设置为不可见
    }

    void Update()
    {
        // 如果鼠标悬停在按钮上，跟随鼠标移动
        if (isMouseOver)
        {
            Vector2 mousePosition = Input.mousePosition;
            RectTransform uiRect = uiElement.GetComponent<RectTransform>();

            // 设置 UI 元素的位置，保持在鼠标的左上方并根据偏移量调整
            uiRect.position = mousePosition + offset;
        }
    }

    // 当鼠标悬停时调用
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isMouseOver)
        {
            isMouseOver = true;
            uiElement.SetActive(true);  // 显示 UI 元素
        }

        // 隐藏鼠标
        Cursor.visible = false;
    }

    // 当鼠标离开时调用
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isMouseOver)
        {
            isMouseOver = false;
            uiElement.SetActive(false);  // 隐藏 UI 元素
        }

        // 恢复鼠标显示
        Cursor.visible = true;
    }
}













