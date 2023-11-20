using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AleynaRotatingCar;
using UnityEngine.SceneManagement;
public class CostumeManager : MonoBehaviour
{

    [Header("---General---")]
    public List<GameObject> Panels = new List<GameObject>();
    int PanelIndex = -1;
    public Text buyText,diamondaText;
    public List<Button> GeneralButtons = new List<Button>();

    [Header("---Save----")]
    Librariy librariy = new Librariy();
    DataManager dataManager = new DataManager();
    public List<ItemDatas> ýtemDatas = new List<ItemDatas>();
    [Header("Group1")]
    public List<Sprite> Group1Image = new List<Sprite>();
    int Group1Index = 0;
    public Image MainImageGroup1;
    public List<Button> Group1BackForwardButtons = new List<Button>();

    [Header("---Group2---")]
    public List<Sprite> Group2Image = new List<Sprite>();
    int Group2Index = 0;
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
        //MainMenuLevelleredevamýný izle.
        diamondaText.text = librariy.GetData_Int("Diaomond").ToString() ;
        librariy.SetData_Int("ActiveGroup1Image", 0);
        librariy.SetData_Int("ActiveGroup2Image", 0);
        librariy.SetData_Int("ActiveGroup3Image", 0);
        librariy.SetData_Int("ActiveGroup4Image", 0);

