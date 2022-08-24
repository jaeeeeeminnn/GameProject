using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour,IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    /// <summary>
    /// ��ġ ���� �� 1ȸ
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Touch Begin : " + eventData);
    }

    /// <summary>
    /// ��ġ ������ �� �� ������
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Touch & Drag : " + eventData);
    }

    /// <summary>
    /// ��ġ ���� �� 1ȸ
    /// </summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Touch Ended : " + eventData);
    }
}
