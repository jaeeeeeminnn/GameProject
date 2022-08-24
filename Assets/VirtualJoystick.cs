using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour,IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    /// <summary>
    /// 터치 시작 시 1회
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Touch Begin : " + eventData);
    }

    /// <summary>
    /// 터치 상태일 때 매 프레임
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Touch & Drag : " + eventData);
    }

    /// <summary>
    /// 터치 종료 시 1회
    /// </summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Touch Ended : " + eventData);
    }
}