        //dataManager.FirstSave(ýtemDatas);
        dataManager.Load();
        ýtemDatas = dataManager.TakeListCostume();
        // Save();
        //Load();
        // CheckButtons(0);
    }


    #region Buttons

    public void Group1Buttons(bool BackForward)
    {
        #region ForwardButton
        if (BackForward == true)
        {
            if (Group1Index == 0)
            {
                Group1Index = 1;
                MainImageGroup1.sprite = Group1Image[Group1Index];
                if (ýtemDatas[Group1Index].BuyResult == false)
                {
                    buyText.text = ýtemDatas[Group1Index].DiamondPoint.ToString();
                    GeneralButtons[0].interactable = true;
                    GeneralButtons[1].interactable = false;
                }
                else
                {
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;
                }
            }
            else
            {
                Group1Index++;
                MainImageGroup1.sprite = Group1Image[Group1Index];
                if (ýtemDatas[Group1Index].BuyResult == false)
                {
                    buyText.text = ýtemDatas[Group1Index].DiamondPoint.ToString();
                    GeneralButtons[0].interactable = true;
                    GeneralButtons[1].interactable = false;
                }
                else
                {
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;
                }


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

                if (Group1Index != 0)
                {
                    MainImageGroup1.sprite = Group1Image[Group1Index];
                    Group1BackForwardButtons[0].interactable = true;
                    if (ýtemDatas[Group1Index].BuyResult == false)
                    {
                        buyText.text = ýtemDatas[Group1Index].DiamondPoint.ToString();
                        GeneralButtons[0].interactable = true;
                        GeneralButtons[1].interactable = false;
                    }
                    else
                    {
                        buyText.text = "0";
                        GeneralButtons[0].interactable = false;
                        GeneralButtons[1].interactable = true;
                    }
                }
                else
                {
                    MainImageGroup1.sprite = Group1Image[Group1Index];
                    Group1BackForwardButtons[0].interactable = false;
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;
                }
            }
            else
            {
                MainImageGroup1.sprite = Group1Image[Group1Index];
                Group1BackForwardButtons[0].interactable = false;
                buyText.text = "0";
                GeneralButtons[0].interactable = false;
                GeneralButtons[1].interactable = true;

            }
            if (Group1Index != Group1Image.Count - 1)

                Group1BackForwardButtons[1].interactable = true;
        }
    }
    public void Group2Buttons(bool BackForward)
    {
        #region ForwardButton
        if (BackForward == true)
        {
            
            if (Group2Index == 0)
            {
                Group2Index = 1;
                MainImageGroup2.sprite = Group2Image[Group2Index];
                if (ýtemDatas[Group2Index+8].BuyResult == false)
                {
                    buyText.text = ýtemDatas[Group2Index + 8].DiamondPoint.ToString();
                    GeneralButtons[0].interactable = true;
                    GeneralButtons[1].interactable = false;
                }
                else
                {
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;
                }

            }
            else
            {
                Group2Index++;
               
                MainImageGroup2.sprite = Group2Image[Group2Index];
                if (ýtemDatas[Group2Index + 8].BuyResult == false)
                {
                    buyText.text = ýtemDatas[Group2Index + 8].DiamondPoint.ToString();
                    GeneralButtons[0].interactable = true;
                    GeneralButtons[1].interactable = false;
                }
                else
                {
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;
                }

            }
            if (Group2Index == Group2Image.Count - 1)

                Group2BackForwardButtons[1].interactable = false;

            else
                Group2BackForwardButtons[1].interactable = true;

            if (Group2Index != 0)
                Group2BackForwardButtons[0].interactable = true;
        }

        #endregion

        else
        {
            if (Group2Index != 0)
            {
               
                Group2Index--;
                MainImageGroup2.sprite = Group2Image[Group2Index];
                

                if (Group2Index != 0)
                {
                    MainImageGroup2.sprite = Group2Image[Group2Index];
                    Group2BackForwardButtons[0].interactable = true;
                    if (ýtemDatas[Group2Index + 8].BuyResult == false)
                    {
                        buyText.text = ýtemDatas[Group2Index + 8].DiamondPoint.ToString();
                        GeneralButtons[0].interactable = true;
                        GeneralButtons[1].interactable = false;
                    }
                    else
                    {
                        buyText.text = "0";
                        GeneralButtons[0].interactable = false;
                        GeneralButtons[1].interactable = true;
                    }


                }
                else
                {
                    MainImageGroup2.sprite = Group2Image[Group2Index];
                    Group2BackForwardButtons[0].interactable = false;
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;


                }
            }
            else
            {
                MainImageGroup2.sprite = Group2Image[Group2Index];
                Group2BackForwardButtons[0].interactable = false;
                buyText.text = "0";
                GeneralButtons[0].interactable = false;
                GeneralButtons[1].interactable = true;

            }
            if (Group2Index != Group2Image.Count - 1)

                Group2BackForwardButtons[1].interactable = true;
        }
    }
    public void Group3Buttons(bool BackForward)
    {
        #region ForwardButton
        if (BackForward == true)
        {
           
            if (Group3Index == 0)
            {
                Group3Index = 1;
                MainImageGroup3.sprite = Group3Image[Group3Index];
                if (ýtemDatas[Group3Index + 16].BuyResult == false)
                {
                    buyText.text = ýtemDatas[Group3Index + 16].DiamondPoint.ToString();
                    GeneralButtons[0].interactable = true;
                    GeneralButtons[1].interactable = false;
                }
                else
                {
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;
                }

            }
            else
            {
                Group3Index++;
                MainImageGroup3.sprite = Group3Image[Group3Index];
                if (ýtemDatas[Group3Index + 16].BuyResult == false)
                {
                    buyText.text = ýtemDatas[Group3Index + 16].DiamondPoint.ToString();
                    GeneralButtons[0].interactable = true;
                    GeneralButtons[1].interactable = false;
                }
                else
                {
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;
                }

            }
            if (Group3Index == Group3Image.Count - 1)

                Group3BackForwardButtons[1].interactable = false;

            else
                Group3BackForwardButtons[1].interactable = true;

            if (Group3Index != 0)
                Group3BackForwardButtons[0].interactable = true;
        }

        #endregion

        else
        {
            if (Group3Index != 0)
            {
               
                Group3Index--;
                
               MainImageGroup3.sprite = Group3Image[Group3Index];
                

                if (Group3Index != 0)
                {
                    MainImageGroup3.sprite = Group3Image[Group3Index];
                    Group3BackForwardButtons[0].interactable = true;
                    if (ýtemDatas[Group3Index + 16].BuyResult == false)
                    {
                        buyText.text = ýtemDatas[Group3Index + 16].DiamondPoint.ToString();
                        GeneralButtons[0].interactable = true;
                        GeneralButtons[1].interactable = false;
                    }
                    else
                    {
                        buyText.text = "0";
                        GeneralButtons[0].interactable = false;
                        GeneralButtons[1].interactable = true;
                    }


                }
                else
                {
                    MainImageGroup3.sprite = Group3Image[Group3Index];
                    Group3BackForwardButtons[0].interactable = false;
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;

                }
            }
            else
            {
                MainImageGroup3.sprite = Group3Image[Group3Index];
                Group3BackForwardButtons[0].interactable = false;
                buyText.text = "0";
                GeneralButtons[0].interactable = false;
                GeneralButtons[1].interactable = true;

            }
            if (Group3Index != Group3Image.Count - 1)

                Group3BackForwardButtons[1].interactable = true;
        }
    }
    public void Group4Buttons(bool BackForward)
    {
        #region ForwardButton
        if (BackForward == true)
        {
           
            if (Group4Index == 0)
            {
                Group4Index = 1;
                MainImageGroup4.sprite = Group4Image[Group4Index];
                if (ýtemDatas[Group4Index + 24].BuyResult == false)
                {
                    buyText.text = ýtemDatas[Group4Index + 24].DiamondPoint.ToString();
                    GeneralButtons[0].interactable = true;
                    GeneralButtons[1].interactable = false;
                }
                else
                {
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;
                }

            }
            else
            {
                Group4Index++;
                MainImageGroup4.sprite = Group4Image[Group4Index];
                if (ýtemDatas[Group4Index + 24].BuyResult == false)
                {
                    buyText.text = ýtemDatas[Group4Index + 24].DiamondPoint.ToString();
                    GeneralButtons[0].interactable = true;
                    GeneralButtons[1].interactable = false;
                }
                else
                {
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;
                }

            }
            if (Group4Index == Group4Image.Count - 1)

                Group4BackForwardButtons[1].interactable = false;

            else
                Group4BackForwardButtons[1].interactable = true;

            if (Group4Index != 0)
                Group4BackForwardButtons[0].interactable = true;
        }

        #endregion

        else
        {
            if (Group4Index != 0)
            {
                Group4Index--;
               
                MainImageGroup4.sprite = Group4Image[Group4Index];
                

                if (Group4Index != 0)
                {
                    MainImageGroup4.sprite = Group4Image[Group4Index];
                    Group4BackForwardButtons[0].interactable = true;
                    if (ýtemDatas[Group4Index + 24].BuyResult == false)
                    {
                        buyText.text = ýtemDatas[Group4Index + 24].DiamondPoint.ToString();
                        GeneralButtons[0].interactable = true;
                        GeneralButtons[1].interactable = false;
                    }
                    else
                    {
                        buyText.text = "0";
                        GeneralButtons[0].interactable = false;
                        GeneralButtons[1].interactable = true;
                    }


                }
                else
                {
                    MainImageGroup4.sprite = Group4Image[Group4Index];
                    Group4BackForwardButtons[0].interactable = false;
                    buyText.text = "0";
                    GeneralButtons[0].interactable = false;
                    GeneralButtons[1].interactable = true;

                }
            }
            else
            {
                MainImageGroup4.sprite = Group4Image[Group4Index];
                Group4BackForwardButtons[0].interactable = false;
                buyText.text = "0";
                GeneralButtons[0].interactable = false;
                GeneralButtons[1].interactable = true;
            }
            if (Group4Index != Group4Image.Count - 1)

                Group4BackForwardButtons[1].interactable = true;
        }
    }
    #endregion
    #region Panels
    public void OpenPanels(int index)
    {

        PanelIndex = index;
        CheckStatus(PanelIndex);
        Panels[index].SetActive(true);
        Panels[5].SetActive(false);
        Panels[4].SetActive(true);
    }
    public void BackGame()
    {

        switch (PanelIndex)
        {
            case -1:
                SceneManager.LoadScene(librariy.GetData_Int("LastLevel"));
                break;
            case 0:
                Panels[PanelIndex].SetActive(false);
                Panels[5].SetActive(true);
                Panels[4].SetActive(false);
                PanelIndex = -1;
                break;
            case 1:
                Panels[PanelIndex].SetActive(false);
                Panels[5].SetActive(true);
                Panels[4].SetActive(false);
                PanelIndex = -1;
                break;
            case 2:
                Panels[PanelIndex].SetActive(false);
                Panels[5].SetActive(true);
                Panels[4].SetActive(false);
                PanelIndex = -1;
                break;
            case 3:
                Panels[PanelIndex].SetActive(false);
                Panels[5].SetActive(true);
                Panels[4].SetActive(false);
                PanelIndex = -1;
                break;

        }
    }
    #endregion
    #region UseBuy
    void CheckStatus(int Part)
    {
        #region Group1
        if (Part == 0)
        {
            if (librariy.GetData_Int("ActiveGroup1Image") == 0)
            {
                Group1Index = 0;
                MainImageGroup1.sprite = Group1Image[0];
                buyText.text = "0";
                Group1BackForwardButtons[0].interactable = false;
                GeneralButtons[0].interactable = false;
                GeneralButtons[1].interactable = false;
            }
            else if (Group1Index == 7)
            {
                MainImageGroup1.sprite = Group1Image[Group1Index];
                Group1BackForwardButtons[1].interactable = false;
            }
            else
            {
                Group1Index = librariy.GetData_Int("ActiveGroup1Image");
                MainImageGroup1.sprite = Group1Image[librariy.GetData_Int("ActiveGroup1Image")];

            }
        }
        #endregion

        #region Group2
        else if (Part == 1)
        {
            if (librariy.GetData_Int("ActiveGroup2Image") == 0)
            {
                Group2Index = 0;
                MainImageGroup2.sprite = Group2Image[librariy.GetData_Int("ActiveGroup2Image")];
                buyText.text = "0";
                Group2BackForwardButtons[0].interactable = false;
                GeneralButtons[0].interactable = false;
                GeneralButtons[1].interactable = false;

            }

            else if (librariy.GetData_Int("ActiveGroup2Image") == 7)
            {
                Group2BackForwardButtons[1].interactable = false;
                MainImageGroup2.sprite = Group2Image[librariy.GetData_Int("ActiveGroup2Image")];
            }
            else
            {
                Group2Index = librariy.GetData_Int("ActiveGroup2Image");
                MainImageGroup2.sprite = Group2Image[librariy.GetData_Int("ActiveGroup2Image")];

            }
        }

        #endregion
        #region Group3
        else if (Part == 2)
        {
            if (librariy.GetData_Int("ActiveGroup3Image") == 0)
            {
                Group3Index = 0;
                MainImageGroup3.sprite = Group3Image[librariy.GetData_Int("ActiveGroup3Image")];
                buyText.text = "0";
                Group3BackForwardButtons[0].interactable = false;
                GeneralButtons[0].interactable = false;
                GeneralButtons[1].interactable = false;

            }

            else if (librariy.GetData_Int("ActiveGroup3Image") == 7)
            {
                Group3BackForwardButtons[1].interactable = false;
                MainImageGroup3.sprite = Group3Image[librariy.GetData_Int("ActiveGroup3Image")];
            }
            else
            {
                Group3Index = librariy.GetData_Int("ActiveGroup3Image");
                MainImageGroup3.sprite = Group3Image[librariy.GetData_Int("ActiveGroup3Image")];

            }
        }

        #endregion
        #region Group4
        else if (Part == 3)
        {
            if (librariy.GetData_Int("ActiveGroup4Image") == 0)
            {
                Group4Index = 0;
                MainImageGroup4.sprite = Group4Image[librariy.GetData_Int("ActiveGroup4Image")];
                buyText.text = "0";
                Group4BackForwardButtons[0].interactable = false;
                GeneralButtons[0].interactable = false;
                GeneralButtons[1].interactable = false;

            }

            else if (librariy.GetData_Int("ActiveGroup4Image") == 4)
            {
                Group4BackForwardButtons[1].interactable = false;
                MainImageGroup4.sprite = Group4Image[librariy.GetData_Int("ActiveGroup4Image")];
            }
            else
            {
                Group4Index = librariy.GetData_Int("ActiveGroup4Image");
                MainImageGroup4.sprite = Group4Image[librariy.GetData_Int("ActiveGroup4Image")];

            }
        }
        #endregion
    }
    public void Buy()
    {
        if (PanelIndex != -1)
        {
            switch (PanelIndex)
            {
                case 0:
                    print("Bolum No: " + PanelIndex + " ItemIndex: " + Group1Index);
                    break;
                case 1:
                    print("Bolum No: " + PanelIndex + " ItemIndex: " + Group2Index);
                    break;
                case 2:
                    print("Bolum No: " + PanelIndex + " ItemIndex: " + Group3Index);
                    break;
                case 3:
                    print("Bolum No: " + PanelIndex + " ItemIndex: " + Group4Index);
                    break;
            }
        }
        print(PanelIndex);
    }
    public void Use()
    {

    }
    #endregion
}

