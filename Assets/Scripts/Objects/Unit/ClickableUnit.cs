using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableUnit : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    public event Action<Unit> Clicked;
    public event Action<Unit> Press;
    public event Action<Unit> Release;
    public event Action<Unit> PointerEnter;
    public event Action<Unit> PointerExit;

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked(this.GetComponent<Unit>());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Press(this.GetComponent<Unit>());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Release(this.GetComponent<Unit>());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnter(this.GetComponent<Unit>());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExit(this.GetComponent<Unit>());
    }

}
