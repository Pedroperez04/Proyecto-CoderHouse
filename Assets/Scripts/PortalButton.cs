using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalButton : MonoBehaviour
{
    public UnityEvent OnPortalActivate;
    public SpawnManager m_rounds;
    public float m_gameRounds;
    public MeshRenderer m_renderer;
    public BoxCollider m_collider;


    private void Awake()
    {
        m_gameRounds = m_rounds.m_wave;
        m_renderer.enabled = false;
        m_collider.enabled = false;

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPortalActivate.Invoke();
            Debug.Log(this);
        }
       
    }

    private void Update()
    {
        m_gameRounds = m_rounds.m_wave;
        if (m_gameRounds == 6) 
        {
            m_renderer.enabled = true;
            m_collider.enabled = true;            
        }
    }



}
