using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public bool go;
    //public bool waitZone = false;
    public Transform parent,parent2;
    public List<GameObject> WhellTracks = new List<GameObject>();
    GameObject gameManagerObject;
    GameManager gameManager;
    
    void Start()
    {
        gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameManagerObject.GetComponent<GameManager>();

    }


    void Update()
    {
        
        if (transform.position.z < -7.46f)
            transform.Translate(new Vector3(0, 0, 3f * Time.deltaTime));
        if(transform.position.z>=-7.46f&& go==true)
            transform.Translate(new Vector3(0, 0, 15 * Time.deltaTime));
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
      

       if (collision.gameObject.CompareTag("Platform"))
        {
            gameObject.SetActive(false);
          
            gameManager.NewCarActive();

        }
        else if (collision.gameObject.CompareTag("Car"))
        {
            gameObject.SetActive(false);
            
            gameManager.NewCarActive();


        }
    }
}
