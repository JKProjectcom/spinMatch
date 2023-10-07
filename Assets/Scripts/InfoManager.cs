using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public PuzzleMain puzzleMain;
    public PlayerPrefsManager playerPrefsManager;
    public PlayerStatusManager playerStatusManager;
    public SpEffectManager spEffectManager;
    public SeManager seManager;

    public GameObject infoPanel;

    public Text playerLevelText;
    public Text playerHpText;
    public Text playerAttackText;
    public Text playerHealText;
    public Text playerSpEffectText;
    public Text abnormalText;

    public Button infoButton;
    public Button backButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 情報パネルに必要な情報をセットする
    public void SetInfo()
    {
        // レベル、HP、攻撃力、回復力のセット
        playerLevelText.text = playerPrefsManager.GetPlayerLevel().ToString();
        playerHpText.text = playerStatusManager.userCurrentHp + "(" + playerStatusManager.GetPlayerHp() + ")";
        playerAttackText.text = playerStatusManager.userCurrentAttackPower + "(" + playerStatusManager.GetPlayerAttack() + ")";
        playerHealText.text = playerStatusManager.userCurrentHealPower + "(" + playerStatusManager.GetPlayerHeal() + ")";

        // 装備の情報
        string[] moldInfo_1 = playerStatusManager.GetMoldInfo_1();
        string[] moldInfo_2 = playerStatusManager.GetMoldInfo_2();
        string[] skillInfo_1 = playerStatusManager.GetSkillInfo_1();
        string[] skillInfo_2 = playerStatusManager.GetSkillInfo_2();

        
        string moldSp_1 = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(moldInfo_1));
        string moldSp_2 = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(moldInfo_2));
        string skillSp_1 = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(skillInfo_1));
        string skillSp_2 = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(skillInfo_2));

        // 特殊効果のセット
        string spEffect = "";
        int spCount = 0;
        if(moldSp_1 != "")
        {
            spCount++;
            spEffect += "・" + moldSp_1 + "\r\n" ;
        }
        if (moldSp_2 != "")
        {
            spCount++;
            spEffect += "・" + moldSp_2 + "\r\n";
        }
        if (skillSp_1 != "")
        {
            spCount++;
            spEffect += "・" + skillSp_1 + "\r\n";
        }
        if (skillSp_2 != "")
        {
            spCount++;
            spEffect += "・" + skillSp_2;
        }

        if(spCount == 0)
        {
            // 特殊効果なし
            spEffect = "ー";
        }
        else if(spCount < 4)
        {
            for (var i = 0; i < 3 - spCount; i++)
            {
                spEffect += "\r\n";
            }
        }

        playerSpEffectText.text = spEffect;

        // 状態・パラメータ異常のセット
        string text = "";
        string name = "";
        for(var i = 0; i < playerStatusManager.abnormalList_1.Count;  i++)
        {
            // 残り1ターンのもの
            name = playerStatusManager.abnormalList_1[i];
            text += "・" + playerStatusManager.GetAbnormalName(name) + "(1)" + "「" + playerStatusManager.GetAbnormalDesc(name)+ "」" + "\r\n";
        }

        for (var i = 0; i < playerStatusManager.abnormalList_2.Count; i++)
        {
            // 残り2ターンのもの
            name = playerStatusManager.abnormalList_2[i];
            text += "・" + playerStatusManager.GetAbnormalName(name) + "(2)" + "「" + playerStatusManager.GetAbnormalDesc(name) + "」" + "\r\n";
        }

        for (var i = 0; i < playerStatusManager.abnormalList_3.Count; i++)
        {
            // 残り3ターンのもの
            name = playerStatusManager.abnormalList_3[i];
            text += "・" + playerStatusManager.GetAbnormalName(name) + "(3)" + "「" + playerStatusManager.GetAbnormalDesc(name) + "」" + "\r\n";
        }

        if (text == "")
        {
            // 異常がない場合
            abnormalText.text = "ー";
        }
        else
        {
            abnormalText.text = text.Remove(text.Length - 1);
        }
    }

    // 情報パネルを表示する
    public void ActivateInfoPanel()
    {
        puzzleMain.InactivateAllParts();
        playerStatusManager.InactivatePara();
        playerStatusManager.InactivateDarkness();
        infoPanel.SetActive(true);
        SetInfo();
        puzzleMain.attackBar_1.SetActive(false);
        puzzleMain.attackBar_2.SetActive(false);

        seManager.SoundChoiceSe();
    }

    // 情報パネルを非表示にする
    public void InactivateInfoPanel()
    {
        puzzleMain.ActivateAllParts();
        playerStatusManager.ActivatePara();
        playerStatusManager.ActivateDarkness();
        infoPanel.SetActive(false);
        puzzleMain.attackBar_1.SetActive(true);
        puzzleMain.attackBar_2.SetActive(true);

        seManager.SoundReturnSe();
    }
}
