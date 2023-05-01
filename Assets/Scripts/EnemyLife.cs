using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] Animator m_animator;
    [SerializeField] float m_life = 100f;
    private PlayerBullets m_normalBullet;    
    private float m_normalShootDamage;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        m_normalShootDamage = m_normalBullet.m_normalShootDamage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<PlayerBullets>())
        {
            PlayerBullets l_playerBullet = collision.gameObject.GetComponentInParent<PlayerBullets>();
            if (l_playerBullet != null)
            {
                TakeDamage(m_normalShootDamage);
                Destroy(collision.gameObject);
            }

        }
    }

    public void TakeDamage(float p_damage)
    {
        m_life -= p_damage;
        if (m_life <= 0)
        {
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        Destroy(this.gameObject);
    }
}
