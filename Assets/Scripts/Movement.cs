using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float m_speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var l_vertical = Input.GetAxis("Vertical");
        var l_horizontal = Input.GetAxis("Horizontal");
        var l_movementDirection = new Vector3(l_horizontal, 0, l_vertical);
        Move(l_movementDirection);
    }

    private void Move(Vector3 p_movementDirection)
    {
        transform.position += p_movementDirection * (m_speed * Time.deltaTime);
    }
}
