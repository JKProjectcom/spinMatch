using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizePuzzleManager : MonoBehaviour
{
    public TextManager textManager;

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
        string textName = this.name;

        switch (textName)
        {
            case "InfoTitleText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("プレイヤー情報");
                return;
            case "SpEffectTitleText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("特殊効果");
                return;
            case "AbnormalTitleText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("パラメータ異常・状態異常");
                return;
            case "BootyDescText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("装備するものを2つ選んでください");
                return;
            case "BootyText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("戦利品");
                return;
            case "MoldMagTitle":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("倍率");
                return;
            case "AdsDescText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("動画広告説明");
                return;
            case "SeeAdsText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("広告を見る");
                return;
            case "AdsErrorText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("広告失敗");
                return;
            case "AdsSuccessText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("広告成功");
                return;
            case "LoseText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("敗北アドバイス");
                return;
        }
    }
}
