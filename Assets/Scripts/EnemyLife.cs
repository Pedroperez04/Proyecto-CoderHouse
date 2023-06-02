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
    public int m_enemyDropPoints;
    private GameManager m_gameManager;
    private ScoreManager m_scoreManager;

    // Start is called before the first frame update
    void Start()
    {        
        m_normalShootDamage = m_normalBullet.m_normalShootDamage;
        ChooseEnemy(enemyType);
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
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
                m_enemyDropPoints = 5;
                break;
            case EnemyType.EnemyMiddle:
                m_life = 80;
                m_enemyDropPoints = 10;
                break;
            case EnemyType.EnemyStrong:
                m_life = 100;
                m_enemyDropPoints = 15;
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

    public IEnumerator IDeathWait()
    {
        m_animator.SetBool("Death", true);
        m_scoreManager.PlayerGetPoints(m_enemyDropPoints);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        m_gameManager.m_defeatedEnemies += 1;
    }
}