using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterController
{
    PlayerModel player { get; set; }

    EncounterTurnModel turnModel { get; set; }

    MainUIViewPresenter mainUI { get; set; }

    GameObject unitsObject;
    List<UnitModel> playerUnitsList;
    List<UnitModel> enemyUnitsList;

    public EncounterController()
    {
        mainUI = CreateView("MainUI").GetComponent<MainUIViewPresenter>();

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
                foreach (var unit in playerUnitsList)
                {
                    spawnUnitPrefab(unit.id);
                }
            }
        }
    }

    private void spawnUnitPrefab(int id)
    {
        switch(id)
        {
            case 1:
                mainUI.createPrefab("dwarf_hunter");
                break;
            case 2:
                mainUI.createPrefab("dwarf_lord");
                break;
            case 3:
                mainUI.createPrefab("dwarf_warrior");
                break;
            case 4:
                mainUI.createPrefab("zombie_warrior");
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
        return GameObject.Find("MainUI");
    }
}


