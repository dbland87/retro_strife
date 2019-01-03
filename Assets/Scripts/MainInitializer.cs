using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInitializer : MonoBehaviour
{

    EncounterController Controller;

    // Start is called before the first frame update
    void Start()
    {
        Controller = new EncounterController();
        Controller.initialize();
    }

}
