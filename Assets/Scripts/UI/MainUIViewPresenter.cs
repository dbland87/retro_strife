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

    public GameObject dwarfHunterPrefab;
    public GameObject dwarfLordPrefab;
    public GameObject dwarfWarriorPrefab;
    public GameObject zombieWarriorPrefab;

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

    public void createPrefab(string name)
    {
        switch (name)
        {
            case "dwarf_hunter":
                Instantiate(dwarfHunterPrefab);
                break;
            case "dwarf_lord":
                Instantiate(dwarfLordPrefab);
                break;
            case "dwarf_warrior":
                Instantiate(dwarfWarriorPrefab);
                break;
            case "zombie_warrior":
                Instantiate(zombieWarriorPrefab);
                break;
        }
    }

    protected virtual void OnButtonClicked()
    {
        Clicked(this, new ButtonPresenterEventArgs(Input.mousePosition));    
    }
}
