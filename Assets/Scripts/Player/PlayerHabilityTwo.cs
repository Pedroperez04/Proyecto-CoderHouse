using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHabilityTwo : PlayerHabilities
{
    

    private void Awake()
    {
        
        m_habilityCooldown = 6f;
        m_canShoot = m_habilityCooldown;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_HabilityImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_canShoot -= Time.deltaTime;
        if (m_canShoot <= 0)
        {            
            SpecialShoot();
        }
    }

    private void SpecialShoot()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            m_HabilityImage.fillAmount = 1;
            m_canShoot = m_habilityCooldown;

            m_Animator.SetBool("ShootingTwo", true);
            StartCoroutine("INormalShootWait");                     
            
        }
       else
        {

            m_HabilityImage.fillAmount -= 1 / m_habilityCooldown * Time.deltaTime;

            if (m_HabilityImage.fillAmount <= 0)
            {
                m_HabilityImage.fillAmount = 0;
            }
            
            m_Animator.SetBool("ShootingTwo", false);
        }
    }
}
