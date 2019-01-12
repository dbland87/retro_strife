using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitController
{
    private int PLAYER_POSITIONS_START = 0;
    private int ENEMY_POSITIONS_START = 3;
    private int GAIN_READY_STATE_THRESHOLD = 10;
    private UnitIdGenerator idGenerator;
    PositionFinder positionFinder { get; set; }
    UnitPresenter unitPresenter { get; set; }
    GameObject unitsObject;
    List<UnitModel> playerUnits;
    List<UnitModel> enemyUnits;
    List<UnitModel> allUnits;

    public UnitController() 
    {
        initUnitLists();
        initUtilities();
    }

    public void initialize() 
    {
        spawnUnits();
    }

    private void initUnitLists() 
    {
        unitsObject = GameObject.Find("Units");
        unitPresenter = unitsObject.GetComponent<UnitPresenter>();
        playerUnits = unitsObject.GetComponent<UnitsRepository>().playerUnits;
        enemyUnits = unitsObject.GetComponent<UnitsRepository>().enemyUnits;
        allUnits = new List<UnitModel>();
        allUnits.AddRange(playerUnits);
        allUnits.AddRange(enemyUnits);
    }

    private void initUtilities()
    {
        positionFinder = GameObject.Find("PositionFinder").GetComponent<PositionFinder>();
        idGenerator = new UnitIdGenerator();
    }

    public void setNextReadyUnitActive() 
    {
        UnitModel activeUnit = getNextReadyUnit();
        unitPresenter.setActiveUnit(activeUnit);
    }

    private void spawnUnits()
    {
        if (playerUnits != null && playerUnits.Count > 0)
        {
            int positionId = PLAYER_POSITIONS_START;
            foreach (var unit in playerUnits)
            {
                unit.instanceId = idGenerator.getNewId();
                spawnUnit(unit, positionId);
                positionId++;
            }
        }

        if (enemyUnits != null && enemyUnits.Count > 0)
        {
            int positionId = ENEMY_POSITIONS_START;
            foreach (var unit in enemyUnits)
            {
                unit.instanceId = idGenerator.getNewId();
                spawnUnit(unit, positionId);
                positionId++;
            }
        }
    }

    private void spawnUnit(UnitModel unit, int positionId)
    {
        unitPresenter.instantiateUnit(unit, positionFinder.getVector2FromPositionId(positionId));
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
            Debug.Log("Could not find unit with id: " + id);
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
