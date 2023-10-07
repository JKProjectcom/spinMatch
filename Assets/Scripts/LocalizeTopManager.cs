using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeTopManager : MonoBehaviour
{
    public TextManager textManager;

    public Text volcanoTitle;
    public Text volcanoCleared;
    public Text volcanoChallenge;
    public Text shipTitle;
    public Text shipCleared;
    public Text shipChallenge;
    public Text forestTitle;
    public Text forestCleared;
    public Text forestChallenge;
    public Text bossTitle;
    public Text bossCleared;
    public Text bossChallenge;
    public Text magTitle_1;
    public Text magTitle_2;
    public Text bgm;
    public Text se;
    public Text langTitle;
    public Text langDesc;
    public Text policyTitle;
    public Text policyButtonText;
    public Text handOverCodeTitle;
    public Text handOverCodeButtonText;
    public Text handOverDesc;
    public Text copyrightText;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText()
    {
        volcanoTitle.text = textManager.GetLocalizeText("火山");
        volcanoCleared.text = textManager.GetLocalizeText("クリア済み");
        volcanoChallenge.text = textManager.GetLocalizeText("挑戦レベル");
        shipTitle.text = textManager.GetLocalizeText("船");
        shipCleared.text = textManager.GetLocalizeText("クリア済み");
        shipChallenge.text = textManager.GetLocalizeText("挑戦レベル");
        forestTitle.text = textManager.GetLocalizeText("森林");
        forestCleared.text = textManager.GetLocalizeText("クリア済み");
        forestChallenge.text = textManager.GetLocalizeText("挑戦レベル");
        bossTitle.text = textManager.GetLocalizeText("ボス");
        bossCleared.text = textManager.GetLocalizeText("クリア済み");
        bossChallenge.text = textManager.GetLocalizeText("挑戦レベル");
        magTitle_1.text = textManager.GetLocalizeText("倍率");
        magTitle_2.text = textManager.GetLocalizeText("倍率");
        bgm.text = textManager.GetLocalizeText("BGM音量");
        se.text = textManager.GetLocalizeText("SE音量");
        langTitle.text = textManager.GetLocalizeText("言語");
        langDesc.text = textManager.GetLocalizeText("OKを押すと言語が切り替わります。一度ゲームのトップに戻ります。");
        policyTitle.text = textManager.GetLocalizeText("プライバシーポリシー");
        policyButtonText.text = textManager.GetLocalizeText("プライバシーポリシーをWebサイトで確認する");
        handOverCodeTitle.text = textManager.GetLocalizeText("引き継ぎコード");
        handOverCodeButtonText.text = textManager.GetLocalizeText("コード生成");
        handOverDesc.text = textManager.GetLocalizeText("引き継ぎ方法の説明");
        copyrightText.text = textManager.GetLocalizeText("コピーライト等");
    }
}
