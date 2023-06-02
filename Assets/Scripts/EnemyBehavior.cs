using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
     private GameObject m_playerTarget;
    [SerializeField] private float m_distanceToChase = 10f;
    [SerializeField] private float m_enemySpeed = 1f;
    [SerializeField] private Animator m_animator;

    [SerializeField] public float m_enemyDamage = 20f;
    private float m_attackCooldown = 5f;
    private float m_canAttack;

    [SerializeField] private int m_enemyRutine;
    [SerializeField] private float m_enemyTimer;
    [SerializeField] private Quaternion m_enemyQuaternion;
    [SerializeField] private float m_degree;
    [SerializeField] private bool m_enemyAttack;


    [SerializeField] private Transform m_raycastPointForward;
    [SerializeField] private Transform m_raycastPointBackward;
    [SerializeField] private float m_raycastDistance = 10f;
    [SerializeField] private LayerMask m_raycastLayerMask;
    private bool m_blockedVisionforward;
    private bool m_blockedVisionbackward;

    private void Awake()
    {
        m_canAttack = m_attackCooldown;
        m_playerTarget = GameObject.Find("Wizard");
    }

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        m_canAttack -= Time.deltaTime;      
        EnemyBehaviorMovement();
        EnemyVisionRaycast();
        EnemyVisionRaycastBackward();
    }

    private void EnemyBehaviorMovement()
    {   
        if (Vector3.Distance(transform.position, m_playerTarget.transform.position) > m_distanceToChase || EnemyVisionRaycast() == true )
        {
            m_enemyTimer += 1 * Time.deltaTime;
            if (m_enemyTimer >= 4)
            {
                m_enemyRutine = Random.Range(0, 2);
                m_enemyTimer = 0;
            }
            switch (m_enemyRutine)
            {
                case 0:
                    m_animator.SetBool("Run", false);
                    break;
                case 1:
                    m_degree = Random.Range(0, 360);
                    m_enemyQuaternion = Quaternion.Euler(0, m_degree, 0);
                    m_enemyRutine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.Lerp(transform.rotation, m_enemyQuaternion, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    m_animator.SetBool("Run", true);
                    break;
            }
        }
        else
        { 
            if (Vector3.Distance(transform.position, m_playerTarget.transform.position) < m_distanceToChase && EnemyVisionRaycast() == false || Vector3.Distance(transform.position, m_playerTarget.transform.position) < m_distanceToChase  && EnemyVisionRaycastBackward() == false)
            {
                Chase();
            }
           
        }
        
    }

      private void Chase()
    {
        var l_diffVector = m_playerTarget.transform.position - transform.position;
        Quaternion l_newRotation = Quaternion.LookRotation(l_diffVector.normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, l_newRotation, m_enemySpeed * Time.deltaTime);
        if (m_distanceToChase > l_diffVector.magnitude && 1 < l_diffVector.magnitude)
        {
            Move(l_diffVector.normalized);
            m_animator.SetBool("Run", true);

            if (2 > l_diffVector.magnitude)
            {
                if (m_canAttack <= 0)
                {
                    m_animator.SetBool("Attack", true);
                    m_canAttack = m_attackCooldown;

                }
                m_animator.SetBool("Run", false);

            }
            else
            {
                m_animator.SetBool("Attack", false);
            }
        }
    }

    private void Move(Vector3 p_direction)
    {
        transform.position += p_direction * (m_enemySpeed * Time.deltaTime);
    }



    private void FinalAttackAnimation()
    {
        m_animator.SetBool("Attack", false);
        m_enemyAttack = false; 
    }

    public bool EnemyVisionRaycast()
    {
        
        Ray l_enemyRayForward = new Ray(m_raycastPointForward.transform.position, m_raycastPointForward.transform.forward);       
        Debug.DrawRay(l_enemyRayForward.origin, l_enemyRayForward.direction * m_raycastDistance, Color.green);        
        m_blockedVisionforward = Physics.Raycast(l_enemyRayForward, out RaycastHit hit, m_raycastDistance, m_raycastLayerMask);
       

        if (m_blockedVisionforward || m_blockedVisionbackward)
        {
            Debug.Log(m_blockedVisionforward);
        }
        else
        {
            Debug.Log(m_blockedVisionforward || m_blockedVisionbackward);
        }
        return m_blockedVisionforward; 
    }
    public bool EnemyVisionRaycastBackward()
    {
        Ray l_enemyRayBackward = new Ray(m_raycastPointBackward.transform.position, m_raycastPointBackward.transform.forward);
        Debug.DrawRay(l_enemyRayBackward.origin, l_enemyRayBackward.direction * m_raycastDistance, Color.green);
        m_blockedVisionbackward = Physics.Raycast(l_enemyRayBackward, out RaycastHit lhit, m_raycastDistance, m_raycastLayerMask);
        if ( m_blockedVisionbackward)
        {
            Debug.Log(m_blockedVisionbackward);
        }
        else
        {
            Debug.Log(m_blockedVisionbackward);
        }
        return m_blockedVisionbackward;
    }


}
