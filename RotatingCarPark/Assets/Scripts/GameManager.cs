using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [Header("---CAR---")]
    public List<GameObject> Carr = new List<GameObject>();
    public int CarNumber;
    public int activeCarIndex = 0;
    public Vector3 carTransform;
    public List<Image> VehicleImage = new List<Image>();
    public Sprite vehicle;
  
    [Header("---PLATFORM---")]
    public GameObject platform1;
    public GameObject platform2;
    public List<float> rotateSpeed = new List<float>();

    void Start()
    {
      

        for (int i = 0; i <CarNumber; i++)
        {
            VehicleImage[i].gameObject.SetActive(true);
           
        }

    }
    public void ChangeImage()
    {
        VehicleImage[activeCarIndex-1].sprite = vehicle;
    }
    public void NewCarActive()
    {
   
        if (activeCarIndex < CarNumber)
        {
            Carr[activeCarIndex].SetActive(true);


        }
    }
    void Update()
    {
        print(activeCarIndex);
        if (platform1.transform.childCount >= 9)
        {
            Debug.Log("Kazandý");
        }
        if (Time.timeScale != 0)
            platform1.transform.Rotate(new Vector3(0, 0, rotateSpeed[0]), Space.Self);


        if (Input.GetKeyDown(KeyCode.Mouse0) && activeCarIndex < CarNumber)
        {

            Carr[activeCarIndex].GetComponent<Car>().go = true;

            activeCarIndex++;
        }



    }
}
