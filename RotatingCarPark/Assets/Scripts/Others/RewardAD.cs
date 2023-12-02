using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class RewardAD : MonoBehaviour
{

#if UNITY_ANDROID
    string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
   string _adUnitId ="ca-app-pub-3940256099942544/1712485313";
#else
   string _adUnitId = "unused";
#endif
    private RewardedAd _rewardedAd;

    bool awardActive = false;
  
    public void LoadRewardedAd()
    {
     
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

      
        var adRequest = new AdRequest();

       
        RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
            
              if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                _rewardedAd = ad;
                RegisterEventHandlers(_rewardedAd);

            });
        
    }
    public void ShowRewardedAd(int value,Text text1,Text text2,Button btn)
    {
        

        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {

            _rewardedAd.Show((Reward reward) =>
            {
                if (awardActive == true) 
                {
                    btn.interactable = false;
                    PlayerPrefs.SetInt("Diaomond", PlayerPrefs.GetInt("Diaomond") + value);
                    text1.text = "x" + value;
                    text2.text = "x" + PlayerPrefs.GetInt("Diaomond");
                    awardActive = false;

                }

                Debug.Log("REKLAM GÖRÜLDÜ");
            });
        }
    }
    private void RegisterEventHandlers(RewardedAd ad)
    {
      
        ad.OnAdFullScreenContentClosed += () =>
        {
            LoadRewardedAd();
            awardActive = true;
        };
       
    }
}
 