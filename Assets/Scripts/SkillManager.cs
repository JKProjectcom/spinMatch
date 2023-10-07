using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public PlayerStatusManager playerStatusManager;
    public TextManager textManager;

    public Sprite skillRedBlue, skillRedGreen, skillRedPink, skillBlueRed, skillBlueGreen, skillBluePink,
        skillGreenRed, skillGreenBlue, skillGreenPink, skillPinkRed, skillPinkBlue, skillPinkGreen,
        skillPowerUp, skillHealUp, skillHealHp, skillHealDebuff, skillHealBadStatus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // スキル名からスキルの説明文を返す
    public string GetSkillDesc(string skillName)
    {
        switch (skillName)
        {
            case "skillRedBlue":
                return textManager.GetLocalizeText("ランダムで火を水に変換する");
            case "skillRedGreen":
                return textManager.GetLocalizeText("ランダムで火を木に変換する");
            case "skillRedPink":
                return textManager.GetLocalizeText("ランダムで火を回復に変換する");
            case "skillBlueRed":
                return textManager.GetLocalizeText("ランダムで水を火に変換する");
            case "skillBlueGreen":
                return textManager.GetLocalizeText("ランダムで水を木に変換する");
            case "skillBluePink":
                return textManager.GetLocalizeText("ランダムで水を回復に変換する");
            case "skillGreenRed":
                return textManager.GetLocalizeText("ランダムで木を火に変換する");
            case "skillGreenBlue":
                return textManager.GetLocalizeText("ランダムで木を水に変換する");
            case "skillGreenPink":
                return textManager.GetLocalizeText("ランダムで木を回復に変換する");
            case "skillPinkRed":
                return textManager.GetLocalizeText("ランダムで回復を火に変換する");
            case "skillPinkBlue":
                return textManager.GetLocalizeText("ランダムで回復を水に変換する");
            case "skillPinkGreen":
                return textManager.GetLocalizeText("ランダムで回復を木に変換する");
            case "skillPowerUp_1.2":
                return textManager.GetLocalizeText("攻撃力を1.2倍にする");
            case "skillPowerUp_1.5":
                return textManager.GetLocalizeText("攻撃力を1.5倍にする");
            case "skillHealUp_1.2":
                return textManager.GetLocalizeText("回復力を1.2倍にする");
            case "skillHealUp_1.5":
                return textManager.GetLocalizeText("回復力を1.5倍にする");
            case "skillHealHp_30":
                return textManager.GetLocalizeText("HPを30%回復する");
            case "skillHealHp_50":
                return textManager.GetLocalizeText("HPを50%回復する");
            case "skillHealDebuff":
                return textManager.GetLocalizeText("パラメータ異常を治す");
            case "skillHealBadStatus":
                return textManager.GetLocalizeText("状態異常を治す");
        }
        return "状態異常を回復する";
    }

    // スキル名からスキルのイラストを返す
    public Sprite GetSkillSprite(string skillName)
    {
        switch (skillName)
        {
            case "skillRedBlue":
                return skillRedBlue;
            case "skillRedGreen":
                return skillRedGreen;
            case "skillRedPink":
                return skillRedPink;
            case "skillBlueRed":
                return skillBlueRed;
            case "skillBlueGreen":
                return skillBlueGreen;
            case "skillBluePink":
                return skillBluePink;
            case "skillGreenRed":
                return skillGreenRed;
            case "skillGreenBlue":
                return skillGreenBlue;
            case "skillGreenPink":
                return skillGreenPink;
            case "skillPinkRed":
                return skillPinkRed;
            case "skillPinkBlue":
                return skillPinkBlue;
            case "skillPinkGreen":
                return skillPinkGreen;
            case "skillPowerUp_1.2":
                return skillPowerUp;
            case "skillPowerUp_1.5":
                return skillPowerUp;
            case "skillHealUp_1.2":
                return skillHealUp;
            case "skillHealUp_1.5":
                return skillHealUp;
            case "skillHealHp_30":
                return skillHealHp;
            case "skillHealHp_50":
                return skillHealHp;
            case "skillHealDebuff":
                return skillHealDebuff;
            case "skillHealBadStatus":
                return skillHealBadStatus;
        }
        return skillHealBadStatus;
    }

    // ランダムにスキルを選んで返す
    public string GetRandomSkill()
    {
        int num = Random.Range(1, 101);

        if(num <= 4)
        {
            return "skillRedBlue";
        }
        else if(num <= 8)
        {
            return "skillRedGreen";
        }
        else if (num <= 13)
        {
            return "skillRedPink";
        }
        else if (num <= 17)
        {
            return "skillBlueRed";
        }
        else if (num <= 21)
        {
            return "skillBlueGreen";
        }
        else if (num <= 26)
        {
            return "skillBluePink";
        }
        else if (num <= 30)
        {
            return "skillGreenRed";
        }
        else if (num <= 34)
        {
            return "skillGreenBlue";
        }
        else if (num <= 39)
        {
            return "skillGreenPink";
        }
        else if (num <= 44)
        {
            return "skillPinkRed";
        }
        else if (num <= 49)
        {
            return "skillPinkBlue";
        }
        else if (num <= 54)
        {
            return "skillPinkGreen";
        }
        else if (num <= 62)
        {
            return "skillPowerUp_1.2";
        }
        else if (num <= 68)
        {
            return "skillPowerUp_1.5";
        }
        else if (num <= 76)
        {
            return "skillHealUp_1.2";
        }
        else if (num <= 82)
        {
            return "skillHealUp_1.5";
        }
        else if (num <= 85)
        {
            return "skillHealHp_30";
        }
        else if (num <= 88)
        {
            return "skillHealHp_50";
        }
        else if (num <= 94)
        {
            return "skillHealDebuff";
        }
        else if (num <= 100)
        {
            return "skillHealBadStatus";
        }

        return "";
    }

    // スキルでのHP回復をする
    public void SkillHealHp(int ratio)
    {
        // 回復量
        int healPoint = (int)(playerStatusManager.userMaxHp * ratio / 100);

        playerStatusManager.userCurrentHp += (int)healPoint;
        if (playerStatusManager.userCurrentHp > playerStatusManager.userMaxHp)
        {
            // 最大HPを上回って回復した場合は最大HPにする
            playerStatusManager.userCurrentHp = playerStatusManager.userMaxHp;
        }

        playerStatusManager.ChangeHp();
    }
}
