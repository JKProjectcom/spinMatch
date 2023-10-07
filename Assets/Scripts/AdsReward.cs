using System;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class AdsReward : MonoBehaviour
{
    public PlayerPrefsManager playerPrefsManager;
    public TextManager textManager;

    public GameObject GotRewardPanel;
    public Text GotRewardText;

    public GameObject ErrorRewardPanel;
    public Text ErrorRewardText;

    public Button SeeAdsButton;
    public Text adsDescText;
    public Text seeAdsText;

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private const string _adUnitId = "ca-app-pub-3270275203457200/9355238191";
#elif UNITY_IPHONE
        private const string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        private const string _adUnitId = "unused";
#endif

    private RewardedAd _rewardedAd;


    public void Start()
    {
        if (LoadAd() == "error")
        {
            // é∏îséûÇÕÇ‡Ç§àÍìxì«Ç›çûÇﬁ
            LoadAd();
        }

        SetRewardPanel();
    }

    public void Update()
    {

    }

    public void SetRewardPanel()
    {
        GotRewardText.text = textManager.GetLocalizeText("çLçêê¨å˜");
        ErrorRewardText.text = textManager.GetLocalizeText("çLçêé∏îs");
    }

    public void ActivateGotRewardPanel()
    {
        GotRewardPanel.SetActive(true);
    }

    public void InactivateGotRewardPanel()
    {
        GotRewardPanel.SetActive(false);
    }
    public void ActivateErrorRewardPanel()
    {
        ErrorRewardPanel.SetActive(true);
    }

    public void InactivateErrorRewardPanel()
    {
        ErrorRewardPanel.SetActive(false);
    }

    // ìÆâÊçLçêÇå©ÇÈÉ{É^Éìâüâ∫
    public void ClickSeeReward()
    {
        ShowAd();
    }

    /// <summary>
    /// Loads the ad.
    /// </summary>
    // çLçêÇì«Ç›çûÇﬁÅBì«Ç›çûÇ›ÇÃåãâ Çï‘Ç∑ÅB
    public string LoadAd()
    {
        // Clean up the old ad before loading a new one.
        if (_rewardedAd != null)
        {
            DestroyAd();
        }

        // Create our request used to load the ad.
        var adRequest = new AdRequest();

        string loadResult = "error";

        // Send the request to load the ad.
        RewardedAd.Load(_adUnitId, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            // If the operation failed with a reason.
            if (error != null)
            {
                return;
            }
            // If the operation failed for unknown reasons.
            // This is an unexpected error, please report this bug if it happens.
            if (ad == null)
            {
                return;
            }

            // The operation completed successfully.
            _rewardedAd = ad;

            // Register to ad events to extend functionality.
            RegisterEventHandlers(ad);
            loadResult = "success";
        });

        return loadResult;
    }

    /// <summary>
    /// Shows the ad.
    /// </summary>
    public void ShowAd()
    {
        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                Debug.Log(String.Format("Rewarded ad granted a reward: {0} {1}",
                                        reward.Amount,
                                        reward.Type));
            });
        }
        else
        {
            // çLçêÇÃï\é¶Ç™Ç≈Ç´Ç»Ç¢èÍçá
            ActivateErrorRewardPanel();
        }
    }

    /// <summary>
    /// Destroys the ad.
    /// </summary>
    public void DestroyAd()
    {
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }
    }

    /// <summary>
    /// Logs the ResponseInfo.
    /// </summary>
    public void LogResponseInfo()
    {
        if (_rewardedAd != null)
        {
            var responseInfo = _rewardedAd.GetResponseInfo();
        }
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
        };
        // Raised when the ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            // çLçêéãíÆéûçèÇï€ë∂Ç∑ÇÈ
            DateTime now = DateTime.Now;
            playerPrefsManager.SetAdsTimeString(now.ToString());

            ActivateGotRewardPanel();
            SeeAdsButton.interactable = false;
            seeAdsText.enabled = false;
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
        };
    }
}
