using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearingScript : MonoBehaviour
{
    Car car;
    public GameObject Platforms;
    public float yValue;
    float yResult;

    Platform4 platform4;
    public void Start()
    {
        car = GetComponentInParent<Car>();
    }
    private void Update()
    {
        
        if (platform4!=null&& platform4.upp == true)
        {
            if (yResult > Platforms.transform.position.y)
                Platforms.transform.position = Vector3.Lerp(Platforms.transform.position, new Vector3(Platforms.transform.position.x, yResult, Platforms.transform.position.z), 0.010f);
            else
                platform4.upp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stop"))
        {
            car.CarStopKontrol();
            if (Platforms != null)
            {
                yResult = Platforms.transform.position.y + yValue;
                platform4 = other.gameObject.GetComponentInParent<Platform4>();
                platform4.carYes = true;


            }
               
          
        }

    }
}


