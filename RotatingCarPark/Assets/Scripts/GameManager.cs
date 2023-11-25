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
    //public List<Image> VehicleImage = new List<Image>();
    public Text vehicleText;
    public Sprite vehicle;
    public Transform parent;
    public bool CarMovement = false;



    [Header("---PLATFORM---")]
    public GameObject platform1;
    public GameObject platform2;
    public List<float> rotateSpeed = new List<float>();

    [Header("---LEVEL---")]
    public int diamond;
    public int firstDiamond = 0;

    [Header("---CANVAS---")]
    public List<GameObject> Panels = new List<GameObject>();
    public GameObject CarNew;
    public List<Text> DiamondCarLevelTexts = new List<Text>();


    [Header("---OTHER---")]
    Librariy librariy = new Librariy();

    [Header("---Language---")]
    DataManager dataManager = new DataManager();
    public List<LanguageDatasMainObject> languageDatasMainObjects = new List<LanguageDatasMainObject>();
    List<LanguageDatasMainObject> ReadingLanguageDatas = new List<LanguageDatasMainObject>();
    public List<Text> languageTexts = new List<Text>();
    void Start()
    {

        vehicleText.text = CarNumber.ToString();
        WritingDiamondLevelCar(3, 5, firstDiamond, true);
        WritingDiamondLevelCar(0, 3, librariy.GetData_Int("Diaomond"), true);
        WritingDiamondLevelCar(5, 7, librariy.GetData_Int("LastLevel") - 1, false);

        dataManager.LoadLang();
        ReadingLanguageDatas = dataManager.TakeLangCostume();
        languageDatasMainObjects.Add(ReadingLanguageDatas[2]);
        ChangeLanguage();
    }
   
    void Update()
    {
        if (Time.timeScale != 0)
        {
            platform1.transform.Rotate(new Vector3(0, 0, rotateSpeed[0]), Space.Self);

            if (activeCarIndex < CarNumber && Input.GetKeyDown(KeyCode.H))
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
    void ChangeLanguage()
    {
        switch (librariy.GetData_String("Language"))
        {
            case "EN":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_EN[i].String;
                }

                break;
            case "TR":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_TR[i].String;
                }
                break;
            case "AZ":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_AZ[i].String;
                }
                break;
            case "JP":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_JP[i].String;
                }
                break;
            case "KR":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_KR[i].String;
                }
                break;
            case "AL":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_AL[i].String;
                }
                break;
            case "HN":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_HN[i].String;
                }
                break;
        }
    }
    public void ChangeImage()
    {
        vehicleText.text = (CarNumber-activeCarIndex).ToString();
    }
    public void NewCarActive()
    {

        if (activeCarIndex < CarNumber)
        {
            Carr[activeCarIndex].SetActive(true);
        }
        else
        {
            WinCase();
        }
    }
    public void WinCase()
    {
            librariy.SetData_Int("LastLevel", librariy.GetData_Int("LastLevel") + 1);
            OpenPanels(0, true);
    }
    void WritingDiamondLevelCar(int firsValue, int secondValue, int value, bool xAdded)
    {

        for (int i = firsValue; i < secondValue; i++)
        {
            if (xAdded == true)
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
        Panels[3].SetActive(false);
        if (index == 0)
            Invoke("OpenButton", 3.5f);
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
            
            case "MainMenu":
                SceneManager.LoadScene(0);

                break;
            case "Reward":
                //Ödül reklamý girecek

                break;
       

        }

    }
    void OpenButton()
    {
        Panels[4].SetActive(true);
    }
}
