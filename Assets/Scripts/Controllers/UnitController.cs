using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitController
{
    private int PLAYER_POSITIONS_START = 0;
    private int ENEMY_POSITIONS_START = 3;
    PositionController positionController { get; set; }
    UnitPresenter unitPresenter { get; set; }
    GameObject unitsObject;
    List<UnitModel> playerUnits;
    List<UnitModel> enemyUnits;

    public UnitController() 
    {
        unitsObject = GameObject.Find("Units");
        unitPresenter = unitsObject.GetComponent<UnitPresenter>();
        playerUnits = unitsObject.GetComponent<Units>().playerUnits;
        enemyUnits = unitsObject.GetComponent<Units>().enemyUnits;
        positionController = GameObject.Find("PositionController").GetComponent<PositionController>();
    }

    public void initialize() {
        spawnUnits();
    }

    private void spawnUnits()
    {
        if (playerUnits != null && playerUnits.Count > 0)
        {
            int position = PLAYER_POSITIONS_START;
            foreach (var unit in playerUnits)
            {
                spawnUnitPrefab(unit, position);
                position++;
            }
        }

        if (enemyUnits != null && enemyUnits.Count > 0)
        {
            int position = ENEMY_POSITIONS_START;
            foreach (var unit in enemyUnits)
            {
                spawnUnitPrefab(unit, position);
                position++;
            }
        }
    }

    private void spawnUnitPrefab(UnitModel unit, int position)
    {
        string unitName = Enum.GetName(typeof(UNIT_NAME), unit.id);
        switch(position)
        {
            case 0: unitPresenter.createPrefab(unitName, positionController.firstPosition);
            break;
            case 1: unitPresenter.createPrefab(unitName, positionController.secondPosition);
            break;
            case 2: unitPresenter.createPrefab(unitName, positionController.thirdPosition);
            break;
            case 3: unitPresenter.createPrefab(unitName, positionController.fourthPosition);
            break;
            case 4: unitPresenter.createPrefab(unitName, positionController.fifthPosition);
            break;
            case 5: unitPresenter.createPrefab(unitName, positionController.sixthPosition);
            break;
        }
    }

}
