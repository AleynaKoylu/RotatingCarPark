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
    private void OnCollisionEnter(Collision collision)
    {
        
         if (collision.gameObject.CompareTag("Stop"))
        {

            car.CarStopKontrol();
            gameManager.WinCase();
        }
        
    }

    }
