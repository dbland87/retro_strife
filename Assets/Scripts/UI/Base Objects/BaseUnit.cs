using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseUnit : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    // public event Action<string> Click;
    public event Action<int> Clicked;
    public event Action<int> Press;
    public event Action<int> Release;
    public event Action<int> PointerEnter;
    public event Action<int> PointerExit;

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked(1);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Press(eventData.pointerCurrentRaycast.gameObject.GetComponent<Identity>().id);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Release(eventData.pointerCurrentRaycast.gameObject.GetComponent<Identity>().id);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnter(eventData.pointerCurrentRaycast.gameObject.GetComponent<Identity>().id);   
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExit(eventData.pointerCurrentRaycast.gameObject.GetComponent<Identity>().id);
    }

}
