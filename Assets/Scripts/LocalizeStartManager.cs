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
        handOverFailureTitle.text = textManager.GetLocalizeText("�f�[�^�����p�����s");
        handOverFailureDesc.text = textManager.GetLocalizeText("�����p���R�[�h���m�F���āA�ēx���������������B");
        handOverSuccessTitle.text = textManager.GetLocalizeText("�f�[�^�����p������");
        handOverSuccessDesc.text = textManager.GetLocalizeText("�S�Ẵf�[�^�������p����Ă���킯�ł͂������܂���B");
        handOverTitle.text = textManager.GetLocalizeText("�f�[�^�����p��");
        handOverDesc.text = textManager.GetLocalizeText("�����p���R�[�h����͂��āAOK�������Ă��������B");
        handOverCode.text = textManager.GetLocalizeText("�����p���R�[�h");
        confirmPolicyTitle.text = textManager.GetLocalizeText("�v���C�o�V�[�|���V�[");
        confirmPolicyDesc.text = textManager.GetLocalizeText("�v���C�o�V�[�|���V�[���m�F���āAOK�������Ă��������B");
        confirmPolicyButtonText.text = textManager.GetLocalizeText("�v���C�o�V�[�|���V�[��Web�T�C�g�Ŋm�F����");
        handOverButtonText.text = textManager.GetLocalizeText("�f�[�^�����p��");
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
