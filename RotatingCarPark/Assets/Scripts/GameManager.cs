using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AleynaRotatingCar;
public class GameManager : MonoBehaviour
{
    [Header("---CAR---")]
    public List<GameObject> Carr = new List<GameObject>();
    public int CarNumber;
    public int activeCarIndex = 0;
    public Vector3 carTransform;
    public List<Image> VehicleImage = new List<Image>();
    public Sprite vehicle;
    public Transform parent;

    [Header("---PLATFORM---")]
    public GameObject platform1;
    public GameObject platform2;
    public List<float> rotateSpeed = new List<float>();

    [Header("---LEVEL---")]
    public int platformCarNumber;
    int pCarNumber2;
    public int diamond;
    public int firstDiamond=0;

    [Header("---CANVAS---")]
    public List<GameObject> Panels = new List<GameObject>();
    public GameObject CarNew;
    public List<Text> DiamondAndCarTexts = new List<Text>();
  

    [Header("---OTHER---")]
    Librariy librariy = new Librariy();
    void Start()
    {
        Time.timeScale = 0;
        pCarNumber2 = 6 + platformCarNumber;
        for (int i = 0; i < CarNumber; i++)
        {
            VehicleImage[i].gameObject.SetActive(true);

        }
        DiamondValue();
        MomentDiamond();
    }

    public void ChangeImage()
    {
        VehicleImage[activeCarIndex - 1].sprite = vehicle;
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
        print(firstDiamond);
        if (Panels[0].activeSelf)
            print("acik");
        
        if (platform1.transform.childCount >= pCarNumber2)
        {
            Debug.Log("Kazandý");

            OpenPanels(0, true);
        }
        if (Time.timeScale != 0)
        {
            platform1.transform.Rotate(new Vector3(0, 0, rotateSpeed[0]), Space.Self);


           
                
                if (activeCarIndex < CarNumber&& Input.GetKeyDown(KeyCode.Mouse0))
                {

                    Carr[activeCarIndex].GetComponent<Car>().go = true;

                    activeCarIndex++;
                }
            
        }
        foreach (var item in Carr)
        {
            if (!item.activeSelf)
            {
                item.transform.SetParent(parent);
            }
        }


    }

    public void MomentDiamond(bool added = false)
    {
        if (added == true)
        {
            firstDiamond++;
        }
        for (int i = 4; i < 6; i++)
        {
            DiamondAndCarTexts[i].text = "x" + firstDiamond;
        }
   
    }
    public void DiamondValue(bool added=false)
    {

        if (added == true)
        {
            librariy.SetData_Int("Diaomond", librariy.GetData_Int("Diaomond") + 1);
            Debug.Log(librariy.GetData_Int("Diaomond"));
        }

        for (int i = 0; i < 4; i++)
        {
            DiamondAndCarTexts[i].text = "x" + librariy.GetData_Int("Diaomond");
        }

     
    }
    public void OpenPanels(int index, bool tf)
    {
        Panels[index].SetActive(tf);
        Time.timeScale = 0;
    }

    public void MainButtons(string name)
    {
        switch (name)
        {
            case "LosePanel":
                SceneManager.LoadScene(1);
                print(name);
                break;
            case "WinPanel":
                //SceneManager.LoadScene(NextLevel);
                print(name);
                break;
            case "FirstPanel":
                Time.timeScale = 1;
                Panels[2].SetActive(false);
                Panels[3].SetActive(true);
                print(name);
                break;
            case "SettingsPanel":
                Panels[4].SetActive(true);
                print(name);
                break;
            case "CostumuzePanel":
                Panels[5].SetActive(true);
                print(name);
                break;
            case "Reward":
                //Ödül reklamý girecek
                print(name);
                break;
            case "PanelClose":
                Panels[4].SetActive(false);
                print(name);
                break;
        }
       
    }
}
