using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler,IPointerDownHandler
{

    //get drag info
    //get finger up info
    //store info as a vector2
    //let interested listeners know

    [SerializeField] RectTransform joystickKnobTransform;
    [SerializeField] float dragOffsetDistance;
    [SerializeField] float dragNormalizer;
    private Vector2 offset;
    private Vector2 startPosition;

    public event Action<Vector2> OnMoveInput;


    private void Start()
    {
        startPosition = joystickKnobTransform.anchoredPosition;
    }

    #region Interface implementations
    public void OnDrag(PointerEventData eventData)
    {
      //turn joystick anchored position to read from center of transform
      RectTransformUtility.ScreenPointToLocalPointInRectangle(
          joystickKnobTransform,
          eventData.position,
          null, out offset);

        offset = Vector2.ClampMagnitude(offset, dragNormalizer) / dragNormalizer;
      
        OnMoveInput?.Invoke(offset);
        offset = offset * dragOffsetDistance;
        joystickKnobTransform.anchoredPosition = offset;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        offset = startPosition;
        joystickKnobTransform.anchoredPosition = offset;
        OnMoveInput?.Invoke(offset);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }
    #endregion
}
