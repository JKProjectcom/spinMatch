using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.EventSystems;

public class StartSceneManager : MonoBehaviour
{
    public EventSystem eventSystem;
    public PlayerPrefsManager playerPrefsManager;
    public LocalizeStartManager localizeStartManager;
    public FadeManager fadeManager;
    public SeManager seManager;

    public GameObject languagePanel;
    public List<Button> langButtonList;

    public GameObject policyPanel;

    public GameObject handOverPanel;
    public GameObject handOverButton;
    public GameObject handOverSuccessPanel;
    public GameObject handOverFailurePanel;
    public Button handOverCancelButton;
    public Button handOverOkButton;
    public InputField handOverCodeInputField;

    public string status;
    public float logoTime;

    public string selectedLanguage;

    public bool isInitialFrame = true;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });
    }

    public void InitialFrame()
    {
        if(isInitialFrame)
        {

            if (playerPrefsManager.GetFirstPlay() == "true")
            {
                SetInitialData();
            }

            isInitialFrame = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        InitialFrame();
        if(status == "logoChange")
        {
            // ロゴを切り替える
            logoTime += Time.deltaTime;

            if(logoTime > 1)
            {
                seManager.SoundGameStartSe();
                localizeStartManager.ChangeLogo();
                logoTime = 0;

                fadeManager.StartFade("TopScene");
                status = "goTop";
            }
        }
    }

    // どこかクリックされたとき
    public void ClickStartScene()
    {
        handOverButton.SetActive(false);

        if (playerPrefsManager.GetFirstPlay() == "true")
        {
            // 最初のプレイ
            languagePanel.SetActive(true);
            selectedLanguage = "en";
            return;
        }

        status = "logoChange";
    }

    // いずれかの言語の押下
    public void ClickLanguageButton()
    {
        seManager.SoundClickSe();
        GameObject button = eventSystem.currentSelectedGameObject.gameObject;
        ChangeButtonColor(button);

        selectedLanguage = button.name;
    }

    // 言語設定OKボタン
    public void ClickOkLanguage()
    {
        seManager.SoundClickSe();
        playerPrefsManager.SetLanguage(selectedLanguage);
        localizeStartManager.SetText();

        languagePanel.SetActive(false);
        policyPanel.SetActive(true);
    }

    // プライバシーポリシー確認ボタン
    public void ClickConfirmPolicy()
    {
        string url = "https://jkprojectcom.wixsite.com/jkproject/post/mold-fitting-puzzle-privacy-policy";
        Application.OpenURL(url);
    }

    // プライバシーポリシーOKボタン
    public void ClickOkPolicy()
    {
        seManager.SoundClickSe();
        playerPrefsManager.SetConfirmPolicy("true");
        playerPrefsManager.SetFirstPlay("false");

        fadeManager.StartFade("TopScene");
    }

    // データ引き継ぎボタン
    public void ClickHandOver()
    {
        seManager.SoundChoiceSe();
        handOverPanel.SetActive(true);
        handOverButton.SetActive(false);
    }

    // データ引き継ぎキャンセルボタン
    public void ClickHandOverCancel()
    {
        seManager.SoundReturnSe();
        handOverPanel.SetActive(false);
        handOverButton.SetActive(true);
    }

    // データ引き継ぎOKボタン
    public void ClickHandOverOk()
    {
        seManager.SoundClickSe();
        if (HandOver() == "success")
        {
            handOverSuccessPanel.SetActive(true);
        }
        else
        {
            handOverFailurePanel.SetActive(true);
        }
    }

    // データ引き継ぎ成功OKボタン
    public void ClickHandOverSeccessOk()
    {
        seManager.SoundClickSe();
        fadeManager.StartFade("TopScene");
    }

    // データ引き継ぎ失敗OKボタン
    public void ClickHandOverFailureOk()
    {
        seManager.SoundClickSe();
        handOverFailurePanel.SetActive(false);
    }


    // データの引き継ぎとその成功失敗を返す
    public string HandOver()
    {
        string code = handOverCodeInputField.text;

        if(code == "")
        {
            return "failure";
        }

        var levelArray = code.Split('.');
        if(levelArray.Length != 4)
        {
            return "failure";
        }

        int level = 0;
        int volcanoLevel = 0;
        int shipLevel = 0;
        int forestLevel = 0;

        bool isConvertLevel = int.TryParse(levelArray[0], out level);
        bool isConvertVolcanoLevel = int.TryParse(levelArray[1], out volcanoLevel);
        bool isConvertShipLevel = int.TryParse(levelArray[2], out shipLevel);
        bool isConvertForestLevel = int.TryParse(levelArray[3], out forestLevel);

        if(!isConvertLevel || !isConvertVolcanoLevel || !isConvertShipLevel || !isConvertForestLevel)
        {
            return "failure";
        }

        int calLevel = (level + 284) / 45 - 123;
        int calVolcanoLevel = (volcanoLevel + 941) / 81 - 84;
        int calShipLevel = (shipLevel + 1538) / 23 - 427;
        int calForestLevel = (forestLevel + 3402) / 76 - 299;

        if(!(calLevel == calVolcanoLevel || calLevel-1 == calVolcanoLevel))
        {
            return "failure";
        }
        if (!(calLevel == calShipLevel || calLevel - 1 == calShipLevel))
        {
            return "failure";
        }
        if (!(calLevel == calForestLevel || calLevel - 1 == calForestLevel))
        {
            return "failure";
        }

        ApplyHandOverData(calLevel, calVolcanoLevel, calShipLevel, calForestLevel);

        return "success";
    }

    public void ApplyHandOverData(int level, int volcanoLevel, int shipLevel, int forestLevel)
    {
        playerPrefsManager.SetPlayerLevel(level);
        playerPrefsManager.SetClearedLevelVolcano(volcanoLevel);
        playerPrefsManager.SetClearedLevelShip(shipLevel);
        playerPrefsManager.SetClearedLevelForest(forestLevel);

        int hp = level * 500;
        int attack = level * 5;
        int heal = level * 5;

        playerPrefsManager.SetMold_1("rod_2,"+hp+","+attack+","+heal+",empty");
        playerPrefsManager.SetMold_2("square_4," + hp + "," + attack + "," + heal + ",empty");
        playerPrefsManager.SetSkill_1("skillPowerUp_1.2," + hp + "," + attack + "," + heal + ",empty,8");
        playerPrefsManager.SetSkill_2("skillHealUp_1.2," + hp + "," + attack + "," + heal + ",empty,8");

        playerPrefsManager.SetBgmVolume(-10);
        playerPrefsManager.SetSeVolume(-10);
    }

    // このゲームを最初に起動したときに各データをセットしておく
    public void SetInitialData()
    {
        playerPrefsManager.SetPlayerLevel(1);

        playerPrefsManager.SetMold_1("rod_2,500,5,5,empty");
        playerPrefsManager.SetMold_2("square_4,500,5,5,empty");
        playerPrefsManager.SetSkill_1("skillPowerUp_1.2,500,5,5,empty,8");
        playerPrefsManager.SetSkill_2("skillHealUp_1.2,500,5,5,empty,8");

        playerPrefsManager.SetClearedLevelVolcano(0);
        playerPrefsManager.SetClearedLevelShip(0);
        playerPrefsManager.SetClearedLevelForest(0);

        playerPrefsManager.SetBgmVolume(-10);
        playerPrefsManager.SetSeVolume(-10);
    }

    private void SetTestData()
    {
        int level = 101;
        int hp = level * 700;
        int at = level * 7;
        playerPrefsManager.SetPlayerLevel(level);
        playerPrefsManager.SetMold_1("rod_2," + hp + "," + at + "," + at + ",skillTurn");
        playerPrefsManager.SetMold_2("square_4," + hp + "," + at + "," + at + ",empty");
        playerPrefsManager.SetSkill_1("skillPinkRed," + hp + "," + at + "," + at + ",empty,7");
        playerPrefsManager.SetSkill_2("skillRedBlue," + hp + "," + at + "," + at + ",empty,8");
        playerPrefsManager.SetClearedLevelVolcano(level);
        playerPrefsManager.SetClearedLevelShip(level);
        playerPrefsManager.SetClearedLevelForest(level);
    }

    public void ChangeButtonColor(GameObject selectedButton)
    {
        foreach (var langButton in langButtonList)
        {
            langButton.image.color = new Color32(180, 180, 180, 255);
        }

        selectedButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public List<int> GetRawData(string[] levelArray)
    {
        int convertLevel = int.Parse(levelArray[0]);
        int convertVolcanoLevel = int.Parse(levelArray[1]);
        int convertShipLevel = int.Parse(levelArray[2]);
        int convertForestLevel = int.Parse(levelArray[3]);

        int level = (convertLevel + 284) / 45 - 123;
        int volcanoLevel = (convertVolcanoLevel + 941) / 81 - 84;
        int shipLevel = (convertShipLevel + 1538) / 23 - 427;
        int forestLevel = (convertForestLevel + 3402) / 76 - 299;

        return new List<int> { level, volcanoLevel, shipLevel, forestLevel };
    }
}
