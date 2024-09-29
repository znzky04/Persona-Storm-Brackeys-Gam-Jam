using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject uiElement;  // ������ϣ����ʾ�� UI Ԫ��
    public Vector2 offset = new Vector2(-96, 48);  // ������������ UI Ԫ��֮��ļ�࣬��ֹ�ص�
    private bool isMouseOver = false;

    void Start()
    {
        uiElement.SetActive(false);  // �� UI Ԫ������Ϊ���ɼ�
    }

    void Update()
    {
        // ��������ͣ�ڰ�ť�ϣ���������ƶ�
        if (isMouseOver)
        {
            Vector2 mousePosition = Input.mousePosition;
            RectTransform uiRect = uiElement.GetComponent<RectTransform>();

            // ���� UI Ԫ�ص�λ�ã��������������Ϸ�������ƫ��������
            uiRect.position = mousePosition + offset;
        }
    }

    // �������ͣʱ����
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isMouseOver)
        {
            isMouseOver = true;
            uiElement.SetActive(true);  // ��ʾ UI Ԫ��
        }

        // �������
        Cursor.visible = false;
    }

    // ������뿪ʱ����
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isMouseOver)
        {
            isMouseOver = false;
            uiElement.SetActive(false);  // ���� UI Ԫ��
        }

        // �ָ������ʾ
        Cursor.visible = true;
    }
}













