using System;
using System.Collections.Generic;
using RSCommonLib.Models;
using UnityEngine;

public class EncounterModel
{
    Queue<RSUnitTurnModel> turns = new Queue<RSUnitTurnModel>();

    public void saveTurn(RSUnitTurnModel turnModel)
    {
        turns.Enqueue(turnModel);
    }

}