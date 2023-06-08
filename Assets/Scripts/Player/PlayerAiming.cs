using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerAiming : MonoBehaviour
{
    [SerializeField] Animator m_animator;
    public CinemachineFreeLook m_fCam;
    private Vector3 m_v3;
    private float m_f1;
    public float m_normalZoom;
    public float m_aimingZoom;
    public float m_speedZoom;
    public Transform m_zoomPoint;
    public Vector3 m_vectorPoint;


    // Start is called before the first frame update
    void Start()
    {
        m_fCam = GetComponentInChildren<CinemachineFreeLook>();
        m_animator.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        AimingPlayer();
       if (Time.timeScale == 1f)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void AimingPlayer() 
    {
        if (Input.GetMouseButton(1))
        {
            m_animator.SetBool("Aiming", true);
            m_zoomPoint.localPosition = Vector3.SmoothDamp(m_zoomPoint.localPosition,m_vectorPoint, ref m_v3, m_speedZoom * Time.deltaTime);
            m_fCam.m_Lens.FieldOfView = Mathf.SmoothDamp(m_fCam.m_Lens.FieldOfView, m_aimingZoom, ref m_f1, m_speedZoom * Time.deltaTime);
        }
        else
        {
            m_animator.SetBool("Aiming", false);
            m_fCam.m_Lens.FieldOfView = Mathf.SmoothDamp(m_fCam.m_Lens.FieldOfView, m_normalZoom, ref m_f1, m_speedZoom * Time.deltaTime);
        }
    }

 



}
