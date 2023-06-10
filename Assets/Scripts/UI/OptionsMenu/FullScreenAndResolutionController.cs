using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreenAndResolutionController : MonoBehaviour
{
    public Toggle m_fullScreenToggle;
    public TMP_Dropdown m_resolutionDropdown;
    Resolution[] m_resols;

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
        CheckResolutions();
    }

    public void ActiveFullScreen(bool p_fullScreen)
    {
        Screen.fullScreen = p_fullScreen;
    }

    public void CheckResolutions()
    {
        m_resols = Screen.resolutions;
        m_resolutionDropdown.ClearOptions();
        List<string> l_options = new List<string>();
        int l_currentResolution = 0;

        for (int i = 0; i < m_resols.Length; i++)
        {
            string l_option = m_resols[i].width + "x" + m_resols[i].height;
            l_options.Add(l_option);

            if (Screen.fullScreen && m_resols[i].width == Screen.currentResolution.width && m_resols[i].height == Screen.currentResolution.height)
            {
                l_currentResolution = i;
            }
        }
        m_resolutionDropdown.AddOptions(l_options);
        m_resolutionDropdown.value = l_currentResolution;
        m_resolutionDropdown.RefreshShownValue();

        m_resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionNumber", 0);
    }

    public void ChangeResolution(int p_indResolution)
    {
        PlayerPrefs.SetInt("ResolutionNumber", m_resolutionDropdown.value);
        Resolution l_resolution = m_resols[p_indResolution];
        Screen.SetResolution(l_resolution.width, l_resolution.height,Screen.fullScreen);
    }

}
