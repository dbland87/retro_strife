using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseUnit : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    public event Action<int> Clicked;
    public event Action<int> Press;
    public event Action<int> Release;
    public event Action<int> PointerEnter;
    public event Action<int> PointerExit;

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked(eventData.pointerCurrentRaycast.gameObject.GetComponent<Identity>().unitId);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Press(eventData.pointerCurrentRaycast.gameObject.GetComponent<Identity>().unitId);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Release(eventData.pointerCurrentRaycast.gameObject.GetComponent<Identity>().unitId);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // PointerEnter(eventData.pointerCurrentRaycast.gameObject.GetComponent<Identity>().unitId);   
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // PointerExit(eventData.pointerCurrentRaycast.gameObject.GetComponent<Identity>().unitId);
    }

}
