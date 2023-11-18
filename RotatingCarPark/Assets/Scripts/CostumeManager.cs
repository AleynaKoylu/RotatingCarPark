using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AleynaRotatingCar;

public class CostumeManager : MonoBehaviour
{
    public List<GameObject> Panels = new List<GameObject>();
    int PanelIndex = -1;
    Librariy librariy = new Librariy();
    public Text buyText;
    DataManager dataManager = new DataManager();
    public List<ItemDatas> ýtemDatas = new List<ItemDatas>();
    
    [Header("Group1")]
    public List<Sprite> Group1Image = new List<Sprite>();
    int Group1Index = 7;
    public Image MainImageGroup1;
    public List<Button> Group1BackForwardButtons = new List<Button>();

    [Header("---Group2---")]
   public List<Sprite> Group2Image = new List<Sprite>();
      int Group2Index =0;
    public Image MainImageGroup2;
    public List<Button> Group2BackForwardButtons = new List<Button>();

    [Header("---Group3---")]
    public List<Sprite> Group3Image = new List<Sprite>();
    int Group3Index = 0;
    public Image MainImageGroup3;
    public List<Button> Group3BackForwardButtons = new List<Button>();


    [Header("---Group4---")]
    public List<Sprite> Group4Image = new List<Sprite>();
    int Group4Index = 0;
    public Image MainImageGroup4;
    public List<Button> Group4BackForwardButtons = new List<Button>();
    void Start()
    {

        librariy.SetData_Int("ActiveGroup1Image", 7);
        librariy.SetData_Int("ActiveGroup2Image", 0);
        librariy.SetData_Int("ActiveGroup3Image", 0);
        librariy.SetData_Int("ActiveGroup4Image", 0);
       
        if (librariy.GetData_Int("ActiveGroup1Image") == 0)
        {
            Group1Index = 0;
            MainImageGroup1.sprite = Group1Image[librariy.GetData_Int("ActiveGroup1Image")];
            Group1BackForwardButtons[0].interactable = false;
        }
       
        else if(librariy.GetData_Int("ActiveGroup1Image") == 7)
        {
            Group1BackForwardButtons[1].interactable = false;
            MainImageGroup1.sprite = Group1Image[librariy.GetData_Int("ActiveGroup1Image")];
        }
        else
        {
            Group1Index = librariy.GetData_Int("ActiveGroup1Image");
            MainImageGroup1.sprite = Group1Image[librariy.GetData_Int("ActiveGroup1Image")];

        }


        dataManager.Load();
        ýtemDatas = dataManager.TakeListCostume();
        // Save();
        //Load();
        // CheckButtons(0);
    }
 

    public void Group1Buttons(bool BackForward)
    {
        #region ForwardButton
        if (BackForward == true)
        {
            if (Group1Index == 0)
            {
                Group1Index=1;
                MainImageGroup1.sprite = Group1Image[Group1Index];
                buyText.text = ýtemDatas[Group1Index].DiamondPoint.ToString(); 
            }
            else
            {
                Group1Index++;
                MainImageGroup1.sprite = Group1Image[Group1Index];
                buyText.text = ýtemDatas[Group1Index].DiamondPoint.ToString();
            }
            if (Group1Index == Group1Image.Count - 1)
            
                Group1BackForwardButtons[1].interactable = false;
            
            else
                Group1BackForwardButtons[1].interactable = true;
            
            if (Group1Index != 0)
                Group1BackForwardButtons[0].interactable = true;
        }

        #endregion

         else
         {
            if (Group1Index != 0)
            {
                Group1Index--;
                MainImageGroup1.sprite = Group1Image[Group1Index];
                buyText.text = ýtemDatas[Group1Index].DiamondPoint.ToString();

                if (Group1Index != 0)
                {
                    MainImageGroup1.sprite = Group1Image[Group1Index];
                    Group1BackForwardButtons[0].interactable = true;
                    buyText.text = ýtemDatas[Group1Index].DiamondPoint.ToString();

                }
                else
                {
                    MainImageGroup1.sprite = Group1Image[Group1Index];
                    Group1BackForwardButtons[0].interactable = false;
                    buyText.text = ýtemDatas[Group1Index].DiamondPoint.ToString();
                }
            }
            else
            {
                MainImageGroup1.sprite = Group1Image[Group1Index];
                Group1BackForwardButtons[0].interactable = false;
                buyText.text = ýtemDatas[Group1Index].DiamondPoint.ToString();
            }
            if (Group1Index != Group1Image.Count - 1)

                Group1BackForwardButtons[1].interactable = true;
        }
    }


    #region Panels
    public void OpenPanels(int index)
    {
        PanelIndex = index;
        Panels[index].SetActive(true);
        Panels[4].SetActive(true);
        Panels[5].SetActive(false);
    }
    public void BackGame()
    {
        Panels[6].SetActive(false);
    }
    public void ClosePanels()
    {
        Panels[PanelIndex].SetActive(false);
        Panels[4].SetActive(false);
        Panels[5].SetActive(true);


    }
    #endregion
}

