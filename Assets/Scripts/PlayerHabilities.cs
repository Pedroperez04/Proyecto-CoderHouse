using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHabilities : MonoBehaviour
{
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
        if (Input.GetMouseButton(0) && m_canShoot <= 0) 
        {
            NormalShoot();
        }
        if (Input.GetMouseButton(1) && m_canShoot <= 0)
        {
            SpecialHability1Shoot();
        }

    }
    
    private void NormalShoot ()
    {
        Instantiate(m_normalBullet, m_shootingPoint.position,Quaternion.identity);
        m_canShoot = m_habilityCooldown;
    }

    private void SpecialHability1Shoot ()
    {
        Instantiate (m_specialHability1Bullet,m_shootingPoint.position, Quaternion.identity);
        m_canShoot = m_habilityCooldown;
    }
}
