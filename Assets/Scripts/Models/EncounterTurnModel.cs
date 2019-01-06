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
        PLAYER_BEGIN,
        PLAYER_MAIN,
        PLAYER_COMBAT,
        PLAYER_END,
        ENEMY_BEGIN,
        ENEMY_MAIN,
        ENEMY_COMBAT,
        ENEMY_END,
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
            case EncounterState.PLAYER_BEGIN:
                onPlayerBegin();
                break;
            case EncounterState.PLAYER_MAIN:
                onPlayerMain();
                break;
            case EncounterState.PLAYER_COMBAT:
                onPlayerCombat();
                break;
            case EncounterState.PLAYER_END:
                onPlayerEnd();
                break;
            case EncounterState.ENEMY_BEGIN:
                onEnemyBegin();
                break;
            case EncounterState.ENEMY_MAIN:
                onEnemyMain();
                break;
            case EncounterState.ENEMY_COMBAT:
                onEnemyCombat();
                break;
            case EncounterState.ENEMY_END:
                onEnemyEnd();
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
                onPlayerBegin();
                break;
            case EncounterState.PLAYER_BEGIN:
                onPlayerMain(); ;
                break;
            case EncounterState.PLAYER_MAIN:
                onPlayerCombat();
                break;
            case EncounterState.PLAYER_COMBAT:
                onPlayerEnd();
                break;
            case EncounterState.PLAYER_END:
                onEnemyBegin();
                break;
            case EncounterState.ENEMY_BEGIN:
                onEnemyMain();
                break;
            case EncounterState.ENEMY_MAIN:
                onEnemyCombat();
                break;
            case EncounterState.ENEMY_COMBAT:
                onEnemyEnd();
                break;
            case EncounterState.ENEMY_END:
                onRoundEnd();
                break;
            case EncounterState.ROUND_END:
                onVictory();
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

    private void onPlayerBegin()
    {
        currentState = EncounterState.PLAYER_BEGIN;
        EncounterStateChanged(this, currentState);
    }

    private void onPlayerMain()
    {
        currentState = EncounterState.PLAYER_MAIN;
        EncounterStateChanged(this, currentState);
    }

    private void onPlayerCombat()
    {
        currentState = EncounterState.PLAYER_COMBAT;
        EncounterStateChanged(this, currentState);
    }

    private void onPlayerEnd()
    {
        currentState = EncounterState.PLAYER_END;
        EncounterStateChanged(this, currentState);
    }

    private void onEnemyBegin()
    {
        currentState = EncounterState.ENEMY_BEGIN;
        EncounterStateChanged(this, currentState);
    }

    private void onEnemyMain()
    {
        currentState = EncounterState.ENEMY_MAIN;
        EncounterStateChanged(this, currentState);
    }

    private void onEnemyCombat()
    {
        currentState = EncounterState.ENEMY_COMBAT;
        EncounterStateChanged(this, currentState);
    }

    private void onEnemyEnd()
    {
        currentState = EncounterState.ENEMY_END;
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
