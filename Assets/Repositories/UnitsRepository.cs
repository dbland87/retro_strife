using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSCommonLib;
public class UnitsRepository : MonoBehaviour
{
    public List<UnitModel> playerUnits = new List<UnitModel>();
    public List<UnitModel> enemyUnits = new List<UnitModel>();
    public List<UnitModel> allUnits = new List<UnitModel>();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void initialize() 
    {
        initTempUnits();
        initUnitLists();
    }

    private void initUnitLists() 
    {
        allUnits = new List<UnitModel>();
        allUnits.AddRange(playerUnits);
        allUnits.AddRange(enemyUnits);
    }

    public UnitModel getUnitModelById(string id)
    {
        if (allUnits.Exists(it => it.instanceId == id))
        {
            return allUnits.Find(it => it.instanceId == id);
        }
        Debug.Log("Can't find the unit by the specified id: " + id);
        return null;
    }

    //TEMP stuff
    private void initTempUnits()
    {
        UnitModel playerUnit1 = new UnitModel();
        playerUnit1.id = 0;
        playerUnit1.prefabId = 1;
        playerUnit1.name = "Dwarfy";
        playerUnit1.level = 3;
        playerUnit1.hp = 100;
        playerUnit1.speed = 5;
        playerUnit1.def = 5;
        playerUnit1.attack = 5;
        playerUnit1.actions.Add(
            new UnitAction(1, -1, "AutoAttack", 10, UnitAction.ActionType.PHYSICAL_ATTACK)
            );
        playerUnit1.initState();

        UnitModel playerUnit2 = new UnitModel();
        playerUnit2.id = 1;
        playerUnit2.prefabId = 2;
        playerUnit2.name = "Gimli";
        playerUnit2.level = 3;
        playerUnit2.hp = 100;
        playerUnit2.speed = 4;
        playerUnit2.def = 5;
        playerUnit2.attack = 5;
        playerUnit2.actions.Add(
            new UnitAction(1, -1, "AutoAttack", 10, UnitAction.ActionType.PHYSICAL_ATTACK)
            );
        playerUnit2.initState();

        UnitModel playerUnit3 = new UnitModel();
        playerUnit3.id = 2;
        playerUnit3.prefabId = 3;
        playerUnit3.name = "Fart";
        playerUnit3.level = 3;
        playerUnit3.hp = 100;
        playerUnit3.speed = 5;
        playerUnit3.def = 5;
        playerUnit3.attack = 5;
        playerUnit3.actions.Add(
            new UnitAction(1, -1, "AutoAttack", 10, UnitAction.ActionType.PHYSICAL_ATTACK)
            );
        playerUnit3.initState();

        UnitModel enemyUnit1 = new UnitModel();
        enemyUnit1.id = 3;
        enemyUnit1.prefabId = 4;
        enemyUnit1.name = "Steve";
        enemyUnit1.level = 3;
        enemyUnit1.hp = 100;
        enemyUnit1.speed = 5;
        enemyUnit1.def = 5;
        enemyUnit1.attack = 5;
        enemyUnit1.actions.Add(
            new UnitAction(1, -1, "AutoAttack", 10, UnitAction.ActionType.PHYSICAL_ATTACK)
            );
        enemyUnit1.initState();

        UnitModel enemyUnit2 = new UnitModel();
        enemyUnit2.id = 4;
        enemyUnit2.prefabId = 4;
        enemyUnit2.name = "Starfox";
        enemyUnit2.level = 3;
        enemyUnit2.hp = 100;
        enemyUnit2.speed = 2;
        enemyUnit2.def = 5;
        enemyUnit2.attack = 5;
        enemyUnit2.actions.Add(
            new UnitAction(1, -1, "AutoAttack", 10, UnitAction.ActionType.PHYSICAL_ATTACK)
            );
        enemyUnit2.initState();

        playerUnits.Add(playerUnit1);
        playerUnits.Add(playerUnit2);
        playerUnits.Add(playerUnit3);

        enemyUnits.Add(enemyUnit1);
        enemyUnits.Add(enemyUnit2);
    }

}
