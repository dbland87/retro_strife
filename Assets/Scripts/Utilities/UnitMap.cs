using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMap : MonoBehaviour
{
    public GameObject dwarfHunterPrefab;
    public GameObject dwarfLordPrefab;
    public GameObject dwarfWarriorPrefab;
    public GameObject zombieWarriorPrefab;
    public GameObject abominationWtfUnit;

    public GameObject getPrefabFromId(int id) 
    {
        switch(id) 
        {
            case 1: return dwarfHunterPrefab;
            case 2: return dwarfLordPrefab;
            case 3: return dwarfWarriorPrefab;
            case 4: return zombieWarriorPrefab;
            default: 
            {
                Debug.Log("Could not find the prefab with the given prefab id: " + id);
                return abominationWtfUnit;
            }
        }
    }
}
