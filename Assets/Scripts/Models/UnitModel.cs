using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitModel
{

    public UnitModel() {
        this.state = new UnitState();
        this.actions = new List<UnitAction>();
    }
    
    public int id { get; set; }
    public int prefabId { get; set; }
    public string instanceId { get; set; }
    public string name { get; set; }
    public int level { get; set; }
    public int hp { get; set; }
    public int speed { get; set; }
    public int def { get; set; }
    public int attack { get; set; }
    public UnitState state { get; set; }
    public List<UnitAction> actions { get; set; }
    public int resolvedSpeed()
    {
        return speed + state.speed;
    }
}

public class UnitState {
    public int speed { get; set; }
    public int initiative { get; set; }
    public int encounterPosition { get; set; }
}

public class UnitAction {

    public UnitAction(int _id, int _targetId, string _name, int _amount, ActionType _type) {
        id = _id;
        targetId = _targetId;
        name = _name;
        amount = _amount;
        type = _type;
    }
    public int id { get; set; }
    public int targetId { get; set; }
    public string name { get; set; }
    public int amount { get; set; }
    public ActionType type { get; set; }
    public enum ActionType {
        PHYSICAL_ATTACK,
        MAGIC_ATTACK,
        STAT_MODIFIER,
        HEAL,
        SHIELD
    }
}
