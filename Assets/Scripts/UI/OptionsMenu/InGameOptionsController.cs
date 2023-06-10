using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameOptionsController : MonoBehaviour
{
    public OptionsManager m_optionsManager;

    // Start is called before the first frame update
    void Start()
    {
        m_optionsManager = GameObject.FindGameObjectWithTag("GlobalOptions").GetComponent<OptionsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowOptionsInGame()
    {

        m_optionsManager.m_screenOptions.SetActive(true);
    }
}
