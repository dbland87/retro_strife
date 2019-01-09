using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitController
{
    private int PLAYER_POSITIONS_START = 0;
    private int ENEMY_POSITIONS_START = 3;
    private int GAIN_READY_STATE_THRESHOLD = 10;
    PositionFinder positionFinder { get; set; }
    UnitPresenter unitPresenter { get; set; }
    GameObject unitsObject;
    List<UnitModel> playerUnits;
    List<UnitModel> enemyUnits;

    public UnitController() 
    {
        unitsObject = GameObject.Find("Units");
        unitPresenter = unitsObject.GetComponent<UnitPresenter>();
        playerUnits = unitsObject.GetComponent<UnitsRepository>().playerUnits;
        enemyUnits = unitsObject.GetComponent<UnitsRepository>().enemyUnits;
        positionFinder = GameObject.Find("PositionFinder").GetComponent<PositionFinder>();
    }

    public void initialize() 
    {
        spawnUnits();
    }

    public void onRoundStart() 
    {
        UnitModel activeUnit = getNextReadyUnit();
        unitPresenter.setActiveUnit(activeUnit);
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
            case 0: 
            unitPresenter.createPrefab(unitName, positionFinder.firstPosition);
            break;
            case 1: 
            unitPresenter.createPrefab(unitName, positionFinder.secondPosition);
            break;
            case 2: 
            unitPresenter.createPrefab(unitName, positionFinder.thirdPosition);
            break;
            case 3: 
            unitPresenter.createPrefab(unitName, positionFinder.fourthPosition);
            break;
            case 4: 
            unitPresenter.createPrefab(unitName, positionFinder.fifthPosition);
            break;
            case 5: 
            unitPresenter.createPrefab(unitName, positionFinder.sixthPosition);
            break;
        }
    }

    private void incrementInitiative(List<UnitModel> units) {
        foreach(var unit in units) {
            unit.state.initiative += unit.resolvedSpeed();
        }
    }

    private List<UnitModel> getAllUnits() {
        List<UnitModel> allUnits = new List<UnitModel>();
        allUnits.AddRange(playerUnits);
        allUnits.AddRange(enemyUnits);
        return allUnits;
    }

    public UnitModel findUnitById(int id) {
        if ( getAllUnits().Exists(it => it.id == id)) 
        {
            return getAllUnits().Find(it => it.id == id);
        } 
        else 
        {
            return null;
        }
    }

    public UnitModel getNextReadyUnit() 
    {
        List<UnitModel> allUnits = getAllUnits();

        while(allUnits.FindAll(it => it.state.initiative >= GAIN_READY_STATE_THRESHOLD).Count < 1) 
        {
            incrementInitiative(allUnits);
            allUnits.Sort((x, y) => y.state.initiative.CompareTo(x.state.initiative));
        }

        int max = allUnits[0].state.initiative;
        if (allUnits.FindAll(it => it.state.initiative == max).Count == 1) {
            allUnits[0].state.initiative =- GAIN_READY_STATE_THRESHOLD;
            return allUnits[0];
        } else {
            System.Random rnd = new System.Random();
            int tiebreaker = rnd.Next(
                allUnits.FindAll(it=>it.state.initiative == max).Count);
            allUnits[tiebreaker].state.initiative =- GAIN_READY_STATE_THRESHOLD;
            return allUnits[tiebreaker];
        }
    }


}
