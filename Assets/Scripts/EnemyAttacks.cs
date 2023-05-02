using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] Animator m_animator;
    [SerializeField] private Transform m_playerTarget;
    private float m_enemySpeed = 50f;
    [SerializeField] public float m_enemyAttackDamage = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {               
                
    }
   
}
