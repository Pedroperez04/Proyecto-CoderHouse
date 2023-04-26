using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private Animator m_animator;
    [SerializeField] private float m_movementSpeed = 1f;
    [SerializeField] private float m_rotationSpeed = 50f;
    public float m_vertical, m_horizontal ;
    public Cinemachine.AxisState xAxis, yAxis ;
    [SerializeField] private Transform m_camFollowPos;
    

    private void Awake()
    {
        m_animator.SetBool("Walking", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_animator.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        m_vertical = Input.GetAxis("Vertical");
        m_horizontal = Input.GetAxis("Horizontal");
        
        transform.Rotate(0,m_horizontal*Time.deltaTime*m_rotationSpeed,0);
        transform.Translate(0, 0, m_vertical * Time.deltaTime * m_movementSpeed);

        m_animator.SetFloat("HorInput", m_horizontal);
        m_animator.SetFloat("VerInput", m_vertical);

        Running();
        Crouching();    
       
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);

        
    }

    private void LateUpdate()
    {
        m_camFollowPos.localEulerAngles = new Vector3(yAxis.Value, m_camFollowPos.localEulerAngles.y, m_camFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);
    }
    private void Running()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_animator.SetBool("Running", true);
        }
        else { m_animator.SetBool("Running", false); }

    }
    private void Crouching()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            m_animator.SetBool("CrouchedDown", true);
        }
        else { m_animator.SetBool("CrouchedDown", false); }
    }

    
    
}

