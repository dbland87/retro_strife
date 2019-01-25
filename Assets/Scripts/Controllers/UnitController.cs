using System;
using System.Collections.Generic;
using UnityEngine;
using RSCommonModels;
using RSCombatEngine;

public class UnitController
{
    private int PLAYER_POSITIONS_START = 0;
    private int ENEMY_POSITIONS_START = 3;
    private int GAIN_READY_STATE_THRESHOLD = 10;
    private UnitIdGenerator idGenerator;
    private UnitModel currentUnit;
    private UnitTurnModel currentUnitTurn;
    PositionFinder positionFinder { get; set; }
    UnitPresenter unitPresenter { get; set; }
    UnitsRepository unitsRepository;
    public event Action<UnitTurnModel> ActionsChosen;
    public event Action TurnStateCompleted;

    public UnitController() 
    {
        initUnitLists();
        initUtilities();
        initEvents();
    }

    public void initialize() 
    {
        spawnUnits();
    }

    private void initUnitLists() 
    {
        unitsRepository = GameObject.Find("Units").GetComponent<UnitsRepository>();
        unitsRepository.initialize();
        unitPresenter = GameObject.Find("Units").GetComponent<UnitPresenter>();
    }

    private void initUtilities()
    {
        positionFinder = GameObject.Find("PositionFinder").GetComponent<PositionFinder>();
        idGenerator = new UnitIdGenerator();
    }

    private void initEvents() 
    {
        unitPresenter.UnitClicked += (e) => onUnitClicked(e);
        unitPresenter.ActionClicked += (e) => onActionClicked(e);
    }

    private void spawnUnits()
    {
        if (unitsRepository.playerUnits != null && unitsRepository.playerUnits.Count > 0)
        {
            int positionId = PLAYER_POSITIONS_START;
            foreach (var unit in unitsRepository.playerUnits)
            {
                unit.instanceId = idGenerator.getNewId();
                spawnUnit(unit, positionId);
                positionId++;
            }
        }

        if (unitsRepository.enemyUnits != null && unitsRepository.enemyUnits.Count > 0)
        {
            int positionId = ENEMY_POSITIONS_START;
            foreach (var unit in unitsRepository.enemyUnits)
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
        unit.UnitStateChange += (newState, instanceId) => onUnitStateChanged(newState, instanceId);
        unit.UnitDeath += (instanceId) => onUnitDeath(instanceId);
    }

    private void onUnitStateChanged(UnitState newState, string instanceId)
    {
        unitPresenter.displayNewUnitState(newState, instanceId);
    }

    private void onUnitDeath(string instanceId)
    {
        unitPresenter.displayUnitDeath(instanceId);
    }
    
    private void setNewTurn() 
    {
        if (currentUnitTurn != null) 
        {
            currentUnitTurn = null;
        }
        currentUnitTurn = new UnitTurnModel();
    }

    private void onUnitClicked(Unit unit)
    {
        Debug.Log("Target: " + unitsRepository.getUnitModelById(unit.id).name + "\nCurrent health: " + unitsRepository.getUnitModelById(unit.id).state.hp);
        currentUnitTurn.setTarget(unit);
        if(currentUnitTurn.isComplete()) 
        {
            ActionsChosen(currentUnitTurn);
            TurnStateCompleted();
        }
    }

    private void onActionClicked(UnitAction action)
    {
        currentUnitTurn.setAction(action);
        if(currentUnitTurn.isComplete()) 
        {
            ActionsChosen(currentUnitTurn);
            TurnStateCompleted();
        }
    }

    private void resolveActions(UnitTurnModel unitTurn) 
    {
        foreach(var unit in unitTurn.targets)
        {
            ActionResolver.resolve(unitTurn.actions, unitsRepository.getUnitModelById(unit.id));
        }
        setNewTurn();
    }

    private void resolveUpkeepEffects()
    {
        Debug.Log("Resolving upkeep items");
    }

    private void resolveTurnEndEffects()
    {
         Debug.Log("Resolving turn end items");
    }

    private void resolveRoundEndEffects()
    {
         Debug.Log("Resolving round end items");
    }

    public UnitModel findUnitById(int id) {
        if ( unitsRepository.allUnits.Exists(it => it.id == id)) 
        {
            return unitsRepository.allUnits.Find(it => it.id == id);
        } 
        else 
        {
            Debug.Log("Could not find unit with id: " + id);
            return null;
        }
    }

    public void setNextReadyUnitActive() 
    {
        setNewTurn();
        currentUnit = SpeedResolver.GetNextReadyUnit(unitsRepository.allUnits, GAIN_READY_STATE_THRESHOLD);
        TurnStateCompleted();
    }

    public void onUnitTurnBegin() 
    {
         resolveUpkeepEffects();
         TurnStateCompleted();
    }

    public void onUnitTurnMain()
    {
        unitPresenter.setActiveUnit(currentUnit);
    }

    public void onUnitTurnCombat()
    {
        resolveActions(currentUnitTurn);
        TurnStateCompleted();
    }

    public void onUnitTurnEnd()
    {
        resolveTurnEndEffects();
        TurnStateCompleted();
    }

    public void onRoundEnd()
    {
        resolveRoundEndEffects();
        TurnStateCompleted();
    }
}
