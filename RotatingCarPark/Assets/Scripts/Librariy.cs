using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AleynaRotatingCar
{
    public class Librariy 
    {
        public void CheckKey()
        {
            if (!PlayerPrefs.HasKey("LastLevel"))
            {
                PlayerPrefs.SetInt("LastLevel", 1);
                PlayerPrefs.SetInt("Diaomond", 0);
                
            }
        }
        #region SetDatas
        public void SetData_Int(string KeyName,int KeyData)
        {
            PlayerPrefs.SetInt(KeyName,KeyData);
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
}

