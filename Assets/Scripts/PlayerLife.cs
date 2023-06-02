using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] Animator m_animator;

    [SerializeField] private float m_life;
    [SerializeField] private float m_maxLife;
    [SerializeField] private LifeBar m_lifeBar;


    public EnemyBehavior m_enemyAttacks;
    private float m_enemyAttackDamage;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        m_enemyAttackDamage = m_enemyAttacks.m_enemyDamage;
        m_life = m_maxLife;
        m_lifeBar.InitializeLifeBar(m_life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAxe"))
        {
            StartCoroutine("IPlayerGetHitWait");
            TakeDamage(m_enemyAttackDamage);
        }

    }
    private void TakeDamage(float p_damage)
    {
        m_life -= p_damage;
        m_lifeBar.ChangeCurrentLife(m_life);
        if (m_life <= 0 )
        {
            StartCoroutine("IPlayerDeathWait");
        }
    }

    IEnumerator IPlayerGetHitWait()
    {
        m_animator.SetBool("GetHit", true);
        yield return new WaitForSeconds(0.2f);
        m_animator.SetBool("GetHit", false);
    }

    IEnumerator IPlayerDeathWait()
    {
        m_animator.SetBool("Death", true);
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
