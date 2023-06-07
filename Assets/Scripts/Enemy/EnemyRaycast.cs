using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    [SerializeField] private Transform m_raycastPoint;
    [SerializeField] private float m_raycastDistance = 10f;
    [SerializeField] private LayerMask m_raycastLayerMask;
    public bool m_blockedVision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            EnemyVisionRaycast();
    }

    public bool EnemyVisionRaycast()
    {
        Ray l_enemyRay = new Ray(m_raycastPoint.transform.position, m_raycastPoint.transform.forward);
        Debug.DrawRay(l_enemyRay.origin, l_enemyRay.direction * m_raycastDistance, Color.green);

        m_blockedVision = Physics.Raycast(l_enemyRay, out RaycastHit hit, m_raycastDistance, m_raycastLayerMask);
        if (m_blockedVision)
        {
            Debug.Log(m_blockedVision);
        }
        else
        {
            Debug.Log(m_blockedVision);
        }
        return m_blockedVision;
    }
}
