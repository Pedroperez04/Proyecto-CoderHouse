using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public MeshRenderer m_portalRenderer;
    public MeshRenderer m_portalRenderer2; 
    public MeshCollider m_portalCollider;
    public SphereCollider m_portalCollider2;



    private void Awake()
    {
        m_portalRenderer.enabled = false;
        m_portalRenderer2.enabled = false;
        m_portalCollider.enabled = false;
        m_portalCollider2.enabled = false;
    }

    public void SeePortal()
    {
        m_portalRenderer.enabled = true;
        m_portalRenderer2.enabled = true;
        m_portalCollider.enabled = true;
        m_portalCollider2.enabled = true;
        Debug.Log(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1.0f;
        }
    }
}

