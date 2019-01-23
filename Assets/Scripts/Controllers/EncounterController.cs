using System;
using System.Collections.Generic;
using UnityEngine;

public class EncounterController
{
    PlayerModel player { get; set; }
    EncounterModel encounterModel { get; set; }
    EncounterTurnModel turnModel { get; set; }
    MainUIViewPresenter mainUI { get; set; }
    PositionFinder positionFinder { get; set; }
    UnitController unitController { get; set; }

    public EncounterController()
    {
  
    }
    public void initialize()
    {
        mainUI = GameObject.Find("MainUI").GetComponent<MainUIViewPresenter>();
        turnModel = new EncounterTurnModel();
        encounterModel = new EncounterModel();
        positionFinder = GameObject.Find("PositionFinder").GetComponent<PositionFinder>();    
        unitController = new UnitController();

        // This needs to happen before we init the turn model
        initEvents();

        unitController.initialize();
        turnModel.initialize();

        
    }

    private void initEvents() 
    {
        turnModel.EncounterStateChanged += (s, e) => onEncounterTurnStateChanged(e);
        unitController.TurnStateCompleted += () => turnModel.advanceEncounterState();
        unitController.ActionsChosen += (e) => onActionsChosen(e);
    }

    private void onActionsChosen(UnitTurnModel chosenActions) 
    {
        encounterModel.saveTurn(chosenActions);
    }

    private void onEncounterTurnStateChanged(EncounterTurnModel.EncounterState state)
    { 
        switch(state)
        { 
           case EncounterTurnModel.EncounterState.ROUND_START:
                onRoundStart();
                break;
            case EncounterTurnModel.EncounterState.BEGIN:
                onTurnBegin();
                break;
            case EncounterTurnModel.EncounterState.MAIN:
                onTurnMain();
                break;
            case EncounterTurnModel.EncounterState.COMBAT:
                onTurnCombat();
                break;
            case EncounterTurnModel.EncounterState.END:
                onTurnEnd();
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
        unitController.setNextReadyUnitActive();    
    }

    private void onTurnBegin()
    {
        unitController.onUnitTurnBegin();
    }

    private void onTurnMain()
    {
        unitController.onUnitTurnMain();
    }

    private void onTurnCombat()
    {
        unitController.onUnitTurnCombat();
    }

    private void onTurnEnd()
    {
        unitController.onUnitTurnEnd();
    }

    private void onRoundEnd()
    {
        unitController.onRoundEnd();
    }

    private void onVictory()
    {

    }

    private void onDefeat()
    {

    }
}


