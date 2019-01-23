using System;
using System.Collections.Generic;
using UnityEngine;

public class EncounterModel
{
    Queue<UnitTurnModel> turns = new Queue<UnitTurnModel>();

    public void saveTurn(UnitTurnModel turnModel)
    {
        turns.Enqueue(turnModel);
    }

}