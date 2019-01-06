﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPresenter : MonoBehaviour
{
    public GameObject dwarfHunterPrefab;
    public GameObject dwarfLordPrefab;
    public GameObject dwarfWarriorPrefab;
    public GameObject zombieWarriorPrefab;

    public GameObject actionButton;
    public GameObject uiCanvas;
    // Start is called before the first frame update
    void awake() {
        uiCanvas = GameObject.Find("UICanvas");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createPrefab(string name, Vector2 position)
    {
        UNIT_NAME _name;

        if (Enum.TryParse(name, out _name))
        {
            switch(_name)
            {
                case UNIT_NAME.DWARF_HUNTER:
                    Instantiate(dwarfHunterPrefab, position, Quaternion.identity);
                    break;
                case UNIT_NAME.DWARF_LORD:
                    Instantiate(dwarfLordPrefab, position, Quaternion.identity);
                    break;
                case UNIT_NAME.DWARF_WARRIOR:
                    Instantiate(dwarfWarriorPrefab, position, Quaternion.identity);
                    break;
                case UNIT_NAME.ZOMBIE_WARRIOR:
                    Instantiate(zombieWarriorPrefab, position, Quaternion.identity);
                    break;
            }
        }
    }

    private void displayUnitActions(List<UnitAction> actions) {
        foreach (var action in actions) {
            GameObject go = Instantiate(actionButton);
            // Button button = go.GetComponent<Button>();
            go.transform.SetParent(uiCanvas.transform, false);
            // go.onClick.AddListener(() => Debug.Log(action.name));
        }
    }

    public void onActionButtonClicked() {
        Debug.Log("Clicked");
    }

    public void setActiveUnit(UnitModel unit) {
        Debug.Log("Active unit: " + unit.name);
        displayUnitActions(unit.actions);
    }
}