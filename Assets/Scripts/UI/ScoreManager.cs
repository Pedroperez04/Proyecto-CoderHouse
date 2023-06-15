using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private float m_points;
    private TextMeshProUGUI m_text;
   


    private void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
       
        m_text.text = m_points.ToString("0");        

    }

    public void PlayerGetPoints(float p_takePoints)
    {
        m_points += p_takePoints;
    }

}
