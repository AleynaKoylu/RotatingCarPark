using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AleynaRotatingCar;
public class MainMenuManager : MonoBehaviour
{
    public List<Button> Buttons = new();
    Librariy librariy = new Librariy();
    public List<ItemDatas> defaultItemDatas = new List<ItemDatas>();
    DataManager dataManager = new DataManager();
    [Header("Sound")]
    public AudioSource audioSources;
    public List<Slider> sliders = new List<Slider>();

    [Header("Language")]

    public Image flagImage;
    public List<Sprite> sprites = new List<Sprite>();
    public List<Text> languageTexts = new List<Text>();
    public List<LanguageDatasMainObject> defaultLanguageDatasMainObjects = new List<LanguageDatasMainObject>();
    public List<LanguageDatasMainObject> languageDatasMainObjects = new List<LanguageDatasMainObject>();
    List<LanguageDatasMainObject> ReadingLanguageDatas = new List<LanguageDatasMainObject>();


    void Start()
    {
        librariy.CheckKey();
        dataManager.FirstSave(defaultItemDatas, defaultLanguageDatasMainObjects);

        dataManager.LoadLang();
        ReadingLanguageDatas = dataManager.TakeLangCostume();
        languageDatasMainObjects.Add(ReadingLanguageDatas[0]);
        ChangeLanguage();
        LanguageButtonControl();
        soundFirst();

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
                flagImage.sprite = sprites[0];
                break;
            case "TR":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_TR[i].String;
                }
                flagImage.sprite = sprites[1];
                break;
            case "AZ":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_AZ[i].String;
                }
                flagImage.sprite = sprites[2];
                break;
            case "JP":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_JP[i].String;
                }
                flagImage.sprite = sprites[3];
                break;
            case "KR":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_KR[i].String;
                }
                flagImage.sprite = sprites[4];
                break;
            case "AL":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_AL[i].String;
                }
                flagImage.sprite = sprites[5];
                break;
            case "HN":
                for (int i = 0; i < languageTexts.Count; i++)
                {
                    languageTexts[i].text = languageDatasMainObjects[0].languesDatas_HN[i].String;
                }
                flagImage.sprite = sprites[6];
                break;


        }
    }
    private void Update()
    {
        audioSources.volume = librariy.GetData_Float("FX");
    }
    public void TapToContinueButton()
    {
        SceneManager.LoadScene(librariy.GetData_Int("LastLevel"));
    }
    public void SceneChange(int index)
    {
        if (index == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if (index == 1)
        {
            SceneManager.LoadScene(2);
        }
    }
    void LanguageButtonControl()
    {
        if (librariy.GetData_Int("ImageIndex") == 6)
            Buttons[1].interactable = false;
        else if (librariy.GetData_Int("ImageIndex") == 0)
            Buttons[0].interactable = false;
    }
    public void LanguageButtons(bool bf)
    {
        if (bf == true)
        {
            librariy.SetData_Int("ImageIndex", librariy.GetData_Int("ImageIndex") + 1);
            switch (librariy.GetData_Int("ImageIndex"))
            {
                case 0:
                    librariy.SetData_String("Language", "EN");
                    Buttons[0].interactable = false;
                    Buttons[1].interactable = true;
                    break;
                case 1:
                    librariy.SetData_String("Language", "TR");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = true;
                    break;
                case 2:
                    librariy.SetData_String("Language", "AZ");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = true;
                    break;
                case 3:
                    librariy.SetData_String("Language", "JP");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = true;
                    break;
                case 4:
                    librariy.SetData_String("Language", "KR");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = true;
                    break;
                case 5:
                    librariy.SetData_String("Language", "AL");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = true;
                    break;
                case 6:
                    librariy.SetData_String("Language", "HN");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = false;
                    break;
            }
            ChangeLanguage();
        }
        else
        {
            librariy.SetData_Int("ImageIndex", librariy.GetData_Int("ImageIndex") - 1);
            switch (librariy.GetData_Int("ImageIndex"))
            {
                case 0:
                    librariy.SetData_String("Language", "EN");
                    Buttons[0].interactable = false;
                    Buttons[1].interactable = true;
                    break;
                case 1:
                    librariy.SetData_String("Language", "TR");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = true;
                    break;
                case 2:
                    librariy.SetData_String("Language", "AZ");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = true;
                    break;
                case 3:
                    librariy.SetData_String("Language", "JP");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = true;
                    break;
                case 4:
                    librariy.SetData_String("Language", "KR");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = true;
                    break;
                case 5:
                    librariy.SetData_String("Language", "AL");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = true;
                    break;
                case 6:
                    librariy.SetData_String("Language", "HN");
                    Buttons[0].interactable = true;
                    Buttons[1].interactable = false;
                    break;
            }
            ChangeLanguage();
        }
    }
    #region Sound
    public void Sounds()
    {
        audioSources.Play();
    }
    void soundFirst()
    {
        sliders[0].value = librariy.GetData_Float("GameSound");
        sliders[1].value = librariy.GetData_Float("FX");
    }
    public void SoundsSetting(int index)
    {
        switch (index)
        {
            case 0:

                librariy.SetData_Float("GameSound", sliders[0].value);
                break;
            case 1:
                librariy.SetData_Float("FX", sliders[1].value);
                break;
        }
    }
    #endregion
}
