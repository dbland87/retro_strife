using System;
using System.Collections.Generic;
using UnityEngine;

public class EncounterController
{
    PlayerModel player { get; set; }
    EncounterTurnModel turnModel { get; set; }
    MainUIViewPresenter mainUI { get; set; }
    PositionFinder positionFinder { get; set; }
    UnitController unitController { get; set; }

    public EncounterController()
    {
        mainUI = CreateView("MainUI").GetComponent<MainUIViewPresenter>();

        // Create models
        turnModel = new EncounterTurnModel();
        player = new PlayerModel();

        // Wire up UI events
        turnModel.EncounterStateChanged += (s, e) => onEncounterTurnStateChanged(e);

    }
    public void initialize()
    {
        positionFinder = GameObject.Find("PositionFinder").GetComponent<PositionFinder>();    
        unitController = new UnitController();

        unitController.initialize();
        turnModel.initialize();

        initEvents();
    }

    private void initEvents() 
    {
        unitController.TurnCompleted += (e) => onTurnCompleted(e);
    }

    private void onTurnCompleted(UnitTurnModel completedTurn) 
    {
        
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

    private void onRoundStart()
    {
        Debug.Log("onRoundStart()");
        unitController.setNextReadyUnitActive();

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


