using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AleynaRotatingCar
{
    public class Librariy
    {
        public void CheckKey()
        {
            if (!PlayerPrefs.HasKey("LastLevel"))
            {
                PlayerPrefs.SetInt("LastLevel", 2);
                PlayerPrefs.SetInt("Diaomond", 0);
                PlayerPrefs.SetInt("ActiveGroup1Image", 0);
                PlayerPrefs.SetInt("ActiveGroup2Image", 0);
                PlayerPrefs.SetInt("ActiveGroup3Image", 0);
                PlayerPrefs.SetInt("ActiveGroup4Image", 0);
                PlayerPrefs.SetString("Language", "EN");
                PlayerPrefs.SetInt("ImageIndex", 0);
                PlayerPrefs.SetFloat("GameSound",.5f);
                PlayerPrefs.SetFloat("FX", .5f);

            }
        }
        #region SetDatas
        public void SetData_Int(string KeyName, int KeyData)
        {
            PlayerPrefs.SetInt(KeyName, KeyData);
            PlayerPrefs.Save();
        }
        public void SetData_String(string KeyName, string KeyData)
        {
            PlayerPrefs.SetString(KeyName, KeyData);
            PlayerPrefs.Save();
        }
        public void SetData_Float(string KeyName, float KeyData)
        {
            PlayerPrefs.SetFloat(KeyName, KeyData);
            PlayerPrefs.Save();
        }
        #endregion
        #region GetDatas
        public int GetData_Int(string KeyName)
        {
            return PlayerPrefs.GetInt(KeyName);
        }
        public string GetData_String(string KeyName)
        {
            return PlayerPrefs.GetString(KeyName);
        }
        public float GetData_Float(string KeyName)
        {
            return PlayerPrefs.GetFloat(KeyName);
        }
        #endregion
    }
    public class DataManager
    {
        public void FirstSave(List<ItemDatas> ýtemDatas,List<LanguageDatasMainObject> languageDatasMainObjects)
        {
            if (!File.Exists(Application.persistentDataPath + "/ItemDatas.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/ItemDatas.gd");
                bf.Serialize(file, ýtemDatas);
                file.Close();
            }
            if (!File.Exists(Application.persistentDataPath + "/LanguageDatas.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/LanguageDatas.gd");
                bf.Serialize(file, languageDatasMainObjects);
                file.Close();
            }
        }
        public void Save(List<ItemDatas> ýtemDatas)
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.persistentDataPath + "/ItemDatas.gd");
            bf.Serialize(file, ýtemDatas);
            file.Close();
        }

        List<ItemDatas> ýtemDatas2;
        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/ItemDatas.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/ItemDatas.gd", FileMode.Open);
                ýtemDatas2 = (List<ItemDatas>)bf.Deserialize(file);
                file.Close();
            }
        }
        List<LanguageDatasMainObject> loadDatas2;
        public void LoadLang()
        {
            if (File.Exists(Application.persistentDataPath + "/LanguageDatas.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/LanguageDatas.gd", FileMode.Open);
                loadDatas2 = (List<LanguageDatasMainObject>)bf.Deserialize(file);
                file.Close();
            }
        }
        public List<ItemDatas> TakeListCostume()
        {
            return ýtemDatas2;
        }
        public List<LanguageDatasMainObject> TakeLangCostume()
        {
            return loadDatas2;
        }
    }

    [Serializable]
    public class ItemDatas
    {
        public int Group;
        public int ItemIndex;
        public int DiamondPoint;
        public bool BuyResult;
        public string ItemName;
    }
   
    [Serializable]
    public class LanguageDatasMainObject
    {
        
        public List<LanguesDatas_En> languesDatas_EN = new List<LanguesDatas_En>();
        public List<LanguesDatas_En> languesDatas_TR = new List<LanguesDatas_En>();
        public List<LanguesDatas_En> languesDatas_AZ = new List<LanguesDatas_En>();
        public List<LanguesDatas_En> languesDatas_JP = new List<LanguesDatas_En>();
        public List<LanguesDatas_En> languesDatas_KR = new List<LanguesDatas_En>();
        public List<LanguesDatas_En> languesDatas_AL = new List<LanguesDatas_En>();
        public List<LanguesDatas_En> languesDatas_HN = new List<LanguesDatas_En>();
    }
    [Serializable]
    public class LanguesDatas_En
    {
        public string String;
    }

}

