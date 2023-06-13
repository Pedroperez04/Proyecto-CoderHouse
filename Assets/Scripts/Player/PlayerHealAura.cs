using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealAura : MonoBehaviour
{
    [SerializeField] private float m_destroyAuraTime = 2f;
    private float m_canDestroy;

    private void Awake()
    {
        m_canDestroy = m_destroyAuraTime;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AuraDestroy();
    }


    private void AuraDestroy()
    {
        m_canDestroy -= Time.deltaTime;
        if (m_canDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
