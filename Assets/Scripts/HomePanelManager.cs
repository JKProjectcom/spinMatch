using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanelManager : MonoBehaviour
{
    public PlayerStatusManager playerStatusManager;
    public PlayerPrefsManager playerPrefsManager;
    public TutorialManager tutorialManager;
    public SkillManager skillManager;
    public MoldManager moldManager;
    public SpEffectManager spEffectManager;
    public SeManager seManager;

    public GameObject homePanel;
    public GameObject equipmentPanel;
    public GameObject settingPanel;
    public GameObject infoPanel;

    public GameObject homePanelSquare;

    public Image moldImage_1;
    public Image moldImage_2;
    public Image skillImage_1;
    public Image skillImage_2;

    public Text moldHp_1;
    public Text moldAttack_1;
    public Text moldHeal_1;
    public Text moldSpEffect_1;
    public Text moldMag_1;

    public Text moldHp_2;
    public Text moldAttack_2;
    public Text moldHeal_2;
    public Text moldSpEffect_2;
    public Text moldMag_2;

    public Text skillDesc_1;
    public Text skillTurn_1;
    public Text skillHp_1;
    public Text skillAttack_1;
    public Text skillHeal_1;
    public Text skillSpEffect_1;

    public Text skillDesc_2;
    public Text skillTurn_2;
    public Text skillHp_2;
    public Text skillAttack_2;
    public Text skillHeal_2;
    public Text skillSpEffect_2;

    public InputField handOverInputField;

    public Button bgm_0;
    public Button bgm_1;
    public Button bgm_2;
    public Button bgm_3;
    public Button bgm_4;
    public Button bgm_5;

    public Button se_0;
    public Button se_1;
    public Button se_2;
    public Button se_3;
    public Button se_4;
    public Button se_5;

    // Start is called before the first frame update
    void Start()
    {
        SetEquipmentInfo();
        SetSetting();

        InactivateHomePanel();
        InactivateHomeAllPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ホームパネルを表示する
    public void ActivateHomePanel()
    {
        homePanel.SetActive(true);
    }

    // ホームパネルを非表示にする
    public void InactivateHomePanel()
    {
        homePanel.SetActive(false);
    }

    // ホームパネルの全てのパネルを非表示にする
    public void InactivateHomeAllPanel()
    {
        equipmentPanel.SetActive(false);
        settingPanel.SetActive(false);
        infoPanel.SetActive(false);
    }

    // BGMの音量ボタンを全て暗くする
    public void DarkenAllBgmVolumeButton()
    {
        bgm_0.image.color = new Color32(255, 255, 255, 100);
        bgm_1.image.color = new Color32(255, 255, 255, 100);
        bgm_2.image.color = new Color32(255, 255, 255, 100);
        bgm_3.image.color = new Color32(255, 255, 255, 100);
        bgm_4.image.color = new Color32(255, 255, 255, 100);
        bgm_5.image.color = new Color32(255, 255, 255, 100);
    }

    // SEの音量ボタンを全て暗くする
    public void DarkenAllSeVolumeButton()
    {
        se_0.image.color = new Color32(255, 255, 255, 100);
        se_1.image.color = new Color32(255, 255, 255, 100);
        se_2.image.color = new Color32(255, 255, 255, 100);
        se_3.image.color = new Color32(255, 255, 255, 100);
        se_4.image.color = new Color32(255, 255, 255, 100);
        se_5.image.color = new Color32(255, 255, 255, 100);
    }

    // 引数音量ボタンを明るくする。それ以外は暗くする。
    public void BrightenVolumeButton(string type, int volume)
    {
        if (type == "bgm")
        {
            DarkenAllBgmVolumeButton();

            switch(volume)
            {
                case 0:
                    bgm_0.image.color = new Color32(255, 255, 255, 255);
                    return;
                case 1:
                    bgm_1.image.color = new Color32(255, 255, 255, 255);
                    return;
                case 2:
                    bgm_2.image.color = new Color32(255, 255, 255, 255);
                    return;
                case 3:
                    bgm_3.image.color = new Color32(255, 255, 255, 255);
                    return;
                case 4:
                    bgm_4.image.color = new Color32(255, 255, 255, 255);
                    return;
                case 5:
                    bgm_5.image.color = new Color32(255, 255, 255, 255);
                    return;
            }

        }else if(type == "se")
        {
            DarkenAllSeVolumeButton();

            switch (volume)
            {
                case 0:
                    se_0.image.color = new Color32(255, 255, 255, 255);
                    return;
                case 1:
                    se_1.image.color = new Color32(255, 255, 255, 255);
                    return;
                case 2:
                    se_2.image.color = new Color32(255, 255, 255, 255);
                    return;
                case 3:
                    se_3.image.color = new Color32(255, 255, 255, 255);
                    return;
                case 4:
                    se_4.image.color = new Color32(255, 255, 255, 255);
                    return;
                case 5:
                    se_5.image.color = new Color32(255, 255, 255, 255);
                    return;
            }
        }
    }

    // 装備ボタン押下
    public void clickEquipment()
    {
        seManager.SoundChoiceSe();
        InactivateHomeAllPanel();
        equipmentPanel.SetActive(true);
    }
    // 設定ボタン押下
    public void clickSetting()
    {
        seManager.SoundChoiceSe();
        InactivateHomeAllPanel();
        settingPanel.SetActive(true);
    }
    // 情報ボタン押下
    public void clickInfo()
    {
        seManager.SoundChoiceSe();
        InactivateHomeAllPanel();
        infoPanel.SetActive(true);
    }
    // 引き継ぎコード生成ボタン押下
    public void ClickCreateHandoverCode()
    {
        seManager.SoundClickSe();
        handOverInputField.text = GetConvertData();
    }
    // 戻るボタン押下
    public void clickReturn()
    {
        seManager.SoundReturnSe();
        InactivateHomePanel();
        InactivateHomeAllPanel();
    }
    // ホームボタン押下
    public void ClickHome()
    {
        seManager.SoundChoiceSe();
        ActivateHomePanel();
        InactivateHomeAllPanel();
        equipmentPanel.SetActive(true);

        if(playerPrefsManager.GetFirstHome() == "true")
        {
            // 最初にホームを訪れたらチュートリアル
            tutorialManager.StartHomeTutorial();
        }
    }

    // 引き継ぎコード生成
    public string GetConvertData()
    {
        int level = playerPrefsManager.GetPlayerLevel();
        int volcanoLevel = playerPrefsManager.GetClearedLevelVolcano();
        int shipLevel = playerPrefsManager.GetClearedLevelShip();
        int forestLevel = playerPrefsManager.GetClearedLevelForest();

        int convertLevel = (level + 123) * 45 -284;
        int convertVolcanoLevel = (volcanoLevel + 84) * 81- 941;
        int convertShipLevel = (shipLevel + 427) * 23 -1538;
        int convertForestLevel = (forestLevel + 299) * 76- 3402;

        return convertLevel.ToString() + "." + convertVolcanoLevel.ToString() + "." + convertShipLevel.ToString() + "." + convertForestLevel.ToString();
    }

    // 装備の情報をセットする
    public void SetEquipmentInfo()
    {
        string[] moldInfo_1 = playerStatusManager.GetMoldInfo_1();
        string[] moldInfo_2 = playerStatusManager.GetMoldInfo_2();
        string[] skillInfo_1 = playerStatusManager.GetSkillInfo_1();
        string[] skillInfo_2 = playerStatusManager.GetSkillInfo_2();

        moldHp_1.text = playerStatusManager.GetEquipmentHp(moldInfo_1);
        moldHp_2.text = playerStatusManager.GetEquipmentHp(moldInfo_2);
        skillHp_1.text = playerStatusManager.GetEquipmentHp(skillInfo_1);
        skillHp_2.text = playerStatusManager.GetEquipmentHp(skillInfo_2);

        moldAttack_1.text = playerStatusManager.GetEquipmentPower(moldInfo_1);
        moldAttack_2.text = playerStatusManager.GetEquipmentPower(moldInfo_2);
        skillAttack_1.text = playerStatusManager.GetEquipmentPower(skillInfo_1);
        skillAttack_2.text = playerStatusManager.GetEquipmentPower(skillInfo_2);

        moldHeal_1.text = playerStatusManager.GetEquipmentHeal(moldInfo_1);
        moldHeal_2.text = playerStatusManager.GetEquipmentHeal(moldInfo_2);
        skillHeal_1.text = playerStatusManager.GetEquipmentHeal(skillInfo_1);
        skillHeal_2.text = playerStatusManager.GetEquipmentHeal(skillInfo_2);

        string moldName_1 = playerStatusManager.GetEquipmentName(moldInfo_1);
        string moldName_2 = playerStatusManager.GetEquipmentName(moldInfo_2);

        moldMag_1.text = moldManager.GetMoldMagnification(moldName_1).ToString();
        moldMag_2.text = moldManager.GetMoldMagnification(moldName_2).ToString();

        string skillName_1 = playerStatusManager.GetEquipmentName(skillInfo_1);
        string skillName_2 = playerStatusManager.GetEquipmentName(skillInfo_2);

        skillDesc_1.text = skillManager.GetSkillDesc(skillName_1);
        skillDesc_2.text = skillManager.GetSkillDesc(skillName_2);

        skillTurn_1.text = playerStatusManager.GetSkillTurn(skillInfo_1);
        skillTurn_2.text = playerStatusManager.GetSkillTurn(skillInfo_2);

        string moldSpEffectName_1 = playerStatusManager.GetEquipmentSpEffect(moldInfo_1);
        string moldSpEffectName_2 = playerStatusManager.GetEquipmentSpEffect(moldInfo_2);
        string skillSpEffectName_1 = playerStatusManager.GetEquipmentSpEffect(skillInfo_1);
        string skillSpEffectName_2 = playerStatusManager.GetEquipmentSpEffect(skillInfo_2);

        moldSpEffect_1.text = spEffectManager.GetSpEffectDesc(moldSpEffectName_1);
        moldSpEffect_2.text = spEffectManager.GetSpEffectDesc(moldSpEffectName_2);
        skillSpEffect_1.text = spEffectManager.GetSpEffectDesc(skillSpEffectName_1);
        skillSpEffect_2.text = spEffectManager.GetSpEffectDesc(skillSpEffectName_2);

        moldImage_1.sprite = moldManager.GetMoldSprite(playerStatusManager.GetEquipmentName(moldInfo_1));
        moldImage_2.sprite = moldManager.GetMoldSprite(playerStatusManager.GetEquipmentName(moldInfo_2));
        skillImage_1.sprite = skillManager.GetSkillSprite(playerStatusManager.GetEquipmentName(skillInfo_1));
        skillImage_2.sprite = skillManager.GetSkillSprite(playerStatusManager.GetEquipmentName(skillInfo_2));
    }

    // 設定をセットする
    public void SetSetting()
    {
        float bgmVolume = playerPrefsManager.GetBgmVolume();
        float seVolume = playerPrefsManager.GetSeVolume();

        switch (bgmVolume)
        {
            case -80:
                BrightenVolumeButton("bgm", 0);
                break;
            case -20:
                BrightenVolumeButton("bgm", 1);
                break;
            case -10:
                BrightenVolumeButton("bgm", 2);
                break;
            case 0:
                BrightenVolumeButton("bgm", 3);
                break;
            case 5:
                BrightenVolumeButton("bgm", 4);
                break;
            case 10:
                BrightenVolumeButton("bgm", 5);
                break;
        }

        switch (seVolume)
        {
            case -80:
                BrightenVolumeButton("se", 0);
                break;
            case -20:
                BrightenVolumeButton("se", 1);
                break;
            case -10:
                BrightenVolumeButton("se", 2);
                break;
            case 0:
                BrightenVolumeButton("se", 3);
                break;
            case 5:
                BrightenVolumeButton("se", 4);
                break;
            case 10:
                BrightenVolumeButton("se", 5);
                break;
        }
    }
}
