using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHabilities : MonoBehaviour
{
     public Animator m_Animator;
     public PlayerBullets m_Bullet;
     public Transform m_shootingPoint;


     public Image m_HabilityImage;
     protected float m_habilityCooldown = 1f;
     protected float m_canShoot;

    IEnumerator INormalShootWait()
    {
        yield return new WaitForSeconds(1f);
        var l_currentBullet =  Instantiate(m_Bullet, m_shootingPoint.position, m_shootingPoint.rotation);
       
    }
}
