using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    [SerializeField] private float m_bulletSpeed = 20f;
    [SerializeField] private float m_destroyBulletTime = 5f;
    [SerializeField] public float m_normalShootDamage = 20f;
    [SerializeField] public float m_specialShootDamage = 35f;
    private float m_canDestroy;

    private void Awake()
    {
        m_canDestroy = m_destroyBulletTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (m_bulletSpeed * Time.deltaTime);
        BulletDestroy();
    }

    
    private void BulletDestroy()
    {
        m_canDestroy -= Time.deltaTime; 
        if (m_canDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

}
