using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider m_audioSlider;
    public float m_sliderValue;
    public Image m_notMutedImage;
    public Image m_MuteImage;


    // Start is called before the first frame update
    void Start()
    {
        m_audioSlider.value = PlayerPrefs.GetFloat("VolumeAudio", 0.5f);
        AudioListener.volume = m_audioSlider.value;
        CheckMute();
    }

    public void ChangeSlider(float p_value)
    {
        m_sliderValue = p_value;
        PlayerPrefs.SetFloat("VolumeAudio", m_sliderValue);
        AudioListener.volume = m_audioSlider.value;
        CheckMute();
    }
    
    public void CheckMute()
    {
        if (m_sliderValue == 0)
        {
            m_notMutedImage.enabled = false;
            m_MuteImage.enabled = true;
        }
        else
        {
            m_notMutedImage.enabled = true;
            m_MuteImage.enabled = false;
        }
    }
   
}
