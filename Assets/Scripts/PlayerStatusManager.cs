using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerStatusManager : MonoBehaviour
{
    public PuzzleMain puzzleMain;
    public PlayerPrefsManager playerPrefsManager;
    public SkillManager skillManager;
    public SpEffectManager spEffectManager;
    public AttackManager attackManager;
    public MoldManager moldManager;
    public TextManager textManager;

    public int userMaxHp;
    public int userAttackPower;
    public int userHealPower;

    // ユーザのHPのテキスト
    public Text userHpText;

    // ユーザのHPバーのスライダー
    public Slider userHpSlider;
    // ユーザのHPバーのfill
    public GameObject userHpfill;

    public int userCurrentHp;
    public int userCurrentAttackPower;
    public int userCurrentHealPower;
    public int userCurrentSkillTurn_1;
    public int userCurrentSkillTurn_2;

    // 装備スキルの情報。配列
    public string[] userSkillInfoArray_1;
    public string[] userSkillInfoArray_2;

    // 装備しているスキルの名称
    public string userSkillName_1;
    public string userSkillName_2;

    // スキルボタン
    public Button userSkill_1_button;
    public Button userSkill_2_button;

    // スキルが溜まるまでのターンを表示するテキスト
    public Text skillTurnText_1;
    public Text skillTurnText_2;

    // モールドの倍率を表示するテキスト
    public Text userMoldMag_1;
    public Text userMoldMag_2;
    public Text stageMoldMag;

    // 状態・パラメータ異常を保存するもの（残り1ターンのもの）
    public List<string> abnormalList_1 = new List<string>();
    // 状態・パラメータ異常を保存するもの（残り2ターンのもの）
    public List<string> abnormalList_2 = new List<string>();
    // 状態・パラメータ異常を保存するもの（残り3ターンのもの）
    public List<string> abnormalList_3 = new List<string>();

    // パラメータ変化、状態異常のアイコン表示領域
    public Image changeImage;

    // 状態異常のアイコン表示領域
    public Image abnormalStatusImage;
    // パラメータ異常のアイコン表示領域
    public Image abnormalParamImage;

    // パラメータ変化、状態異常のアイコン
    public Sprite poisonSprite;
    public Sprite paraSprite;
    public Sprite burnSprite;
    public Sprite sleepSprite;
    public Sprite darknessSprite;
    public Sprite confuseSprite;
    public Sprite attackUpSprite;
    public Sprite healUpSprite;
    public Sprite attackDownSprite;
    public Sprite healDownSprite;

    // パラメータ異常の一覧
    public List<string> abnormalParamName = new List<string>() { "attackDown", "healDown", "attackUp_1.5", "healUp_1.5", "attackUp_1.2", "healUp_1.2" };
    // 悪いパラメータ異常の一覧
    public List<string> abnormalBadParamName = new List<string>() { "attackDown", "healDown" };
    // 状態異常の一覧
    public List<string> abnormalStatusName = new List<string>() { "poison", "paralysis", "burn", "sleep", "darkness", "confuse" };

    // パラメータ異常の現在表示中のもの
    public string currentAbnormalParam;

    // パラメータ異常のアイコン変更管理時間
    public float abnormalParamTime;

    // 麻痺状態になっているブロック
    public List<int> paralysisBlockList = new List<int>();

    // 麻痺状態で生成したエフェクト
    public List<GameObject> paralysisPrefabList = new List<GameObject>();

    // 暗闇状態になっているブロック
    public List<int> darknessBlockList = new List<int>();

    // 暗闇状態で生成したエフェクト
    public List<GameObject> darknessPrefabList = new List<GameObject>();

    public Image userMoldIImage_1;
    public Image userMoldIImage_2;
    public Image stageMoldIImage;

    // Start is called before the first frame update
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        // パズル画面以外は終了
        if (sceneName != "VolcanoScene" && sceneName != "ShipScene" && sceneName != "ForestScene" && sceneName != "BossScene")
        {
            return;
        }

        InitializePlayerStatus();

        // 初期化
        userCurrentHp = userMaxHp;
        userHpSlider.value = 1;
        userCurrentAttackPower = userAttackPower;
        userCurrentHealPower = userHealPower;

        // HP設定
        ChangeHp();

        // スキル設定
        SetSkill();

        // モールド設定
        SetMold();
    }

    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        // パズル画面以外は終了
        if (sceneName != "VolcanoScene" && sceneName != "ShipScene" && sceneName != "ForestScene" && sceneName != "BossScene")
        {
            return;
        }

        // パラメータ異常の表示切替
        abnormalParamTime += Time.deltaTime;
        if( abnormalParamTime > 1 )
        {
            ChangeAbnormalParamIcon();
            abnormalParamTime = 0;
        }
    }

    // 引数異常の名前から表示名を返す
    public string GetAbnormalName(string name)
    {
        switch (name)
        {
            case "poison":
                return textManager.GetLocalizeText("毒");
            case "paralysis":
                return textManager.GetLocalizeText("麻痺");
            case "burn":
                return textManager.GetLocalizeText("火傷");
            case "sleep":
                return textManager.GetLocalizeText("睡眠");
            case "darkness":
                return textManager.GetLocalizeText("暗闇");
            case "confuse":
                return textManager.GetLocalizeText("混乱");
            case "attackDown":
                return textManager.GetLocalizeText("攻撃力ダウン");
            case "healDown":
                return textManager.GetLocalizeText("回復力ダウン");
            case "attackUp_1.5":
                return textManager.GetLocalizeText("攻撃力アップ");
            case "healUp_1.5":
                return textManager.GetLocalizeText("回復力アップ");
            case "attackUp_1.2":
                return textManager.GetLocalizeText("攻撃力アップ");
            case "healUp_1.2":
                return textManager.GetLocalizeText("回復力アップ");
        }
        return "";
    }

    // 引数異常の名前から説明を返す
    public string GetAbnormalDesc(string name)
    {
        switch (name)
        {
            case "poison":
                return textManager.GetLocalizeText("毎ターンHPの5%のダメージを受ける");
            case "paralysis":
                return textManager.GetLocalizeText("ランダムでパネルの回転不可");
            case "burn":
                return textManager.GetLocalizeText("受けるダメージが1.5倍 特殊効果が無効");
            case "sleep":
                return textManager.GetLocalizeText("与えるダメージが0倍 受けるダメージが2倍");
            case "darkness":
                return textManager.GetLocalizeText("ランダムでパネルが見えなくなる");
            case "confuse":
                return textManager.GetLocalizeText("回復パネルを消すとダメージを受ける");
            case "attackDown":
                return textManager.GetLocalizeText("攻撃力が0.5倍");
            case "healDown":
                return textManager.GetLocalizeText("回復力が0.5倍");
            case "attackUp_1.5":
                return textManager.GetLocalizeText("攻撃力が1.5倍");
            case "healUp_1.5":
                return textManager.GetLocalizeText("回復力が1.5倍");
            case "attackUp_1.2":
                return textManager.GetLocalizeText("攻撃力が1.2倍");
            case "healUp_1.2":
                return textManager.GetLocalizeText("回復力が1.2倍");
        }

        return "";
    }

    // パラメータに関わる異常を適用する
    public void ApplyAbnormalParam()
    {
        float attack = GetPlayerAttack();
        float heal = GetPlayerHeal();

        List<string> list = GetAllAbnormal();

        foreach (var abnormal in list)
        {
            switch (abnormal)
            {
                case "attackDown":
                    attack /= 2;
                    break;
                case "healDown":
                    heal /= 2;
                    break;
                case "attackUp_1.5":
                    attack *= 1.5f;
                    break;
                case "healUp_1.5":
                    heal *= 1.5f;
                    break;
                case "attackUp_1.2":
                    attack *= 1.2f;
                    break;
                case "healUp_1.2":
                    heal *= 1.2f;
                    break;
            }
        }

        // 小数点は切り上げ
        userCurrentAttackPower = (int)Math.Ceiling(attack);
        userCurrentHealPower = (int)Math.Ceiling(heal);
    }

    // 異常をリフレッシュする
    public void RefreshAbnormal()
    {
        List<string> all = GetAllAbnormal();
        bool isAbnormalStatus = false;

        // 毒
        if (all.Contains("poison"))
        {
            abnormalStatusImage.sprite = poisonSprite;
            isAbnormalStatus = true;
        }

        // 麻痺
        foreach (var blockNum in paralysisBlockList)
        {
            puzzleMain.PartsButtonList[blockNum].GetComponent<Button>().interactable = true;
            puzzleMain.ChangePartsBright(blockNum, false);
        }
        foreach (var prefab in paralysisPrefabList)
        {
            Destroy(prefab);
        }
        paralysisPrefabList.Clear();

        if (all.Contains("paralysis"))
        {
            // 麻痺状態
            foreach (var blockNum in paralysisBlockList)
            {
                puzzleMain.PartsButtonList[blockNum].GetComponent<Button>().interactable = false;
                puzzleMain.ChangePartsBright(blockNum, true);
                paralysisPrefabList.Add(puzzleMain.CreatePartPara(blockNum));
            }

            abnormalStatusImage.sprite = paraSprite;
            isAbnormalStatus = true;
        }
        else
        {
            // 麻痺ではない
            paralysisBlockList.Clear();
        }

        // 火傷
        if (all.Contains("burn"))
        {
            abnormalStatusImage.sprite = burnSprite;
            isAbnormalStatus = true;
        }

        // 睡眠
        if (all.Contains("sleep"))
        {
            abnormalStatusImage.sprite = sleepSprite;
            isAbnormalStatus = true;
        }

        // 暗闇
        foreach (var prefab in darknessPrefabList)
        {
            Destroy(prefab);
        }
        darknessPrefabList.Clear();

        if (all.Contains("darkness"))
        {
            // 暗闇状態
            foreach (var blockNum in darknessBlockList)
            {
                darknessPrefabList.Add(puzzleMain.CreatePartDarkness(blockNum));
            }

            abnormalStatusImage.sprite = darknessSprite;
            isAbnormalStatus = true;
        }
        else
        {
            // 暗闇ではない
            darknessBlockList.Clear();
        }

        // 混乱
        if (all.Contains("confuse"))
        {
            abnormalStatusImage.sprite = confuseSprite;
            isAbnormalStatus = true;
        }

        // 状態異常の場合アイコンを表示する
        if (isAbnormalStatus)
        {
            abnormalStatusImage.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            abnormalStatusImage.color = new Color32(255, 255, 255, 0);
        }

        // パラメータ異常
        ApplyAbnormalParam();
    }

    // 異常を全て取得する
    public List<string> GetAllAbnormal()
    {
        List<string> list = new List<string>();

        list.AddRange(abnormalList_1);
        list.AddRange(abnormalList_2);
        list.AddRange(abnormalList_3);

        return list;
    }


    // 異常を追加する
    public void AddAbnormal(string abnormalName, int turn)
    {
        // 既に同じものでターン数の多いものがあれば重複するため追加しない
        if(turn == 1)
        {
            if (abnormalList_1.Contains(abnormalName) || abnormalList_2.Contains(abnormalName) || abnormalList_3.Contains(abnormalName))
            {
                return;
            }
        }else if (turn == 2)
        {
            if (abnormalList_2.Contains(abnormalName) || abnormalList_3.Contains(abnormalName))
            {
                return;
            }
        }else if(turn == 3)
        {
            if (abnormalList_3.Contains(abnormalName))
            {
                return;
            }
        }

        // 既に同じものでターン数の少ないものがあれば少ない方を削除する
        if (turn == 3)
        {
            abnormalList_1.Remove(abnormalName);
            abnormalList_2.Remove(abnormalName);
        }
        else if(turn == 2)
        {
            abnormalList_1.Remove(abnormalName);
        }

        // 追加する
        if(turn == 3)
        {
            abnormalList_3.Add(abnormalName);
        }
        else if(turn == 2)
        {
            abnormalList_2.Add(abnormalName);
        }
        else
        {
            abnormalList_1.Add(abnormalName);
        }
    }

    // パラメータ異常を回復する
    public void HealAbnormalParam()
    {
        List<string> allAbnormal = GetAllAbnormal();
        if (!IsAbnormalBadParam(allAbnormal))
        {
            // 悪いパラメータ異常になっていなければ終了
            return;
        }

        foreach (var item in abnormalBadParamName)
        {
            RemoveAbnormal(item);
        }
    }

    // 状態異常を回復する
    public void HealAbnormalStatus()
    {
        List<string> allAbnormal = GetAllAbnormal();
        if (!IsAbnormalStatus(allAbnormal))
        {
            // 状態異常になっていなければ終了
            return;
        }
        foreach (var item in abnormalStatusName)
        {
            RemoveAbnormal(item);
        }
    }

    // 引数異常を回復する
    public void RemoveAbnormal(string abnormalName)
    {
        // 残ターンリストから削除
        abnormalList_1.Remove(abnormalName);
        abnormalList_2.Remove(abnormalName);
        abnormalList_3.Remove(abnormalName);
    }

    // 異常のターン数を進める
    public void AdvanceAbnormal()
    {
        abnormalList_1.Clear();
        abnormalList_1.AddRange(abnormalList_2);
        abnormalList_2.Clear();
        abnormalList_2.AddRange(abnormalList_3);
        abnormalList_3.Clear();
    }

    // 麻痺状態のプレハブを全て表示する
    public void ActivatePara()
    {
        foreach (var item in paralysisPrefabList)
        {
            item.SetActive(true);
        }
    }

    // 麻痺状態のプレハブを全て非表示にする
    public void InactivatePara()
    {
        foreach (var item in paralysisPrefabList)
        {
            item.SetActive(false);
        }
    }

    // 暗闇状態のプレハブを全て表示する
    public void ActivateDarkness()
    {
        foreach (var item in darknessPrefabList)
        {
            item.SetActive(true);
        }
    }

    // 暗闇状態のプレハブを全て非表示にする
    public void InactivateDarkness()
    {
        foreach (var item in darknessPrefabList)
        {
            item.SetActive(false);
        }
    }

    // パラメータ異常のアイコンを変化させる
    public void ChangeAbnormalParamIcon()
    {
        List<string> allAbnormal = GetAllAbnormal();

        if (!IsAbnormalParam(allAbnormal)) {
            // パラメータ異常になっていなければ終了
            abnormalParamImage.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            abnormalParamImage.enabled = false;
            return;
        }

        int currentIndex = abnormalParamName.IndexOf(currentAbnormalParam);
        int nextIndex = -1;
        for (int i = currentIndex + 1; i < abnormalParamName.Count; i++)
        {
            if (allAbnormal.IndexOf(abnormalParamName[i]) > -1)
            {
                nextIndex = i;
                break;
            }
        }

        if(nextIndex == -1)
        {
            for (int i = 0; i < abnormalParamName.Count; i++)
            {
                if (allAbnormal.IndexOf(abnormalParamName[i]) > -1)
                {
                    nextIndex = i;
                    break;
                }
            }
        }
        
        if (nextIndex > -1)
        {
            string nextAbnormalName = abnormalParamName[nextIndex];

            abnormalParamImage.sprite = GetAbnormalSprite(nextAbnormalName);
            abnormalParamImage.enabled = true;
            abnormalParamImage.GetComponent<Image>().color = new Color32(255, 255,255,255);
            currentAbnormalParam = nextAbnormalName;
        }
    }

    // パラメータ異常になっているかどうか
    public bool IsAbnormalParam(List<string> allAbnormal)
    {
        foreach (var item in allAbnormal)
        {
            if (abnormalParamName.Contains(item))
            {
                return true;
            }
        }
        return false;
    }

    // 悪いパラメータ異常になっているかどうか
    public bool IsAbnormalBadParam(List<string> allAbnormal)
    {
        foreach (var item in allAbnormal)
        {
            if (abnormalBadParamName.Contains(item))
            {
                return true;
            }
        }
        return false;
    }

    // 状態異常になっているかどうか
    public bool IsAbnormalStatus(List<string> allAbnormal)
    {
        foreach (var item in allAbnormal)
        {
            if (abnormalStatusName.Contains(item))
            {
                return true;
            }
        }
        return false;
    }

    // 異常の名前からSpriteを返す
    public Sprite GetAbnormalSprite(string abnormalName)
    {
        if(abnormalName == "attackDown")
        {
            return attackDownSprite;
        }
        else if(abnormalName == "healDown")
        {
            return healDownSprite;
        }
        else if (abnormalName == "attackUp_1.5" || abnormalName == "attackUp_1.2")
        {
            return attackUpSprite;
        }
        else if (abnormalName == "healUp_1.5" || abnormalName == "healUp_1.2")
        {
            return healUpSprite;
        }
        return attackUpSprite;
    }


    // パズル開始時のプレイヤーステータスの初期化
    public void InitializePlayerStatus()
    {
        userMaxHp = GetPlayerHp();
        userAttackPower = GetPlayerAttack();
        userHealPower = GetPlayerHeal();
    }

    // 装備しているスキル1の情報を返す
    public string[] GetSkillInfo_1()
    {
        string userSkill_1 = playerPrefsManager.GetSkill_1();
        return GetEquipmentInfo(userSkill_1);
    }

    // 装備しているスキル2の情報を返す
    public string[] GetSkillInfo_2()
    {
        string userSkill_2 = playerPrefsManager.GetSkill_2();
        return GetEquipmentInfo(userSkill_2);
    }

    // 装備しているモールド1の情報を返す
    public string[] GetMoldInfo_1()
    {
        string mold_1 = playerPrefsManager.GetMold_1();
        return GetEquipmentInfo(mold_1);
    }

    // 装備しているモールド2の情報を返す
    public string[] GetMoldInfo_2()
    {
        string mold_2 = playerPrefsManager.GetMold_2();
        return GetEquipmentInfo(mold_2);
    }

    // プレイヤーの装備品込みのHPを返す
    public int GetPlayerHp()
    {
        int moldHp_1 = int.Parse(GetEquipmentHp(GetMoldInfo_1()));
        int moldHp_2 = int.Parse(GetEquipmentHp(GetMoldInfo_2()));

        int skillHp_1 = int.Parse(GetEquipmentHp(GetSkillInfo_1()));
        int skillHp_2 = int.Parse(GetEquipmentHp(GetSkillInfo_2()));

        int hp = moldHp_1 + moldHp_2 + skillHp_1 + skillHp_2;

        return hp;
    }

    // プレイヤーの装備品込みの攻撃力を返す
    public int GetPlayerAttack()
    {
        int moldAttack_1 = int.Parse(GetEquipmentPower(GetMoldInfo_1()));
        int moldAttack_2 = int.Parse(GetEquipmentPower(GetMoldInfo_2()));

        int skillAttack_1 = int.Parse(GetEquipmentPower(GetSkillInfo_1()));
        int skillAttack_2 = int.Parse(GetEquipmentPower(GetSkillInfo_2()));

        int attack = moldAttack_1 + moldAttack_2 + skillAttack_1 + skillAttack_2;

        return attack;
    }

    // プレイヤーの装備品込みの回復力を返す
    public int GetPlayerHeal()
    {
        int moldHeal_1 = int.Parse(GetEquipmentHeal(GetMoldInfo_1()));
        int moldHeal_2 = int.Parse(GetEquipmentHeal(GetMoldInfo_2()));

        int skillHeal_1 = int.Parse(GetEquipmentHeal(GetSkillInfo_1()));
        int skillHeal_2 = int.Parse(GetEquipmentHeal(GetSkillInfo_2()));

        int heal = moldHeal_1 + moldHeal_2 + skillHeal_1 + skillHeal_2;

        return heal;
    }

    // ユーザのHPの変更を反映する
    public void ChangeHp()
    {
        // HPのテキストに反映
        userHpText.text = "HP "+ userCurrentHp + " / " + userMaxHp;

        // HPバーに反映
        userHpSlider.value = (float)userCurrentHp / (float)userMaxHp;
        attackManager.ChangeHpColor(userHpSlider, userHpfill);
    }

    // 攻撃力を下げる
    public void PowerDown()
    {
        userCurrentAttackPower -= userAttackPower / 2;
    }

    // 回復力を下げる
    public void HealDown()
    {
        userCurrentHealPower -= userHealPower / 2;
    }

    // 毒のダメージを受ける
    public void DamagePoison()
    {
        if (GetAllAbnormal().Contains("poison"))
        {
            userCurrentHp -= (int)(userMaxHp * 0.05f);

            if (userCurrentHp < 0)
            {
                userCurrentHp = 0;
            }

            ChangeHp();
        }
    }

    // スキルターンを進める
    public void AdvanceSkillTurn()
    {
        if(userCurrentSkillTurn_1 > 0)
        {
            userCurrentSkillTurn_1--;
        }

        if (userCurrentSkillTurn_2 > 0)
        {
            userCurrentSkillTurn_2--;
        }

        skillTurnText_1.text = userCurrentSkillTurn_1.ToString();
        skillTurnText_2.text = userCurrentSkillTurn_2.ToString();

        if(userCurrentSkillTurn_1 == 0)
        {
            userSkill_1_button.image.color = new Color32(255, 255, 255, 255);
        }

        if (userCurrentSkillTurn_2 == 0)
        {
            userSkill_2_button.image.color = new Color32(255, 255, 255, 255);
        }        
    }

    // スキルターン数を元に戻す
    public void ResetSkillTurn(string skillButtonName)
    {
        if(skillButtonName == "SkillButton_1")
        {
            int userSkill_1_turn = int.Parse(GetSkillTurn(userSkillInfoArray_1));
            userCurrentSkillTurn_1 = userSkill_1_turn;
            skillTurnText_1.text = userSkill_1_turn.ToString();

            userSkill_1_button.image.color = new Color32(100, 100, 100, 255);
        }
        else
        {
            int userSkill_2_turn = int.Parse(GetSkillTurn(userSkillInfoArray_2));
            userCurrentSkillTurn_2 = userSkill_2_turn;
            skillTurnText_2.text = userSkill_2_turn.ToString();

            userSkill_2_button.image.color = new Color32(100, 100, 100, 255);
        }
    }

    // スキルボタンにスキルのイラストをセットする。発動ターンもセットする
    public void SetSkill()
    {
        string userSkill_1 = playerPrefsManager.GetSkill_1();
        string userSkill_2 = playerPrefsManager.GetSkill_2();

        userSkillInfoArray_1 = GetEquipmentInfo(userSkill_1);
        string userSkill_1_name = GetEquipmentName(userSkillInfoArray_1);
        userSkillName_1 = userSkill_1_name;
        Sprite userSkill_1_sprite = skillManager.GetSkillSprite(userSkill_1_name);
        userSkill_1_button.image.sprite = userSkill_1_sprite;

        userSkillInfoArray_2 = GetEquipmentInfo(userSkill_2);
        string userSkill_2_name = GetEquipmentName(userSkillInfoArray_2);
        userSkillName_2 = userSkill_2_name;
        Sprite userSkill_2_sprite = skillManager.GetSkillSprite(userSkill_2_name);
        userSkill_2_button.image.sprite = userSkill_2_sprite;

        if (spEffectManager.GetAllSpEffect().Contains("skillTurn"))
        {
            // 特殊効果でスキルターンが溜まった状態で開始する
            userCurrentSkillTurn_1 = 0;
            skillTurnText_1.text = 0.ToString();
            userSkill_1_button.image.color = new Color32(255, 255, 255, 255);

            userCurrentSkillTurn_2 = 0;
            skillTurnText_2.text = 0.ToString();
            userSkill_2_button.image.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            ResetSkillTurn("SkillButton_1");
            ResetSkillTurn("SkillButton_2");
        }
        
    }

    // モールドに装備とステージのモールドをセットする
    public void SetMold()
    {
        // 装備しているモールドをセットする
        string userMold_1 = playerPrefsManager.GetMold_1();
        string userMold_2 = playerPrefsManager.GetMold_2();

        string[] userMoldInfo_1 = GetEquipmentInfo(userMold_1);
        string[] userMoldInfo_2 = GetEquipmentInfo(userMold_2);

        string userMoldName_1 = GetEquipmentName(userMoldInfo_1);
        string userMoldName_2 = GetEquipmentName(userMoldInfo_2);

        userMoldIImage_1.sprite = moldManager.GetMoldSprite(userMoldName_1);
        userMoldIImage_2.sprite = moldManager.GetMoldSprite(userMoldName_2);
        userMoldMag_1.text = "× " + moldManager.GetMoldMagnification(userMoldName_1).ToString();
        userMoldMag_2.text = "× " + moldManager.GetMoldMagnification(userMoldName_2).ToString();

        // ステージのモールドをセットする
        string stageMold = moldManager.GetRandomStageMoldName(userMoldName_1, userMoldName_2);
        playerPrefsManager.SetStageMold(stageMold);
        stageMoldIImage.sprite = moldManager.GetMoldSprite(stageMold);
        stageMoldMag.text = "× " + moldManager.GetMoldMagnification(stageMold).ToString();
    }


    // モールド、スキルの情報（文字列）を配列にして返す
    public string[] GetEquipmentInfo(string equipment)
    {
        return equipment.Split(',');
        // ["名前","HP上昇値","攻撃力上昇値","回復力上昇値","追加効果","発動ターン数"]
        // 例）["skillHealHp","100","150","300","powerUp","4"] 追加効果が無ければ"empty"を入れておく。発動ターン数はスキルのみ
    }

    // モールド、スキルの名称を返す
    public string GetEquipmentName(string[] equipmentArray)
    {
        return equipmentArray[0];
    }

    // モールド、スキルのHPを返す
    public string GetEquipmentHp(string[] equipmentArray)
    {
        return equipmentArray[1];
    }

    // モールド、スキルの攻撃力を返す
    public string GetEquipmentPower(string[] equipmentArray)
    {
        return equipmentArray[2];
    }

    // モールド、スキルの回復力を返す
    public string GetEquipmentHeal(string[] equipmentArray)
    {
        return equipmentArray[3];
    }

    // モールド、スキルの追加効果を返す
    public string GetEquipmentSpEffect(string[] equipmentArray)
    {
        return equipmentArray[4];
    }

    // スキルの発動ターン数を返す
    public string GetSkillTurn(string[] equipmentArray)
    {
        return equipmentArray[5];
    }
}
