using System;
using System.Collections.Generic;
using RSCommonModels;

public class UnitTurnModel 
{   
    public List<Unit> targets { get; set; }
    public List<UnitAction> actions { get; set; }

    public UnitTurnModel() 
    {
        targets = new List<Unit>();
        actions = new List<UnitAction>();
    }

    public void addTarget(Unit target) 
    {
        targets.Add(target);
    }

    public void setTarget(Unit target)
    {
        targets.Clear();
        targets.Add(target);
    }

    public void addAction(UnitAction action) 
    {
        actions.Add(action);
    }

    public void setAction(UnitAction action)
    {
        actions.Clear();
        actions.Add(action);
    }

    public bool isComplete() 
    {
        return targets.Count > 0 && actions.Count > 0;
    }
}