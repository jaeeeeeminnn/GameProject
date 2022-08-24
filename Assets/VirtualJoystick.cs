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
    /// 터치 시작 시 1회
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    /// <summary>
    /// 터치 상태일 때 매 프레임
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchPosition = Vector2.zero;
        
        // 조이스틱의 위치가 어디에 있든 동일한 값을 연산하기 위해
        // touchPosition의 위치 값은 이미지의 현재 위치를 기준으로
        // 얼마나 떨어져 있는지에 따라 다르게 나온다
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickBackground.rectTransform, eventData.position, eventData.pressEventCamera, out touchPosition))
        {
            // touchPosition 값의 정규화 [0~1]
            // touchPosition을 이미지 크기로 나눔
            touchPosition.x = (touchPosition.x / JoystickBackground.rectTransform.sizeDelta.x);
            touchPosition.y = (touchPosition.y / JoystickBackground.rectTransform.sizeDelta.y);

            // touchPosition 값의 정규화 [-n ~ n]
            // 왼쪽(-1), 중심(0), 오른쪽(1)로 변경하기 위해 touchPosition.x * 2 - 1
            // 아래(-1), 중심(0), 위(1)로 변경하기 위해 touchPosition.y * 2 - 1
            // 이 수식은 Pivot에 따라 달라진다. (좌하단 Pivot 기준)
            touchPosition = new Vector2(touchPosition.x * 2 - 1, touchPosition.y * 2 - 1);

            // touchPosition 값의 정규화 [-1 ~ 1]
            // 가상 조이스틱 배경 이미지 밖으로 터치가 나가게 되면 -1 ~ 1보다 큰 값이 나올 수 있다
            // 이 때 normailzed을 이용해 -1 ~ 1 사이의 값으로 정규화
            touchPosition = (touchPosition.magnitude > 1) ? touchPosition.normalized : touchPosition;

            JoystickController.rectTransform.anchoredPosition = new Vector2(
                touchPosition.x * JoystickBackground.rectTransform.sizeDelta.x / 2,
                touchPosition.y * JoystickBackground.rectTransform.sizeDelta.y / 2);

            
        }
        
    }

    /// <summary>
    /// 터치 종료 시 1회
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
