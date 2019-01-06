using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitModel
{

    public UnitModel() {
        this.state = new UnitState();
    }
    
    public int id { get; set; }
    public string name { get; set; }
    public int level { get; set; }
    public int hp { get; set; }
    public int speed { get; set; }
    public int def { get; set; }
    public int attack { get; set; }
    public UnitState state { get; set; }
    public int resolvedSpeed()
    {
        return speed + state.speed;
    }
}

public class UnitState {
    public int speed { get; set; }
    public int initiative { get; set; }
}
