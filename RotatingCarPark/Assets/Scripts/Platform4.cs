using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform4 : MonoBehaviour
{
    public bool carYes=false;
    public GameObject control;
    Platform4 platform4;
    public bool upp=false;
    public bool haveSibling = false;
    void Start()
    {
        if (haveSibling==true)
        {
            platform4 = control.GetComponent<Platform4>();
        }

    }

    void Update()
    {
        if (haveSibling==true)
        {
            if (carYes == true && platform4.carYes == true)
            {
                upp = true;
            }
        }
        else
        {
            if (carYes == true)
            {
                upp = true;
            }
        }
      
    }

}
