using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Slider m_slider;

    private void Start()
    {
       
    }

    public void ChangeMaxLife(float p_maxLife)
    {
        m_slider.maxValue = p_maxLife;
    }

    public void ChangeCurrentLife(float p_life)
    {
        m_slider.value = p_life;
    }

    public void InitializeLifeBar(float p_life)
    {
        m_slider = GetComponent<Slider>();
        ChangeMaxLife(p_life);
        ChangeCurrentLife(p_life);
    }
}
