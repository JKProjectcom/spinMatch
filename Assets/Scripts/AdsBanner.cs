using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdsBanner : MonoBehaviour
{
    // バナー用

    private BannerView bannerView;
    public void Start()
    {
        this.RequestBanner();
    }
    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3270275203457200/4988069034";
#elif UNITY_IPHONE
    string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
    string adUnitId = "unexpected_platform";
#endif
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest();
        bannerView.LoadAd(request);
    }
}