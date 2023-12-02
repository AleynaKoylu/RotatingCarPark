using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class ADSManager : MonoBehaviour
{

    private InterstitialADS interstitial;
    private RewardAD reward;
    private static GameObject instance;
    public Texture2D sprt;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);


        interstitial = GetComponent<InterstitialADS>();
        reward = GetComponent<RewardAD>();
    }

    private void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            interstitial.LoadInterstitialAd();
            reward.LoadRewardedAd();

        });
        Cursor.SetCursor(sprt, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void Update()
    {
       
    }
}
   
