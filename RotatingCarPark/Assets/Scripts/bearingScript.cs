using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearingScript : MonoBehaviour
{
    Car car;
    public void Start()
    {
        car = GetComponentInParent<Car>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
         if (collision.gameObject.CompareTag("Stop"))
        {

            car.CarStopKontrol();
            print("degdi");

        }
        
    }

    }
