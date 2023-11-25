using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPark : MonoBehaviour
{
    public GameObject ActvieObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car1")|| other.CompareTag("Car2") || other.CompareTag("Car3") || other.CompareTag("Car4"))
        {
            ActvieObject.SetActive(true);
        }
    }
}
