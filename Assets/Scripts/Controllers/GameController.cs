﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

//TODO this shouldn't extend monobehavior. Need a better initializer.
    private bool hasLoaded = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (!hasLoaded)
        {
            SceneManager.LoadScene("Encounter", LoadSceneMode.Single);
            hasLoaded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
