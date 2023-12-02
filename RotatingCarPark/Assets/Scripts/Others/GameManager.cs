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
    public Text vehicleText;
    public Sprite vehicle;
    public Transform parent;
    public bool CarMovement = false;

    [Header("---ADS---")]
    GameObject AdsObject;
    InterstitialADS aDSManager;
    RewardAD rewardManager;
    public Button adsBtn;

    [Header("---PLATFORM---")]
    public GameObject platform1;
    public GameObject platform2;
    public List<float> rotateSpeed = new List<float>();

    [Header("---LEVEL---")]
    public int diamond;
    public int firstDiamond = 0;
    public List<AudioSource> audioSources = new List<AudioSource>();

    [Header("---CANVAS---")]
    public List<GameObject> Panels = new List<GameObject>();
    public GameObject CarNew;
    public List<Text> DiamondCarLevelTexts = new List<Text>();


    [Header("---OTHER---")]
    Librariy librariy = new Librariy();
    public bool noMovement = false;
    public int down = 0;
    [Header("---Language---")]
    DataManager dataManager = new DataManager();
    public List<LanguageDatasMainObject> languageDatasMainObjects = new List<LanguageDatasMainObject>();
    List<LanguageDatasMainObject> ReadingLanguageDatas = new List<LanguageDatasMainObject>();
    public List<Text> languageTexts = new List<Text>();

    private void Awake()
    {
        AdsObject = GameObject.FindGameObjectWithTag("ADS");
        aDSManager = AdsObject.GetComponent<InterstitialADS>();
        rewardManager = AdsObject.GetComponent<RewardAD>();
    }
    void Start()
    {

        vehicleText.text = CarNumber.ToString();
        WritingDiamondLevelCar(3, 5, firstDiamond, true);
        WritingDiamondLevelCar(0, 3, librariy.GetData_Int("Diaomond"), true);
        WritingDiamondLevelCar(5, 8, librariy.GetData_Int("LastLevel") - 1, false);

        dataManager.LoadLang();
        ReadingLanguageDatas = dataManager.TakeLangCostume();
        languageDatasMainObjects.Add(ReadingLanguageDatas[2]);
        ChangeLanguage();

        foreach (var item in audioSources)
        {
            item.volume = librariy.GetData_Float("FX");
        }


    }

    void Update()
    {


        platform1.transform.Rotate(new Vector3(0, 0, rotateSpeed[0]), Space.Self);
        if (platform2 != null)
            platform2.transform.Rotate(new Vector3(0, 0, rotateSpeed[1]), Space.Self);
        if (Input.GetMouseButtonDown(0) && noMovement == true)
        {
            down++;
            if (activeCarIndex < CarNumber && down >= 1)
            {

                Carr[activeCarIndex].GetComponent<Car>().go = true;
                activeCarIndex++;
            }
        }
        if (Panels[0].activeSelf || Panels[1].activeSelf || Panels[2].activeSelf)
        {
            noMovement = false;
        }
        else if (Panels[0].activeSelf == false && Panels[1].activeSelf == false && Panels[2].activeSelf == false)
        {
            noMovement = true;
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
        vehicleText.text = (CarNumber - activeCarIndex).ToString();
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
            if (SceneManager.GetActiveScene().buildIndex % 2 == 0)
                aDSManager.ShowAd();
        }
    }
    public void WinCase()
    {

        if (SceneManager.GetActiveScene().buildIndex >= 25)
            librariy.SetData_Int("LastLevel", 25);
        else
            librariy.SetData_Int("LastLevel", librariy.GetData_Int("LastLevel") + 1);
        OpenPanels(0, true);
        Sounds(2);
    }
    void WritingDiamondLevelCar(int firsValue, int secondValue, int value, bool xAdded)
    {

        for (int i = firsValue; i < secondValue; i++)
        {
            if (xAdded == true)
                DiamondCarLevelTexts[i].text = "x" + value;
            else
                DiamondCarLevelTexts[i].text = " " + value.ToString();
        }

    }
    public void DiamondValue(string name)
    {
        if (name == "Moment")
        {
            firstDiamond++;
            WritingDiamondLevelCar(3, 5, firstDiamond, true);
        }
        else if (name == "Total")
        {
            librariy.SetData_Int("Diaomond", librariy.GetData_Int("Diaomond") + 1);
            WritingDiamondLevelCar(0, 3, librariy.GetData_Int("Diaomond"), true);
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
                rewardManager.ShowRewardedAd(firstDiamond,DiamondCarLevelTexts[3],DiamondCarLevelTexts[1],adsBtn);

                break;


        }

    }
    void OpenButton()
    {
        Panels[4].SetActive(true);
    }

    #region Sounds
    public void ButtonsSound()
    {
        audioSources[0].Play();
    }
    public void Sounds(int index)
    {
        audioSources[index].Play();
    }


    #endregion
}

