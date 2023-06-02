using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutZoneWall : MonoBehaviour
{
    public UnityEvent OnOutZone;

    public void OnCollisionEnter(Collision p_collision)
    {
        if (p_collision.gameObject.CompareTag("Player"))
        {
            OnOutZone.Invoke();
            Debug.Log(this);
        }
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OutzoneWallPlayer()
    {
        var m_findPlayer = GameObject.Find("Wizard");
        if (m_findPlayer != null)
        {
            Debug.Log("Leaving the zone");
        }

    }
}
