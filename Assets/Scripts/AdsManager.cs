using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Google AdMob Initial
        MobileAds.Initialize(initStatus => { });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
