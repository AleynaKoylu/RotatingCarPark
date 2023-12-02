
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class InterstitialADS : MonoBehaviour
{

  
#if UNITY_ANDROID
        string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
   string _adUnitId ="ca-app-pub-3940256099942544/4411468910";
#else
   string _adUnitId = "unused";
#endif

    private InterstitialAd interstitialAd;
    public void LoadInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }
        var adRequest = new AdRequest();
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
                
            });
        RegisterEventHandlers(interstitialAd);
    }
    public void ShowAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
        }
    }
    private void RegisterEventHandlers(InterstitialAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            LoadInterstitialAd();
        };
    }

}






