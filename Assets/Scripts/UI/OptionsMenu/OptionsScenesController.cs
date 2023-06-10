using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScenesController : MonoBehaviour
{

        private void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("GlobalOptions");
            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }
          //  DontDestroyOnLoad(this.gameObject);
        }
}
