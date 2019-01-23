using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EncounterTurnModel
{

    public event EventHandler<EncounterState> EncounterStateChanged;

    public EncounterState currentState;

    public enum EncounterState
    {
        ROUND_START,
        BEGIN,
        MAIN,
        COMBAT,
        END,
        ROUND_END,
        VICTORY,
        DEFEAT
    }

    public EncounterTurnModel()
    {
        
    }

    public void initialize() {
        currentState = EncounterState.ROUND_START;
        EncounterStateChanged(this, currentState);
    }

    private void onSetEncounterState(EncounterState state)
    {
        switch (state)
        {
            case EncounterState.ROUND_START:
                onRoundStart();
                break;
            case EncounterState.BEGIN:
                onBegin();
                break;
            case EncounterState.MAIN:
                onMain();
                break;
            case EncounterState.COMBAT:
                onCombat();
                break;
            case EncounterState.END:
                onEnd();
                break;
            case EncounterState.ROUND_END:
                onRoundEnd();
                break;
            case EncounterState.VICTORY:
                onVictory();
                break;
            case EncounterState.DEFEAT:
                onDefeat();
                break;
        }
    }

    public void advanceEncounterState()
    {
        switch (currentState)
        {
            case EncounterState.ROUND_START:
                onBegin();
                break;
            case EncounterState.BEGIN:
                onMain(); ;
                break;
            case EncounterState.MAIN:
                onCombat();
                break;
            case EncounterState.COMBAT:
                onEnd();
                break;
            case EncounterState.END:
                onRoundEnd();
                break;
            case EncounterState.ROUND_END:
                onRoundStart();
                break;
            case EncounterState.VICTORY:
                //TODO
                onDefeat();
                break;
            case EncounterState.DEFEAT:
                //TODO
                onRoundStart();
                break;
        }
    }

    private void onRoundStart()
    {
        currentState = EncounterState.ROUND_START;
        EncounterStateChanged(this, currentState);
    }

    private void onBegin()
    {
        currentState = EncounterState.BEGIN;
        EncounterStateChanged(this, currentState);
    }

    private void onMain()
    {
        currentState = EncounterState.MAIN;
        EncounterStateChanged(this, currentState);
    }

    private void onCombat()
    {
        currentState = EncounterState.COMBAT;
        EncounterStateChanged(this, currentState);
    }

    private void onEnd()
    {
        currentState = EncounterState.END;
        EncounterStateChanged(this, currentState);
    }

    private void onRoundEnd()
    {
        currentState = EncounterState.ROUND_END;
        EncounterStateChanged(this, currentState);
    }

    private void onVictory()
    {
        currentState = EncounterState.VICTORY;
        EncounterStateChanged(this, currentState);
    }

    private void onDefeat()
    {
        currentState = EncounterState.DEFEAT;
        EncounterStateChanged(this, currentState);
    }
}
