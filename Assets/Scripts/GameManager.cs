using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int m_defeatedEnemies;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {      
        m_defeatedEnemies = 0;
    }


    
}
