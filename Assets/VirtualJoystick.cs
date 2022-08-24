using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour,IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Image JoystickBackground;
    private Image JoystickController;
    private Vector2 touchPosition;

    private void Awake()
    {
        JoystickBackground = GetComponent<Image>();
        JoystickController = transform.GetChild(0).GetComponent<Image>();
    }

    /// <summary>
    /// ��ġ ���� �� 1ȸ
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    /// <summary>
    /// ��ġ ������ �� �� ������
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchPosition = Vector2.zero;
        
        // ���̽�ƽ�� ��ġ�� ��� �ֵ� ������ ���� �����ϱ� ����
        // touchPosition�� ��ġ ���� �̹����� ���� ��ġ�� ��������
        // �󸶳� ������ �ִ����� ���� �ٸ��� ���´�
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickBackground.rectTransform, eventData.position, eventData.pressEventCamera, out touchPosition))
        {
            // touchPosition ���� ����ȭ [0~1]
            // touchPosition�� �̹��� ũ��� ����
            touchPosition.x = (touchPosition.x / JoystickBackground.rectTransform.sizeDelta.x);
            touchPosition.y = (touchPosition.y / JoystickBackground.rectTransform.sizeDelta.y);

            // touchPosition ���� ����ȭ [-n ~ n]
            // ����(-1), �߽�(0), ������(1)�� �����ϱ� ���� touchPosition.x * 2 - 1
            // �Ʒ�(-1), �߽�(0), ��(1)�� �����ϱ� ���� touchPosition.y * 2 - 1
            // �� ������ Pivot�� ���� �޶�����. (���ϴ� Pivot ����)
            touchPosition = new Vector2(touchPosition.x * 2 - 1, touchPosition.y * 2 - 1);

            // touchPosition ���� ����ȭ [-1 ~ 1]
            // ���� ���̽�ƽ ��� �̹��� ������ ��ġ�� ������ �Ǹ� -1 ~ 1���� ū ���� ���� �� �ִ�
            // �� �� normailzed�� �̿��� -1 ~ 1 ������ ������ ����ȭ
            touchPosition = (touchPosition.magnitude > 1) ? touchPosition.normalized : touchPosition;

            JoystickController.rectTransform.anchoredPosition = new Vector2(
                touchPosition.x * JoystickBackground.rectTransform.sizeDelta.x / 2,
                touchPosition.y * JoystickBackground.rectTransform.sizeDelta.y / 2);

            
        }
        
    }

    /// <summary>
    /// ��ġ ���� �� 1ȸ
    /// </summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        JoystickController.rectTransform.anchoredPosition = Vector2.zero;
        touchPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        return touchPosition.x;
    }

    public float Vertical()
    {
        return touchPosition.y;
    }
}
