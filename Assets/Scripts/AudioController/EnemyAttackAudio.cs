using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAudio : MonoBehaviour
{

    [SerializeField] private AudioSource m_enemyAudioSource;
    [SerializeField] private SphereCollider m_enemyAxeCollider;
    [SerializeField] private Animator m_enemyAnimator;
    private void Awake()
    {
        m_enemyAudioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //m_enemyAnimator.GetBool("Attack") != false
    }

    // Update is called once per frame
    void Update()
    {
        if (m_enemyAxeCollider.enabled == true)
        {
            m_enemyAudioSource.Play();
        }
       
    }
}
