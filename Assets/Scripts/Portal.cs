using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public MeshRenderer m_portalRenderer;
    

    private void Awake()
    {
        m_portalRenderer.enabled = false;
        
    }

    public void SeePortal()
    {
        m_portalRenderer.enabled = true;
        Debug.Log(this);
    }
}
