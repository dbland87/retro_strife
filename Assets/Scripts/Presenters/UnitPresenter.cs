using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPresenter : MonoBehaviour
{

    private UnitMap unitMap;
    public GameObject actionButton;
    public GameObject uiCanvas;

    private void initUnitMap() 
    {
        unitMap = GameObject.Find("Units").GetComponent<UnitMap>();
    }

    public void instantiateUnit(UnitModel unit, Vector2 position)
    {
        if (unitMap == null) {
            initUnitMap();
        }
        
        GameObject instance = Instantiate(unitMap.getPrefabFromId(unit.prefabId), position, Quaternion.identity);
        instance.GetComponent<Unit>().id = unit.instanceId;
        instance.GetComponent<ClickableUnit>().Clicked += (e) => onUnitClicked(e);
        instance.GetComponent<ClickableUnit>().Press += (e) => onUnitPressed(e);
        instance.GetComponent<ClickableUnit>().Release += (e) => onUnitReleased(e);
        instance.GetComponent<ClickableUnit>().PointerEnter += (e) => onUnitPointerEnter(e);
        instance.GetComponent<ClickableUnit>().PointerExit += (e) => onUnitPointerExit(e);
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

    private void onUnitClicked(Unit unit) 
    {
        Debug.Log("Clicked: " + unit.id);
    }

        private void onUnitPressed(Unit unit) 
    {
        //TODO
    }

        private void onUnitReleased(Unit unit) 
    {
        //TODO
    }

        private void onUnitPointerEnter(Unit unit) 
    {
        //TODO
    }

        private void onUnitPointerExit(Unit unit) 
    {
        //TODO
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
