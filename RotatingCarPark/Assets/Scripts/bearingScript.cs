using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearingScript : MonoBehaviour
{
    Car car;
    GameObject gameManagerObjct;
    GameManager gameManager;
    public void Start()
    {
        gameManagerObjct = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameManagerObjct.GetComponent<GameManager>();
        car = GetComponentInParent<Car>();
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Stop"))
        {
            car.CarStopKontrol();

        }
    }

}
