using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCoreData : MonoBehaviour
{

    public static UserCoreData instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetAndroidBannerUnitId()
    {
        return "ca-app-pub-3270275203457200/4988069034";
    }

    public string GetAndroidRewardUnitId()
    {
        return "ca-app-pub-3270275203457200/9355238191";
    }

    public string GetPolicyUrl()
    {
        return "https://jkprojectcom.wixsite.com/jkproject/post/mold-fitting-puzzle-privacy-policy";
    }
}
