using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitPresenter : MonoBehaviour
{

    public GameObject dwarfHunterPrefab;
    public GameObject dwarfLordPrefab;
    public GameObject dwarfWarriorPrefab;
    public GameObject zombieWarriorPrefab;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createPrefab(string name, Vector2 position)
    {
        UNIT_NAME _name;

        if (Enum.TryParse(name, out _name))
        {
            switch(_name)
            {
                case UNIT_NAME.DWARF_HUNTER:
                    Instantiate(dwarfHunterPrefab, position, Quaternion.identity);
                    break;
                case UNIT_NAME.DWARF_LORD:
                    Instantiate(dwarfLordPrefab, position, Quaternion.identity);
                    break;
                case UNIT_NAME.DWARF_WARRIOR:
                    Instantiate(dwarfWarriorPrefab, position, Quaternion.identity);
                    break;
                case UNIT_NAME.ZOMBIE_WARRIOR:
                    Instantiate(zombieWarriorPrefab, position, Quaternion.identity);
                    break;
            }
        }
    }
}
