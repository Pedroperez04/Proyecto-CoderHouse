using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] Animator m_animator;

    [SerializeField] public float m_life;
    [SerializeField] private float m_maxLife;
    [SerializeField] private LifeBar m_lifeBar;
    [SerializeField] private float m_heal = 2f;
    private float m_healCooldown = 10f;
    private float m_healTime;
    
    public EnemyBehavior m_enemyAttacks;
    private float m_enemyAttackDamage;

    public Action<float> OnDamageEvent;
    public Action<float> OnHealEvent;

    public event EventHandler m_OnPlayerDeath;


    private void Awake()
    {
        OnDamageEvent += TakeDamage;
        OnHealEvent += GetHeal;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_enemyAttackDamage = m_enemyAttacks.m_enemyDamage;
        m_life = m_maxLife;
        m_lifeBar.InitializeLifeBar(m_life);
        m_healTime = m_healCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        m_healTime -= Time.deltaTime;
        if(m_healTime <= 0)
        {
            OnHealEvent(m_heal);
            
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAxe"))
        {
            StartCoroutine("IPlayerGetHitWait");
            OnDamageEvent(m_enemyAttackDamage);
           
        }

    }
    private void TakeDamage(float p_damage)
    {
        m_life -= p_damage;
        m_lifeBar.ChangeCurrentLife(m_life);
        Debug.Log($"Damage Received: {p_damage}");
        Debug.Log($"Current Life:{m_life}");
        Debug.Log(this);
        if (m_life <= 0 )
        {
            m_OnPlayerDeath?.Invoke(this,EventArgs.Empty);
            StartCoroutine("IPlayerDeathWait");
        }
    }


    private void GetHeal(float m_heal)
    {
        if (Input.GetKeyDown(KeyCode.V))
            {
            m_life += m_heal;
            m_healTime = m_healCooldown;
            m_lifeBar.ChangeCurrentLife(m_life);
            Debug.Log($"Heal Received: {m_heal}");
            Debug.Log($"Current Life: {m_life}");
            Debug.Log(this);

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
