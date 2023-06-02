using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHabilityOne : PlayerHabilities
{


    private void Awake()
    {
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
            NormalShoot();
        }
    }

    private void NormalShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_Animator.SetBool("Shooting", true);
            StartCoroutine("INormalShootWait");


            m_HabilityImage.fillAmount = 1;
            m_canShoot = m_habilityCooldown;
        }
        else
        {

            m_HabilityImage.fillAmount -= 1 / m_habilityCooldown * Time.deltaTime;

            if (m_HabilityImage.fillAmount <= 0)
            {
                m_HabilityImage.fillAmount = 0;
            }
            m_Animator.SetBool("Shooting", false);
        }
    }




}
