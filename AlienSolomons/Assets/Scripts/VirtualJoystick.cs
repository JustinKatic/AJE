using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image _bgImg;
    private Image _joystickImg;


    public Vector3 InputDirection { set; get; }


    // Start is called before the first frame update
    private void Start()
    {
        _bgImg = GetComponent<Image>();
        _joystickImg = transform.GetChild(0).GetComponent<Image>();
        InputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (_bgImg.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out pos))
        {
            pos.x = (pos.x / _bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _bgImg.rectTransform.sizeDelta.y);

            float x = (_bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (_bgImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            InputDirection = new Vector3(x, 0, y);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

            _joystickImg.rectTransform.anchoredPosition =
                new Vector3(InputDirection.x * (_bgImg.rectTransform.sizeDelta.x / 3),
                InputDirection.z * (_bgImg.rectTransform.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector3.zero;
        _joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }
}
