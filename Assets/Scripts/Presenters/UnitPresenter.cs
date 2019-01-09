using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPresenter : MonoBehaviour
{
    public GameObject dwarfHunterPrefab;
    public GameObject dwarfLordPrefab;
    public GameObject dwarfWarriorPrefab;
    public GameObject zombieWarriorPrefab;
    public Dictionary<string, GameObject> spawnedUnits = new Dictionary<string, GameObject>();
    public GameObject actionButton;
    public GameObject uiCanvas;
    // Start is called before the first frame update
    void awake() {
        
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
            //TODO
            switch(_name)
            {
                case UNIT_NAME.DWARF_HUNTER:
                    spawnUnit(dwarfHunterPrefab, position, name);
                    break;
                case UNIT_NAME.DWARF_LORD:
                    spawnUnit(dwarfLordPrefab, position, name);
                    break;
                case UNIT_NAME.DWARF_WARRIOR:
                    spawnUnit(dwarfWarriorPrefab, position, name);
                    break;
                case UNIT_NAME.ZOMBIE_WARRIOR:
                    spawnUnit(zombieWarriorPrefab, position, name);
                    break;
            }
        }
    }

    private void spawnUnit(GameObject prefab, Vector2 position, string name) 
    {
        GameObject unit = Instantiate(prefab, position, Quaternion.identity);
        spawnedUnits[name] = unit;
        unit.GetComponent<BaseUnit>().Clicked += (e) => onUnitClicked(e);
    }

    private void displayUnitActions(List<UnitAction> actions) {
        if (uiCanvas == null) {
            uiCanvas = GameObject.Find("UICanvas");
        }
        foreach (var action in actions) {
            GameObject buttonObject = Instantiate(actionButton);            
            buttonObject.transform.SetParent(uiCanvas.transform, false);
            buttonObject.GetComponent<Button>().onClick.AddListener(() => Debug.Log(action.name));
        }
    }

    private void onUnitClicked(int id) 
    {
        Debug.Log("Clicked: " + id);
    }

    public void onActionButtonClicked() 
    {
        Debug.Log("Clicked");
    }

    public void setActiveUnit(UnitModel unit) 
    {
        Debug.Log("Active unit: " + unit.name);
        displayUnitActions(unit.actions);
    }
}
