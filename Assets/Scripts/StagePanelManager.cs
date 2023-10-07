using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StagePanelManager : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public SeManager seManager;
    public PlayerPrefsManager playerPrefsManager;
    public FadeManager fadeManager;

    public Image castleImage;
    public GameObject castleButton;

    public GameObject VolcanoPanel;
    public GameObject ShipPanel;
    public GameObject ForestPanel;
    public GameObject CastlePanel;

    public Text clearedLevelVolcanoText;
    public Text clearedLevelShipText;
    public Text clearedLevelForestText;
    public Text clearedLevelBossText;
    public Text choiceLevelVolcanoText;
    public Text choiceLevelShipText;
    public Text choiceLevelForestText;
    public Text choiceLevelBossText;

    public Button addLevelVolcano_1;
    public Button addLevelVolcano_10;
    public Button subtractLevelVolcano_1;
    public Button subtractLevelVolcano_10;
    public Button addLevelShipText_1;
    public Button addLevelShipText_10;
    public Button subtractLevelShip_1;
    public Button subtractLevelShip_10;
    public Button addLevelForestText_1;
    public Button addLevelForestText_10;
    public Button subtractLevelForest_1;
    public Button subtractLevelForest_10;
    public Button addLevelBossText_1;
    public Button addLevelBossText_10;
    public Button subtractLevelBoss_1;
    public Button subtractLevelBoss_10;


    // Start is called before the first frame update
    void Start()
    {
        InactivateStagePanel();
        castleImage.enabled = false;

        SetVolcanoPanel();
        SetShipPanel();
        SetForestPanel();
        SetBossPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ステージパネルを全て非表示にする
    public void InactivateStagePanel()
    {
        VolcanoPanel.SetActive(false);
        ShipPanel.SetActive(false);
        ForestPanel.SetActive(false);
        CastlePanel.SetActive(false);
    }

    // 火山ボタン押下時
    public void ClickVolcano()
    {
        if (VolcanoPanel.activeSelf)
        {
            return;
        }

        seManager.SoundChoiceSe();

        InactivateStagePanel();
        
        VolcanoPanel.SetActive(true);
    }
    // 船ボタン押下時
    public void ClickShip()
    {
        if (ShipPanel.activeSelf)
        {
            return;
        }

        seManager.SoundChoiceSe();

        InactivateStagePanel();

        ShipPanel.SetActive(true);
    }
    // 森ボタン押下時
    public void ClickForest()
    {
        if (ForestPanel.activeSelf)
        {
            return;
        }

        seManager.SoundChoiceSe();

        InactivateStagePanel();

        ForestPanel.SetActive(true);
    }
    // 城ボタン押下時
    public void ClickCastle()
    {
        if (CastlePanel.activeSelf)
        {
            return;
        }

        seManager.SoundChoiceSe();

        InactivateStagePanel();

        CastlePanel.SetActive(true);
    }
    // 火山レベル+1ボタン押下時
    public void ClickAddVolcanoLevel_1()
    {
        AddStageLevel("volcano", 1);
    }
    // 火山レベル+10ボタン押下時
    public void ClickAddVolcanoLevel_10()
    {
        AddStageLevel("volcano", 10);
    }
    // 火山レベル-1ボタン押下時
    public void ClickSubtractVolcanoLevel_1()
    {
        SubtractStageLevel("volcano", 1);
    }
    // 火山レベル-10ボタン押下時
    public void ClickSubtractVolcanoLevel_10()
    {
        SubtractStageLevel("volcano", 10);
    }
    // 海レベル+1ボタン押下時
    public void ClickAddShipLevel_1()
    {
        AddStageLevel("ship", 1);
    }
    // 海レベル+10ボタン押下時
    public void ClickAddShipLevel_10()
    {
        AddStageLevel("ship", 10);
    }
    // 海レベル-1ボタン押下時
    public void ClickSubtractShipLevel_1()
    {
        SubtractStageLevel("ship", 1);
    }
    // 海レベル-10ボタン押下時
    public void ClickSubtractShipLevel_10()
    {
        SubtractStageLevel("ship", 10);
    }
    // 森レベル+1ボタン押下時
    public void ClickAddForestLevel_1()
    {
        AddStageLevel("forest", 1);
    }
    // 森レベル+10ボタン押下時
    public void ClickAddForestLevel_10()
    {
        AddStageLevel("forest", 10);
    }
    // 森レベル-1ボタン押下時
    public void ClickSubtractForestLevel_1()
    {
        SubtractStageLevel("forest", 1);
    }
    // 森レベル-10ボタン押下時
    public void ClickSubtractForestLevel_10()
    {
        SubtractStageLevel("forest", 10);
    }
    // ボスレベル+1ボタン押下時
    public void ClickAddBossLevel_1()
    {
        AddStageLevel("boss", 1);
    }
    // ボスレベル+10ボタン押下時
    public void ClickAddBossLevel_10()
    {
        AddStageLevel("boss", 10);
    }
    // ボスレベル-1ボタン押下時
    public void ClickSubtractBossLevel_1()
    {
        SubtractStageLevel("boss", 1);
    }
    // ボスレベル-10ボタン押下時
    public void ClickSubtractBossLevel_10()
    {
        SubtractStageLevel("boss", 10);
    }
    // 火山ステージのプレイボタン押下時
    public void ClickPlayVolcano()
    {
        seManager.SoundWalkSe();

        // プレイするステージの種類とレベルを保存
        playerPrefsManager.SetPlayStageType("volcano");
        int playLevel = int.Parse(choiceLevelVolcanoText.text);
        playerPrefsManager.SetPlayLevel(playLevel);

        fadeManager.StartFade("VolcanoScene");
    }
    // 船ステージのプレイボタン押下時
    public void ClickPlayShip()
    {
        seManager.SoundWalkSe();

        // プレイするステージの種類とレベルを保存
        playerPrefsManager.SetPlayStageType("ship");
        int playLevel = int.Parse(choiceLevelShipText.text);
        playerPrefsManager.SetPlayLevel(playLevel);

        fadeManager.StartFade("ShipScene");
    }
    // 森林ステージのプレイボタン押下時
    public void ClickPlayForest()
    {
        seManager.SoundWalkSe();

        // プレイするステージの種類とレベルを保存
        playerPrefsManager.SetPlayStageType("forest");
        int playLevel = int.Parse(choiceLevelForestText.text);
        playerPrefsManager.SetPlayLevel(playLevel);

        fadeManager.StartFade("ForestScene");
    }
    // ボスステージのプレイボタン押下時
    public void ClickPlayBoss()
    {
        seManager.SoundOpenDoorSe();

        // プレイするステージの種類とレベルを保存
        playerPrefsManager.SetPlayStageType("boss");
        int playLevel = int.Parse(choiceLevelBossText.text);
        playerPrefsManager.SetPlayLevel(playLevel);

        fadeManager.StartFade("BossScene");
    }

    // ステージの挑戦レベルを上げる
    public void AddStageLevel(string stageType, int addLevel)
    {
        int setLevel = 0;
        switch (stageType)
        {
            case "forest":
                int forestLevel = int.Parse(choiceLevelForestText.text);
                if((forestLevel + addLevel) > playerPrefsManager.GetPlayerLevel())
                {
                    // 加算した結果プレイヤーレベル（挑戦可能上限レベル）を超えた場合はプレイヤーレベルとする
                    setLevel = playerPrefsManager.GetPlayerLevel();
                }
                else
                {
                    // 超えていなければそのまま表示する
                    setLevel = forestLevel + addLevel;
                }
                choiceLevelForestText.text = setLevel.ToString();
                break;
            case "ship":
                int shipLevel = int.Parse(choiceLevelShipText.text);
                if ((shipLevel + addLevel) > playerPrefsManager.GetPlayerLevel())
                {
                    // 加算した結果プレイヤーレベル（挑戦可能上限レベル）を超えた場合はプレイヤーレベルとする
                    setLevel = playerPrefsManager.GetPlayerLevel();
                }
                else
                {
                    // 超えていなければそのまま表示する
                    setLevel = shipLevel + addLevel;
                }
                choiceLevelShipText.text = setLevel.ToString();
                break;
            case "volcano":
                int volcanoLevel = int.Parse(choiceLevelVolcanoText.text);
                if ((volcanoLevel + addLevel) > playerPrefsManager.GetPlayerLevel())
                {
                    // 加算した結果プレイヤーレベル（挑戦可能上限レベル）を超えた場合はプレイヤーレベルとする
                    setLevel = playerPrefsManager.GetPlayerLevel();
                }
                else
                {
                    // 超えていなければそのまま表示する
                    setLevel = volcanoLevel + addLevel;
                }
                choiceLevelVolcanoText.text = setLevel.ToString();
                break;
            case "boss":
                int bossLevel = int.Parse(choiceLevelBossText.text);
                if ((bossLevel + addLevel) > playerPrefsManager.GetPlayerLevel())
                {
                    // 加算した結果プレイヤーレベル（挑戦可能上限レベル）を超えた場合はプレイヤーレベルとする
                    setLevel = playerPrefsManager.GetPlayerLevel();
                }
                else
                {
                    // 超えていなければそのまま表示する
                    setLevel = bossLevel + addLevel;
                }
                choiceLevelBossText.text = setLevel.ToString();
                break;
        }
    }
    // ステージの挑戦レベルを下げる
    public void SubtractStageLevel(string stageType, int subtractLevel)
    {
        int setLevel = 0;
        switch (stageType)
        {
            case "forest":
                int forestLevel = int.Parse(choiceLevelForestText.text);
                if ((forestLevel - subtractLevel) < 1)
                {
                    setLevel = 1;
                }
                else
                {
                    // 超えていなければそのまま表示する
                    setLevel = forestLevel - subtractLevel;
                }
                choiceLevelForestText.text = setLevel.ToString();
                break;
            case "ship":
                int shipLevel = int.Parse(choiceLevelShipText.text);
                if ((shipLevel - subtractLevel) < 1)
                {
                    setLevel = 1;
                }
                else
                {
                    // 超えていなければそのまま表示する
                    setLevel = shipLevel - subtractLevel;
                }
                choiceLevelShipText.text = setLevel.ToString();
                break;
            case "volcano":
                int volcanoLevel = int.Parse(choiceLevelVolcanoText.text);
                if ((volcanoLevel - subtractLevel) < 1)
                {
                    setLevel = 1;
                }
                else
                {
                    // 超えていなければそのまま表示する
                    setLevel = volcanoLevel - subtractLevel;
                }
                choiceLevelVolcanoText.text = setLevel.ToString();
                break;
            case "boss":
                int bossLevel = int.Parse(choiceLevelBossText.text);
                if ((bossLevel - subtractLevel) < 1)
                {
                    setLevel = 1;
                }
                else
                {
                    // 超えていなければそのまま表示する
                    setLevel = bossLevel - subtractLevel;
                }
                choiceLevelBossText.text = setLevel.ToString();
                break;
        }
    }

    // 火山ステージのテキストをセットする
    public void SetVolcanoPanel()
    {
        clearedLevelVolcanoText.text = playerPrefsManager.GetClearedLevelVolcano().ToString();
        choiceLevelVolcanoText.text = playerPrefsManager.GetPlayerLevel().ToString();
    }
    // 海ステージのテキストをセットする
    public void SetShipPanel()
    {
        clearedLevelShipText.text = playerPrefsManager.GetClearedLevelShip().ToString();
        choiceLevelShipText.text = playerPrefsManager.GetPlayerLevel().ToString();
    }
    // 森ステージのテキストをセットする
    public void SetForestPanel()
    {
        clearedLevelForestText.text = playerPrefsManager.GetClearedLevelForest().ToString();
        choiceLevelForestText.text = playerPrefsManager.GetPlayerLevel().ToString();
    }
    // ボスステージのテキストをセットし挑戦権があれば表示する
    public void SetBossPanel()
    {
        clearedLevelBossText.text = (playerPrefsManager.GetPlayerLevel() - 1).ToString();
        choiceLevelBossText.text = playerPrefsManager.GetPlayerLevel().ToString();

        if(IsBossAppear())
        {
            castleImage.enabled = true;
            castleButton.SetActive(true);

            if (playerPrefsManager.GetFirstBossAppear() == "true")
            {
                // 最初のボスが出現したらチュートリアル
                tutorialManager.StartBossAppearTutorial();
            }
        }
    }

    // ボスへの挑戦権があるか返す
    public bool IsBossAppear()
    {
        // プレイヤーレベルと3ステージの到達レベルが同じであればボスステージに挑戦可能
        int playerLevel = playerPrefsManager.GetPlayerLevel();
        if (playerLevel == playerPrefsManager.GetClearedLevelVolcano()
            && playerLevel == playerPrefsManager.GetClearedLevelShip()
            && playerLevel == playerPrefsManager.GetClearedLevelForest())
        {
            return true;
        }

        return false;
    }
}
