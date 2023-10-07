using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeStartManager : MonoBehaviour
{
    public PlayerPrefsManager playerPrefsManager;
    public TextManager textManager;

    public Text handOverFailureTitle;
    public Text handOverFailureDesc;
    public Text handOverSuccessTitle;
    public Text handOverSuccessDesc;
    public Text handOverTitle;
    public Text handOverDesc;
    public Text handOverCode;
    public Text confirmPolicyTitle;
    public Text confirmPolicyDesc;
    public Text confirmPolicyButtonText;
    public Text handOverButtonText;

    public Image logoImage;

    public Sprite enTopLogoSprite;
    public Sprite enBottomLogoSprite;
    public Sprite jaTopLogoSprite;
    public Sprite jaBottomLogoSprite;
    public Sprite koTopLogoSprite;
    public Sprite koBottomLogoSprite;
    public Sprite zhcnTopLogoSprite;
    public Sprite zhcnBottomLogoSprite;
    public Sprite zhtwTopLogoSprite;
    public Sprite zhtwBottomLogoSprite;
    
    void Start()
    {
        SetText();

        SetImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText()
    {
        handOverFailureTitle.text = textManager.GetLocalizeText("データ引き継ぎ失敗");
        handOverFailureDesc.text = textManager.GetLocalizeText("引き継ぎコードを確認して、再度お試しください。");
        handOverSuccessTitle.text = textManager.GetLocalizeText("データ引き継ぎ完了");
        handOverSuccessDesc.text = textManager.GetLocalizeText("全てのデータが引き継がれているわけではございません。");
        handOverTitle.text = textManager.GetLocalizeText("データ引き継ぎ");
        handOverDesc.text = textManager.GetLocalizeText("引き継ぎコードを入力して、OKを押してください。");
        handOverCode.text = textManager.GetLocalizeText("引き継ぎコード");
        confirmPolicyTitle.text = textManager.GetLocalizeText("プライバシーポリシー");
        confirmPolicyDesc.text = textManager.GetLocalizeText("プライバシーポリシーを確認して、OKを押してください。");
        confirmPolicyButtonText.text = textManager.GetLocalizeText("プライバシーポリシーをWebサイトで確認する");
        handOverButtonText.text = textManager.GetLocalizeText("データ引き継ぎ");
    }

    public void SetImage()
    {
        string lang = playerPrefsManager.GetLanguage();
        switch (lang)
        {
            case "ja":
                logoImage.sprite = jaTopLogoSprite;
                break;
            case "en":
                logoImage.sprite = enTopLogoSprite;
                break;
            case "zh-cn":
                logoImage.sprite = zhcnTopLogoSprite;
                break;
            case "zh-tw":
                logoImage.sprite = zhtwTopLogoSprite;
                break;
            case "ko":
                logoImage.sprite = koTopLogoSprite;
                break;
            default:
                logoImage.sprite = enTopLogoSprite;
                break;
        }
    }

    public void ChangeLogo()
    {
        string lang = playerPrefsManager.GetLanguage();
        switch (lang)
        {
            case "ja":
                logoImage.sprite = jaBottomLogoSprite;
                break;
            case "en":
                logoImage.sprite = enBottomLogoSprite;
                break;
            case "zh-cn":
                logoImage.sprite = zhcnBottomLogoSprite;
                break;
            case "zh-tw":
                logoImage.sprite = zhtwBottomLogoSprite;
                break;
            case "ko":
                logoImage.sprite = koBottomLogoSprite;
                break;
            default:
                logoImage.sprite = enBottomLogoSprite;
                break;
        }
    }
}
