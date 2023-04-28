using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        AimingPlayer();
        ShowCursor(false);
    }

    private void AimingPlayer() 
    {
        if (Input.GetMouseButton(1))
        {
            m_animator.SetBool("Aiming", true);
        }
        else
        {
            m_animator.SetBool("Aiming", false);
        }
    }

    private void ShowCursor(bool p_showCursor)
    {
        Cursor.visible = p_showCursor;
        Cursor.lockState = p_showCursor ? CursorLockMode.Locked : CursorLockMode.Locked;
    }



}
