﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    

    void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.LogWarning("Warning: multiple " + this + "s in scene!"); }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
