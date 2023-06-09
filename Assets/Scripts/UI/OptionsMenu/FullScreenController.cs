using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenController : MonoBehaviour
{
    public Toggle m_fullScreenToggle; 

    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            m_fullScreenToggle.isOn = true;
        }
        else
        {
            m_fullScreenToggle.isOn = false;
        }
    }

    public void ActiveFullScreen(bool p_fullScreen)
    {
        Screen.fullScreen = p_fullScreen;
    }
}
