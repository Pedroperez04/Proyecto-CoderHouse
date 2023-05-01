using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypes : MonoBehaviour
{
    [SerializeField] private Transform m_playerTarget;
    [SerializeField] private float m_distanceToChase = 10f;
    [SerializeField] private float m_enemySpeed = 50f;
    [SerializeField] private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }
    private void Move(Vector3 p_direction)
    {
        transform.position += p_direction * (m_enemySpeed * Time.deltaTime);
    }
    private void Chase()
    {
        var l_diffVector = m_playerTarget.position - transform.position;
        Quaternion l_newRotation = Quaternion.LookRotation(l_diffVector.normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, l_newRotation, m_enemySpeed * Time.deltaTime);
        if(m_distanceToChase > l_diffVector.magnitude && 2 < l_diffVector.magnitude) 
        {
            Move(l_diffVector.normalized);
            m_animator.SetBool("Run", true);
        }
        else { m_animator.SetBool("Run",false); }
    }

}
