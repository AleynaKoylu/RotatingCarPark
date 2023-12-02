using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLeft : MonoBehaviour
{
    [Header("---LEFT---")]
    public GameManager gameManager;
    public Vector3 firstTransform;
    public GameObject platform2;
    public float x;
    bool left = false;
    public List<GameObject> bearing = new List<GameObject>();
    public int platformChild;
    public List<GameObject> Cars = new List<GameObject>();

    [Header("---UP---")]
    public bool LeftOrUp;
    public GameObject floor1, floor2;
    bool up = false;
    public float y;
    public GameObject secondTransform;

    [Header("---LEFT2---")]
    public int left2;

    void Start()
    {
        if (LeftOrUp == true)
            firstTransform = floor1.transform.position;
     
         
    }


    void Update()
    {
        if (LeftOrUp == false)
        {
            Left();
        }
        else 
        {
            Up();
        }
       

    }
    void Left()
    {
        if (gameObject.transform.childCount == platformChild)
        {
            left = true;

        }

        if (left == true)
        {
            gameManager.platform1 = platform2;

            for (int i = 0; i < Cars.Count; i++) 
            {
              Cars[i].GetComponent<Car>().parent = platform2.transform;
            }
            if (left2 == 0)
            {
                foreach (var item in bearing)
                {
                    item.GetComponent<bearingScript>().Platforms = platform2;
                }
            }
            if (x < transform.position.x)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(x, firstTransform.y, transform.position.z), 0.005f);
                platform2.transform.position = Vector3.Lerp(platform2.transform.position, firstTransform, 0.005f);

            }

            else
            {

                left = false;
            }
        }
    }
    
    void Up()
    {
        if (floor1.transform.childCount == platformChild)
        {
            up = true;

        }

        if (up == true)
        {
         
            if (y <floor1.transform.position.z)
            {
                floor1.transform.position = Vector3.Lerp(floor1.transform.position, secondTransform.transform.position, 0.005f);
                floor2.transform.position = Vector3.Lerp(floor2.transform.position, firstTransform, 0.005f);

            }

            else
            {

                up = false;
            }
        }
    }

}
