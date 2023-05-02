using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] Animator m_animator;
    [SerializeField] private float m_life;
    public EnemyAttacks m_enemyAttacks;
    private float m_enemyAttackDamage;

    // Start is called before the first frame update
    void Start()
    {
        m_enemyAttackDamage = m_enemyAttacks.m_enemyAttackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    private void OnCollisionEnter(Collision p_collision)
    {
        if (p_collision.gameObject.GetComponentInParent<EnemyAttacks>())
        {
            EnemyAttacks l_enemyAttacks = p_collision.gameObject.GetComponentInParent<EnemyAttacks>();
            if(l_enemyAttacks != null) 
            {
                TakeDamage(m_enemyAttackDamage);
            }
        }
    }
    private void TakeDamage(float p_damage)
    {
        m_life -= p_damage;
        if (m_life <= 0 )
        {
            Debug.Log("Death");
        }
    }
}
