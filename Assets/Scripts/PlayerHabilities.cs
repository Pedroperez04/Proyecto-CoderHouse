using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHabilities : MonoBehaviour
{
    [SerializeField] Animator m_Animator;
    [SerializeField] PlayerBullets m_normalBullet;
    [SerializeField] PlayerBullets m_specialHability1Bullet;
    [SerializeField] Transform m_shootingPoint;
    [SerializeField] private float m_habilityCooldown = 1f;
    private float m_canShoot;


    private void Awake()
    {
        m_canShoot = m_habilityCooldown;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_canShoot -= Time.deltaTime;
        if (m_canShoot <= 0) 
        {            
            NormalShoot();
        }
        
        if (Input.GetKey(KeyCode.Q) && m_canShoot <= 0)
        {
            SpecialHability1Shoot();
        }

    }
    
    private void NormalShoot ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_Animator.SetBool("Shooting", true);
            StartCoroutine("INormalShootWait");
            
            m_canShoot = m_habilityCooldown;
        }
        else
        {
            m_Animator.SetBool("Shooting", false);
        }
    }

    private void SpecialHability1Shoot ()
    {
        Instantiate (m_specialHability1Bullet,m_shootingPoint.position, Quaternion.identity);
        m_canShoot = m_habilityCooldown;
    }

    IEnumerator INormalShootWait()
    {
        yield return new WaitForSeconds(1f);
        var l_currentBullet =  Instantiate(m_normalBullet, m_shootingPoint.position, m_shootingPoint.rotation);        
    }
}
