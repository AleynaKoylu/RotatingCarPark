using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AleynaRotatingCar;
public class Car : MonoBehaviour
{
    public bool go;
    Librariy librariy = new Librariy();
    public Transform parent,parent2;
    public List<GameObject> WhellTracks = new();
    GameObject gameManagerObject;
    GameManager gameManager;
    public ParticleSystem particleSystem;

    public List<GameObject> Group1 = new List<GameObject>();
    public List<GameObject> Group2 = new List<GameObject>();
    public List<GameObject> Group3 = new List<GameObject>();
    public List<GameObject> Group4 = new List<GameObject>();


    void Start()
    {
      
        gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    

        CarCostumeControl("Car1", Group1, "ActiveGroup1Image");
        CarCostumeControl("Car2", Group2, "ActiveGroup2Image");
        CarCostumeControl("Car3", Group3, "ActiveGroup3Image");
        CarCostumeControl("Car4", Group4, "ActiveGroup4Image");

    }



    private void Update()
    {
        if (transform.position.z < -7.46f && gameManager.CarMovement == true)
            transform.Translate(new Vector3(0, 0, 5f * Time.deltaTime));


        else if (transform.position.z >= -7.46f && go == true)
            transform.Translate(new Vector3(0, 0, 15 * Time.deltaTime));

       

    }

    void CarCostumeControl(string Tag,List<GameObject> GroupName,string key)
    {
        if (gameObject.CompareTag(Tag)) 
        { 
            for (int i = 0; i < GroupName.Count; i++)
                {
                    GroupName[i].SetActive(false);
                }
            GroupName[librariy.GetData_Int(key)].SetActive(true);
        }

    }
    public void CarStopKontrol()
    {
        go = false;
        transform.SetParent(parent);
        WhellTracks[0].SetActive(false);
        WhellTracks[1].SetActive(false);
        gameManager.NewCarActive();
        gameManager.ChangeImage();
    }
    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Car1")|| collision.gameObject.CompareTag("Car2")|| collision.gameObject.CompareTag("Car3")|| collision.gameObject.CompareTag("Car4"))
        {
            gameObject.SetActive(false);
            gameManager.OpenPanels(1, true);
            particleSystem.Play();
            go = false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Platform"))
        {
            gameObject.SetActive(false);
            gameManager.OpenPanels(1, true);
            particleSystem.Play();
            go = false;
        }
        else if (other.gameObject.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            gameManager.DiamondValue("Moment");
            gameManager.DiamondValue("Total");

        }
    }
}
