using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AleynaRotatingCar;
public class MainMenuManager : MonoBehaviour
{
    public List<Button> Buttons = new List<Button>();
    Librariy librariy = new Librariy();
    public List<ItemDatas> �temDatas = new List<ItemDatas>();
    DataManager dataManager = new DataManager();
    void Start()
    {
       librariy.CheckKey();
        //dataManager.FirstSave(�temDatas);
    }

    void Update()
    { 
    }
    public void TapToContinueButton()
    {
        SceneManager.LoadScene(librariy.GetData_Int("LastLevel"));
    }
}
