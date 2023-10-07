using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpEffectManager : MonoBehaviour
{
    public PlayerPrefsManager playerPrefsManager;
    public PlayerStatusManager playerStatusManager;
    public EnemyManager enemyManager;
    public AttackManager attackManager;
    public TextManager textManager;

    // 有効な特殊効果  
    public List<string> spEffectList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        spEffectList = GetAllSpEffect();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetSpEffectDesc(string spEffectName)
    {
        switch(spEffectName)
        {
            case "redKiller_2":
                return textManager.GetLocalizeText("火属性に与えるダメージ+2%");
            case "redKiller_5":
                return textManager.GetLocalizeText("火属性に与えるダメージ+5%");
            case "blueKiller_2":
                return textManager.GetLocalizeText("水属性に与えるダメージ+2%");
            case "blueKiller_5":
                return textManager.GetLocalizeText("水属性に与えるダメージ+5%");
            case "greenKiller_2":
                return textManager.GetLocalizeText("木属性に与えるダメージ+2%");
            case "greenKiller_5":
                return textManager.GetLocalizeText("木属性に与えるダメージ+5%");
            case "erase_10":
                return textManager.GetLocalizeText("パーツを10個以上消すとダメージ+1%");
            case "erase_20":
                return textManager.GetLocalizeText("パーツを20個以上消すとダメージ+3%");
            case "erase_30":
                return textManager.GetLocalizeText("パーツを30個以上消すとダメージ+6%");
            case "erase_40":
                return textManager.GetLocalizeText("パーツを40個以上消すとダメージ+10%");
            case "erase_50":
                return textManager.GetLocalizeText("パーツを50個以上消すとダメージ+20%");
            case "hp_50":
                return textManager.GetLocalizeText("HPが50%以下のとき与えるダメージ+5%");
            case "hp_25":
                return textManager.GetLocalizeText("HPが25%以下のとき与えるダメージ+10%");
            case "abnormalAttackUp_5":
                return textManager.GetLocalizeText("状態異常のとき与えるダメージ+5%");
            case "abnormalAttackUp_10":
                return textManager.GetLocalizeText("状態異常のとき与えるダメージ+10%");
            case "abnormalHealUp_5":
                return textManager.GetLocalizeText("状態異常のときHP回復量+5%");
            case "abnormalHealUp_10":
                return textManager.GetLocalizeText("状態異常のときHP回復量+10%");
            case "redResist_2":
                return textManager.GetLocalizeText("火属性から受けるダメージ-2%");
            case "redResist_5":
                return textManager.GetLocalizeText("火属性から受けるダメージ-5%");
            case "blueResist_2":
                return textManager.GetLocalizeText("水属性から受けるダメージ-2%");
            case "blueResist_5":
                return textManager.GetLocalizeText("水属性から受けるダメージ-5%");
            case "greenResist_2":
                return textManager.GetLocalizeText("木属性から受けるダメージ-2%");
            case "greenResist_5":
                return textManager.GetLocalizeText("木属性から受けるダメージ-5%");
            case "abnormalParameterResist_10":
                return textManager.GetLocalizeText("パラメータ異常にかかる確率-10%");
            case "abnormalParameterResist_20":
                return textManager.GetLocalizeText("パラメータ異常にかかる確率-20%");
            case "abnormalParameterResist_30":
                return textManager.GetLocalizeText("パラメータ異常にかかる確率-30%");
            case "abnormalStatusResist_10":
                return textManager.GetLocalizeText("状態異常にかかる確率-10%");
            case "abnormalStatusResist_20":
                return textManager.GetLocalizeText("状態異常にかかる確率-20%");
            case "abnormalStatusResist_30":
                return textManager.GetLocalizeText("状態異常にかかる確率-30%");
            case "autoHeal_1":
                return textManager.GetLocalizeText("毎ターンHPの1%を回復する");
            case "autoHeal_3":
                return textManager.GetLocalizeText("毎ターンHPの3%を回復する");
            case "survive_5":
                return textManager.GetLocalizeText("HPが0になったとき5%の確率で生き残る");
            case "survive_10":
                return textManager.GetLocalizeText("HPが0になったとき10%の確率で生き残る");
            case "skillTurn":
                return textManager.GetLocalizeText("スキルが発動可能な状態でゲーム開始");
        }
        return "";
    }

    // ランダムに特殊効果の名前を返す
    public string GetRandomSpEffect()
    {
        int num = 0;
        if(enemyManager.enemyType == "gold" ||  enemyManager.enemyType == "silver")
        {
            // 特殊な敵の場合は確定
            num = UnityEngine.Random.Range(2, 89);
        }
        else
        {
            num = UnityEngine.Random.Range(1, 101);
        }
        
        if (2 <= num && num <= 4){
            return "redKiller_2";
        }
        else if(num <= 6)
        {
            return "redKiller_5";
        }
        else if (num <= 9)
        {
            return "blueKiller_2";
        }
        else if (num <= 11)
        {
            return "blueKiller_5";
        }
        else if (num <= 14)
        {
            return "greenKiller_2";
        }
        else if (num <= 16)
        {
            return "greenKiller_5";
        }
        else if (num <= 19)
        {
            return "erase_10";
        }
        else if (num <= 22)
        {
            return "erase_20";
        }
        else if (num <= 25)
        {
            return "erase_30";
        }
        else if (num <= 27)
        {
            return "erase_40";
        }
        else if (num <= 29)
        {
            return "erase_50";
        }
        else if (num <= 32)
        {
            return "hp_50";
        }
        else if (num <= 35)
        {
            return "hp_25";
        }
        else if (num <= 39)
        {
            return "abnormalAttackUp_5";
        }
        else if (num <= 41)
        {
            return "abnormalAttackUp_10";
        }
        else if (num <= 45)
        {
            return "abnormalHealUp_5";
        }
        else if (num <= 47)
        {
            return "abnormalHealUp_10";
        }
        else if (num <= 50)
        {
            return "redResist_2";
        }
        else if (num <= 52)
        {
            return "redResist_5";
        }
        else if (num <= 55)
        {
            return "blueResist_2";
        }
        else if (num <= 57)
        {
            return "blueResist_5";
        }
        else if (num <= 60)
        {
            return "greenResist_2";
        }
        else if (num <= 62)
        {
            return "greenResist_5";
        }
        else if (num <= 65)
        {
            return "abnormalParameterResist_10";
        }
        else if (num <= 67)
        {
            return "abnormalParameterResist_20";
        }
        else if (num <= 68)
        {
            return "abnormalParameterResist_30";
        }
        else if (num <= 71)
        {
            return "abnormalStatusResist_10";
        }
        else if (num <= 73)
        {
            return "abnormalStatusResist_20";
        }
        else if (num <= 74)
        {
            return "abnormalStatusResist_30";
        }
        else if (num <= 78)
        {
            return "autoHeal_1";
        }
        else if (num <= 80)
        {
            return "autoHeal_3";
        }
        else if (num <= 84)
        {
            return "survive_5";
        }
        else if (num <= 86)
        {
            return "survive_10";
        }
        else if (num <= 88)
        {
            return "skillTurn";
        }
        else
        {
            return "empty";
        }
    }

    // 特殊効果を適用したときのダメージを返す
    public int GetApplySpEffectDamage(int damage)
    {
        // 倍率
        float spEffectMag = 0;

        // 敵の属性
        string enemyAttribute = enemyManager.enemyAttribute;
        // 消したパーツの数
        int partsCount = attackManager.allComboParts.Count;
        // 最大HP
        int maxHp = playerStatusManager.userMaxHp;
        // 現在のHP
        int currentHp = playerStatusManager.userCurrentHp;
        // 全ての異常
        List<string> allAbnormal = playerStatusManager.GetAllAbnormal();
        // 状態異常かどうか
        bool isAbnormalStatus = playerStatusManager.IsAbnormalStatus(allAbnormal);

        foreach (var spEffect in spEffectList)
        {
            // 属性
            if (enemyAttribute == "red")
            {
                if (spEffect == "redKiller_2")
                {
                    spEffectMag += 0.02f;
                    continue;
                }
                if (spEffect == "redKiller_5")
                {
                    spEffectMag += 0.05f;
                    continue;
                }
            }
            else if (enemyAttribute == "blue")
            {
                if (spEffect == "blueKiller_2")
                {
                    spEffectMag += 0.02f;
                    continue;
                }
                if (spEffect == "blueKiller_5")
                {
                    spEffectMag += 0.05f;
                    continue;
                }
            }
            else if (enemyAttribute == "green")
            {
                if (spEffect == "greenKiller_2")
                {
                    spEffectMag += 0.02f;
                    continue;
                }
                if (spEffect == "greenKiller_5")
                {
                    spEffectMag += 0.05f;
                    continue;
                }
            }

            // パーツ数
            if(spEffect == "erase_10")
            {
                if(partsCount >= 10)
                {
                    spEffectMag += 0.01f;
                }
                continue;
            }
            else if(spEffect == "erase_20")
            {
                if (partsCount >= 20)
                {
                    spEffectMag += 0.03f;
                    
                }
                continue;
            }
            else if (spEffect == "erase_30")
            {
                if (partsCount >= 30)
                {
                    spEffectMag += 0.06f;
                }
                continue;
            }
            else if (spEffect == "erase_40")
            {
                if (partsCount >= 40)
                {
                    spEffectMag += 0.1f;
                }
                continue;
            }
            else if (spEffect == "erase_50")
            {
                if (partsCount >= 50)
                {
                    spEffectMag += 0.2f;
                }
                continue;
            }

            // HP
            if(spEffect == "hp_50")
            {
                if((float)currentHp/(float)maxHp <= 0.5)
                {
                    spEffectMag += 0.05f;
                }
                continue;
            }
            else if(spEffect == "hp_25")
            {
                if ((float)currentHp / (float)maxHp <= 0.25)
                {
                    spEffectMag += 0.1f;
                }
                continue;
            }

            // 状態異常
            if(spEffect == "abnormalAttackUp_5")
            {
                if (isAbnormalStatus)
                {
                    spEffectMag += 0.05f;
                }
                continue;
            }
            else if(spEffect == "abnormalAttackUp_10")
            {
                if (isAbnormalStatus)
                {
                    spEffectMag += 0.1f;
                }
                continue;
            }
        }

        return (int)(damage * (1 + spEffectMag));
    }

    // 特殊効果を適用したときの回復量を返す
    public int GetApplySpEffectHeal(int healPoint)
    {
        float healMag = 0;

        foreach (var spEffect in spEffectList)
        {
            if(spEffect == "abnormalHealUp_5")
            {
                healMag += 0.05f;
            }
            else if(spEffect == "abnormalHealUp_10")
            {
                healMag += 0.1f;
            }
        }

        return (int)(healPoint * (1 + healMag));
    }

    // 特殊効果を適用したときの敵からのダメージを返す
    public int GetApplySpEffectEnemyDamage(int enemyDamage)
    {
        float mag = 0;
        // 敵の属性
        string enemyAttribute = enemyManager.enemyAttribute;

        foreach (var spEffect in spEffectList)
        {
            if(spEffect == "redResist_2")
            {
                if(enemyAttribute == "red")
                {
                    mag -= 0.02f;
                }
            }
            else if( spEffect == "redResist_5")
            {
                if (enemyAttribute == "red")
                {
                    mag -= 0.05f;
                }
            }
            else if (spEffect == "blueResist_2")
            {
                if (enemyAttribute == "blue")
                {
                    mag -= 0.02f;
                }
            }
            else if (spEffect == "blueResist_5")
            {
                if (enemyAttribute == "blue")
                {
                    mag -= 0.05f;
                }
            }
            else if (spEffect == "greenResist_2")
            {
                if (enemyAttribute == "green")
                {
                    mag -= 0.02f;
                }
            }
            else if (spEffect == "greenResist_5")
            {
                if (enemyAttribute == "green")
                {
                    mag -= 0.05f;
                }
            }
        }

        return (int)(enemyDamage * (1 + mag));
    }

    // 特殊効果を適用したときのパラメータ異常にかかったかどうかの判定
    public bool IsGotAbnormalParam()
    {
        int probability = 100;

        foreach (var spEffect in spEffectList)
        {
            if(spEffect == "abnormalParameterResist_10")
            {
                probability -= 10;
            }
            else if(spEffect == "abnormalParameterResist_20")
            {
                probability -= 20;
            }
            else if (spEffect == "abnormalParameterResist_30")
            {
                probability -= 30;
            }
        }

        int randomNum = UnityEngine.Random.Range(1, 101);
        if(randomNum <= probability)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 特殊効果を適用したときの状態異常にかかったかどうかの判定
    public bool IsGotAbnormalStatus()
    {
        int probability = 100;

        foreach (var spEffect in spEffectList)
        {
            if(spEffect == "abnormalStatusResist_10")
            {
                probability -= 10;
            }
            else if( spEffect == "abnormalStatusResist_20")
            {
                probability -= 20;
            }
            else if(spEffect == "abnormalStatusResist_30")
            {
                probability -= 30;
            }
        }

        int randomNum = UnityEngine.Random.Range(1, 101);
        if (randomNum <= probability)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 自動回復
    public void AutoHeal()
    {
        float mag = 0;

        foreach (var spEffect in spEffectList)
        {
            if(spEffect == "autoHeal_1")
            {
                mag += 0.01f;
            }
            else if(spEffect == "autoHeal_3")
            {
                mag += 0.03f;
            }
        }

        if(mag == 0)
        {
            return;
        }

        playerStatusManager.userCurrentHp += (int)(playerStatusManager.userMaxHp * mag);
        if (playerStatusManager.userCurrentHp > playerStatusManager.userMaxHp)
        {
            // 最大HPを上回って回復した場合は最大HPにする
            playerStatusManager.userCurrentHp = playerStatusManager.userMaxHp;
        }

        playerStatusManager.ChangeHp();
    }

    // 特殊効果を適用したときの負けたかどうかの判定
    public bool IsLost()
    {
        float probability = 100;

        foreach (var spEffect in spEffectList)
        {
            if(spEffect == "survive_5")
            {
                probability -= 5;
            }
            else if( spEffect == "survive_10")
            {
                probability -= 10;
            }
        }

        int randomNum = UnityEngine.Random.Range(1, 101);
        if (randomNum <= probability)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 装備中の全ての特殊効果を返す
    public List<string> GetAllSpEffect()
    {
        List<string> list = new List<string>();
        string moldSpEffect_1 = playerStatusManager.GetEquipmentSpEffect(playerStatusManager.GetEquipmentInfo(playerPrefsManager.GetMold_1()));
        string moldSpEffect_2 = playerStatusManager.GetEquipmentSpEffect(playerStatusManager.GetEquipmentInfo(playerPrefsManager.GetMold_2()));
        string skillSpEffect_1 = playerStatusManager.GetEquipmentSpEffect(playerStatusManager.GetEquipmentInfo(playerPrefsManager.GetSkill_1()));
        string skillSpEffect_2 = playerStatusManager.GetEquipmentSpEffect(playerStatusManager.GetEquipmentInfo(playerPrefsManager.GetSkill_2()));
        if(moldSpEffect_1 != "empty")
        {
            list.Add(moldSpEffect_1);
        }
        if (moldSpEffect_2 != "empty")
        {
            list.Add(moldSpEffect_2);
        }
        if (skillSpEffect_1 != "empty")
        {
            list.Add(skillSpEffect_1);
        }
        if (skillSpEffect_2 != "empty")
        {
            list.Add(skillSpEffect_2);
        }
        return list;
    }
}
