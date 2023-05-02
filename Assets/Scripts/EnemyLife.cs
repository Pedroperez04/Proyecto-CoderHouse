using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public enum EnemyType
    {
        EnemyWeak,
        EnemyMiddle,
        EnemyStrong,
    }
    [SerializeField] EnemyType enemyType;
    [SerializeField] Animator m_animator;
    [SerializeField] float m_life = 100f;
    public PlayerBullets m_normalBullet;
    private float m_normalShootDamage;    
    

    // Start is called before the first frame update
    void Start()
    {        
        m_normalShootDamage = m_normalBullet.m_normalShootDamage;
        ChooseEnemy(enemyType);
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision p_collision)
    {
        if (p_collision.gameObject.GetComponentInParent<PlayerBullets>())
        {
            PlayerBullets l_playerBullet = p_collision.gameObject.GetComponentInParent<PlayerBullets>();
            if (l_playerBullet != null)
            {              
                StartCoroutine("IGetHitWait");                
                TakeDamage(m_normalShootDamage);
                Destroy(p_collision.gameObject);
            }            

        }
    }
    private void ChooseEnemy(EnemyType enemyType)
    {
        switch (enemyType) 
        {
            case EnemyType.EnemyWeak:
                m_life = 60;
                break;
            case EnemyType.EnemyMiddle:
                m_life = 80;
                break;
            case EnemyType.EnemyStrong:
                m_life = 100;
                break;
        }
    }
    public void TakeDamage(float p_damage)
    {
        m_life -= p_damage;        
        if (m_life <= 0)
        {
            StartCoroutine("IDeathWait");
        }
    }  

    IEnumerator IGetHitWait()
    {
        m_animator.SetBool("GetHit", true);
        yield return new WaitForSeconds(1f);
        m_animator.SetBool("GetHit", false);
    }

    IEnumerator IDeathWait()
    {
        m_animator.SetBool("Death", true);
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}