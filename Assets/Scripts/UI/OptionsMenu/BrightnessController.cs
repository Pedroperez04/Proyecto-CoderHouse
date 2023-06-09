using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    public Slider m_brightnessSlider;
    public float m_brightnessValue;
    public Image m_brightnessPanel;

    // Start is called before the first frame update
    void Start()
    {
        m_brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 0.5f);
        m_brightnessPanel.color = new Color(m_brightnessPanel.color.r, m_brightnessPanel.color.g, m_brightnessPanel.color.b, m_brightnessSlider.value);
    }

    public void ChangeSlider(float p_value)
    {
        m_brightnessValue = p_value;
        PlayerPrefs.SetFloat("Brightness", m_brightnessValue);
        m_brightnessPanel.color = new Color(m_brightnessPanel.color.r, m_brightnessPanel.color.g, m_brightnessPanel.color.b, m_brightnessSlider.value);
    }
}
