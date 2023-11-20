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
    public bool CarMovement = false;
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
    public List<Text> DiamondCarLevelTexts = new List<Text>();
    

    [Header("---OTHER---")]
    Librariy librariy = new Librariy();
    void Start()
    {
    

        pCarNumber2 = 6 + platformCarNumber;
        for (int i = 0; i < CarNumber; i++)
        {
            VehicleImage[i].gameObject.SetActive(true);
            
        }
        WritingDiamondLevelCar(4, 6, firstDiamond, true);
        WritingDiamondLevelCar(0, 4, librariy.GetData_Int("Diaomond"), true);
        WritingDiamondLevelCar(6, 9, librariy.GetData_Int("LastLevel"),false);
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
        if (platform1.transform.childCount >= pCarNumber2)
        {
            OpenPanels(0, true);
        }
        if (Time.timeScale != 0)
        {
            platform1.transform.Rotate(new Vector3(0, 0, rotateSpeed[0]), Space.Self);

                if (activeCarIndex < CarNumber&& Input.GetKeyDown(KeyCode.H))
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
    public void WinCase()
    {
         if (platform1.transform.childCount >= pCarNumber2)
        {
          
            librariy.SetData_Int("LastLevel", librariy.GetData_Int("LastLevel") + 1);
            OpenPanels(0, true);
            }
        
    }

    void WritingDiamondLevelCar(int firsValue,int secondValue, int value,bool xAdded)
    {

        for (int i = firsValue; i < secondValue; i++)
        {
            if(xAdded==true)
            DiamondCarLevelTexts[i].text = "x" + value;
            else
            DiamondCarLevelTexts[i].text = value.ToString();
        }
        
    }
    public void DiamondValue(string name)
    {
        if (name == "Moment")
        {
            firstDiamond++;
            WritingDiamondLevelCar(4, 6, firstDiamond, true);
        }
        else if (name == "Total")
        {
            librariy.SetData_Int("Diaomond", librariy.GetData_Int("Diaomond") + 1);
            WritingDiamondLevelCar(0, 4, librariy.GetData_Int("Diaomond"), true);
        }
    }

    public void OpenPanels(int index, bool tf)
    {
        Panels[index].SetActive(tf);
        Panels[6].SetActive(false);
        if (index == 0)
            Invoke("OpenButton", 2f);
    }

    public void MainButtons(string name)
    {
        switch (name)
        {
            case "LosePanel":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
               
                break;
            case "WinPanel":
                SceneManager.LoadScene(librariy.GetData_Int("LastLevel"));
               
                break;
            case "FirstPanel":
                CarMovement = true;
                Panels[2].SetActive(false);
                Panels[3].SetActive(true);
               
                break;
            case "SettingsPanel":
                Panels[4].SetActive(true);
               
                break;
            case "CostumuzePanel":
                SceneManager.LoadScene(1);
               
                break;
            case "Reward":
                //Ödül reklamý girecek
                
                break;
            case "PanelClose":
                Panels[4].SetActive(false);
               
                break;
                
        }
       
    }


   void OpenButton()
    {
        Panels[7].SetActive(true);
    }
}
