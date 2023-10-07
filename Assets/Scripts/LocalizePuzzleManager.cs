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
                this.GetComponent<Text>().text = textManager.GetLocalizeText("�v���C���[���");
                return;
            case "SpEffectTitleText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("�������");
                return;
            case "AbnormalTitleText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("�p�����[�^�ُ�E��Ԉُ�");
                return;
            case "BootyDescText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("����������̂�2�I��ł�������");
                return;
            case "BootyText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("�험�i");
                return;
            case "MoldMagTitle":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("�{��");
                return;
            case "AdsDescText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("����L������");
                return;
            case "SeeAdsText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("�L��������");
                return;
            case "AdsErrorText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("�L�����s");
                return;
            case "AdsSuccessText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("�L������");
                return;
            case "LoseText":
                this.GetComponent<Text>().text = textManager.GetLocalizeText("�s�k�A�h�o�C�X");
                return;
        }
    }
}
