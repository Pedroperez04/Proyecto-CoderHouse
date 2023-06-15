using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {      
        m_defeatedEnemies = 0;
    }

    private void Update()
    {
        CheckScene();
    }

    private void CheckScene()
    {
        var p_scene = SceneManager.GetActiveScene().buildIndex;
        if (p_scene == 2)
        {
            m_defeatedEnemies = 0;
        }
    }
    

}
