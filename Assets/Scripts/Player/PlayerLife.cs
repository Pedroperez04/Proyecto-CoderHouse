using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] Animator m_animator;

    [SerializeField] public float m_life;
    [SerializeField] private float m_maxLife;
    [SerializeField] public LifeBar m_lifeBar;
    
    public EnemyBehavior m_enemyAttacks;
    private float m_enemyAttackDamage;

    public Action<float> OnDamageEvent;
    public event EventHandler m_OnPlayerDeath;

    public Transform m_healingPoint;


    public Image m_healHabilityImage;
    private float m_healing =4f;
    private float m_healHabilityCooldown = 10f;
    private float m_canHeal;

    public PlayerHealAura m_healingAura;



    private void Awake()
    {
        OnDamageEvent += TakeDamage;
        m_canHeal = m_healHabilityCooldown;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_enemyAttackDamage = m_enemyAttacks.m_enemyDamage;
        m_life = m_maxLife;
        m_lifeBar.InitializeLifeBar(m_life);
        m_healHabilityImage.fillAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {        
        m_canHeal -= Time.deltaTime;
       
            GetHeal();
        
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
        if (m_life <= 0 )
        {
            m_OnPlayerDeath?.Invoke(this,EventArgs.Empty);
            StartCoroutine("IPlayerDeathWait");
        }
    }

    private void GetHeal()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (m_canHeal <= 0 && m_life < 100)
            {
                m_life += m_healing;
                m_lifeBar.ChangeCurrentLife(m_life);
                m_healHabilityImage.fillAmount = 1;
                m_canHeal = m_healHabilityCooldown;
                Instantiate(m_healingAura, m_healingPoint.position, m_healingPoint.rotation);
                
            }
            
        }
        else
        {
            m_healHabilityImage.fillAmount -= 1 / m_healHabilityCooldown * Time.deltaTime;

            if (m_healHabilityImage.fillAmount <= 0)
            {
                m_healHabilityImage.fillAmount = 0;
            }
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
