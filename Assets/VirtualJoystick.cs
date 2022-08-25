using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour,IPointerDownHandler, IPointerUpHandler,IDragHandler
{
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_Joystick;

    private float radius;

    [SerializeField] private GameObject go_Player;
    [SerializeField] private float moveSpeed;

    private bool isTouch = false;
    private Vector3 movePosition;

    void Start()
    {
        radius = rect_Background.rect.width * 0.5f;
    }

    void Update()
    {
        if (isTouch)
            go_Player.transform.position += movePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_Background.position;

        value = Vector2.ClampMagnitude(value, radius);
        rect_Joystick.localPosition = value;

        value = value.normalized;
        movePosition = new Vector3 (value.x * moveSpeed * Time.deltaTime, 0f, value.y * moveSpeed * Time.deltaTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch= false;
        rect_Joystick.localPosition = Vector2.zero;
    }
}
