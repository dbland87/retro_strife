using System.Collections;
using System.Collections.Generic;
using System;
using System.Configuration;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPresenterEventArgs : System.EventArgs
{
    public Vector3 MousePosition { get; private set; }

    public ButtonPresenterEventArgs(Vector2 mousePosition)
    {
        MousePosition = mousePosition;
    }

}

public class MainUIViewPresenter : MonoBehaviour
{ 

    public event EventHandler<ButtonPresenterEventArgs> Clicked;


    // Start is called before the first frame update
    void Start()
    {
        //TestButton.onClick.AddListener(() => OnButtonClicked());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    protected virtual void OnButtonClicked()
    {
        Clicked(this, new ButtonPresenterEventArgs(Input.mousePosition));    
    }
}
