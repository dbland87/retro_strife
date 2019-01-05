﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class EncounterController
{
    PlayerModel player { get; set; }

    EncounterTurnModel turnModel { get; set; }

    MainUIViewPresenter mainUI { get; set; }

    UnitPresenter unitPresenter { get; set; }

    UnitSpawner unitSpawner { get; set; }

    private int FIRST_PLAYER_POSITION = 0;
    private int FIRST_ENEMY_POSITION = 3;

    GameObject unitsObject;
    List<UnitModel> playerUnitsList;
    List<UnitModel> enemyUnitsList;

    public EncounterController()
    {
        mainUI = CreateView("MainUI").GetComponent<MainUIViewPresenter>();

        unitPresenter = GameObject.Find("Units").GetComponent<UnitPresenter>();

        // Create models
        turnModel = new EncounterTurnModel();
        player = new PlayerModel();

        // Wire up UI events
        mainUI.Clicked += (s, e) => onButtonClicked();
        turnModel.EncounterStateChanged += (s, e) => onEncounterTurnStateChanged(e);

    }

    public void initialize()
    {
        unitsObject = GameObject.Find("Units");
        playerUnitsList = unitsObject.GetComponent<Units>().playerUnits;
        enemyUnitsList = unitsObject.GetComponent<Units>().enemyUnits;
        unitSpawner = GameObject.Find("Unit Spawner").GetComponent<UnitSpawner>();    
        spawnUnits();
    }

    private void onEncounterTurnStateChanged(EncounterTurnModel.EncounterState state)
    { 
        switch(state)
        { 
           case EncounterTurnModel.EncounterState.ROUND_START:
                onRoundStart();
                break;
            case EncounterTurnModel.EncounterState.PLAYER_BEGIN:
                onPlayerBegin();
                break;
            case EncounterTurnModel.EncounterState.PLAYER_MAIN:
                onPlayerMain();
                break;
            case EncounterTurnModel.EncounterState.PLAYER_COMBAT:
                onPlayerCombat();
                break;
            case EncounterTurnModel.EncounterState.PLAYER_END:
                onPlayerEnd();
                break;
            case EncounterTurnModel.EncounterState.ENEMY_BEGIN:
                onEnemyBegin();
                break;
            case EncounterTurnModel.EncounterState.ENEMY_MAIN:
                onEnemyMain();
                break;
            case EncounterTurnModel.EncounterState.ENEMY_COMBAT:
                onEnemyCombat();
                break;
            case EncounterTurnModel.EncounterState.ENEMY_END:
                onEnemyEnd();
                break;
            case EncounterTurnModel.EncounterState.ROUND_END:
                onRoundEnd();
                break;
            case EncounterTurnModel.EncounterState.VICTORY:
                onVictory();
                break;
            case EncounterTurnModel.EncounterState.DEFEAT:
                onDefeat();
                break;
        }
    }

    private void spawnUnits()
    {

        if (unitsObject != null)
        {
            if (playerUnitsList != null && playerUnitsList.Count > 0)
            {
                int position = FIRST_PLAYER_POSITION;
                foreach (var unit in playerUnitsList)
                {
                    spawnUnitPrefab(unit, position);
                    position++;
                }
            }

            if (enemyUnitsList != null && enemyUnitsList.Count > 0)
            {
                int position = FIRST_ENEMY_POSITION;
                foreach (var unit in enemyUnitsList)
                {
                    spawnUnitPrefab(unit, position);
                    position++;
                }
            }
        }
    }

    private void spawnUnitPrefab(UnitModel unit, int position)
    {
        string unitName = Enum.GetName(typeof(UNIT_NAME), unit.id);
        switch(position)
        {
            case 0: unitPresenter.createPrefab(unitName, unitSpawner.firstPosition);
            break;
            case 1: unitPresenter.createPrefab(unitName, unitSpawner.secondPosition);
            break;
            case 2: unitPresenter.createPrefab(unitName, unitSpawner.thirdPosition);
            break;
            case 3: unitPresenter.createPrefab(unitName, unitSpawner.fourthPosition);
            break;
            case 4: unitPresenter.createPrefab(unitName, unitSpawner.fifthPosition);
            break;
            case 5: unitPresenter.createPrefab(unitName, unitSpawner.sixthPosition);
            break;
        }
    }

    private void onRoundStart()
    {
        Debug.Log("onRoundStart()");

    }

    private void onPlayerBegin()
    {
        Debug.Log("onPlayerBegin()");

    }

    private void onPlayerMain()
    {
        Debug.Log("onPlayerMain()");

    }

    private void onPlayerCombat()
    {
        Debug.Log("onPlayerCombat()");

    }

    private void onPlayerEnd()
    {
        Debug.Log("onPlayerEnd()");

    }

    private void onEnemyBegin()
    {
        Debug.Log("onEnemyBegin()");

    }

    private void onEnemyMain()
    {
        Debug.Log("onEnemyMain()");

    }

    private void onEnemyCombat()
    {
        Debug.Log("onEnemyCombat()");

    }

    private void onEnemyEnd()
    {
        Debug.Log("onEnemyEnd()");

    }

    private void onRoundEnd()
    {
        Debug.Log("onRoundEnd()");

    }

    private void onVictory()
    {
        Debug.Log("onVictory()");

    }

    private void onDefeat()
    {
        Debug.Log("onDefeat()");

    }

    private void onButtonClicked()
    {
        turnModel.advanceEncounterState();
    }

    GameObject CreateView(string viewName)
    { 
        return GameObject.Find(viewName);
    }
}


