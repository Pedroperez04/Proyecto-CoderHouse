using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int m_scorePoints;
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
        m_scorePoints = 0;       
        m_defeatedEnemies = 0;
    }


    public void PlayerScore(int p_killPoints)
    {
        m_scorePoints += p_killPoints;
        Debug.Log($"Total Points {m_scorePoints}");
    }
}
