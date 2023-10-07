using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttackManager : MonoBehaviour
{
    public EventSystem eventSystem;

    public PuzzleMain puzzleMain;
    public PuzzleSceneManager puzzleSceneManager;
    public PlayerStatusManager playerStatusManager;
    public EnemyManager enemyManager;
    public MoldManager moldManager;
    public SkillManager skillManager;
    public BgmManager bgmManager;
    public SpEffectManager spEffectManager;
    public PlayerPrefsManager playerPrefsManager;
    public ClearPanelManager clearPanelManager;
    public InfoManager infoManager;
    public TutorialManager tutorialManager;
    public SeManager seManager;

    public List<GameObject> comboParts;

    public Button attackButton;

    // スキルボタンが押されたときそのボタンの名前を保存する
    public string useSkillButtonName;

    // コンボ判定中に使うモールドのパターン
    public string comboMold;
    public int comboEndNum;
    public int comboDiff;
    public List<int> comboBlockList;
    public List<string> comboDirectionList;

    // 合致するパターンが存在したかどうかTRUE:有り
    public bool isCombo;

    // コンボカウント
    public int moldComboNum;

    // コンボ中にまだ判定していないモールド
    public List<string> waitingMoldList;

    // コンボで消すべき全てのパーツ。攻撃の最後に新しいパーツを生成するのに使う。
    public List<string> allComboParts;

    // コンボで消すべき火のパーツ。モールド毎に保存して攻撃力回復力計算に使用する。
    public List<string> redComboList;
    // コンボで消すべき水のパーツ。モールド毎に保存して攻撃力回復力計算に使用する。
    public List<string> blueComboList;
    // コンボで消すべき木のパーツ。モールド毎に保存して攻撃力回復力計算に使用する。
    public List<string> greenComboList;
    // コンボで消すべき回復のパーツ。モールド毎に保存して攻撃力回復力計算に使用する。
    public List<string> pinkComboList;

    // 火攻撃倍率
    public float redAttackMagnification;
    // 水攻撃倍率
    public float blueAttackMagnification;
    // 木攻撃倍率
    public float greenAttackMagnification;
    // 回復倍率
    public float healMagnification;

    // 各倍率を表示するもの
    public Text redMagText;
    public Text blueMagText;
    public Text greenMagText;
    public Text pinkMagText;

    // 敵へのダメージ
    public int enemyDamage;

    // 敵への攻撃SEを鳴らしたかどうか
    public bool isSoundAttackSe;

    // 敵からの攻撃SEを鳴らしたかどうか
    public bool isSoundEnemyAttackSe;

    // Start is called before the first frame update
    void Start()
    {
        comboParts = new List<GameObject>();
        redAttackMagnification = 0;
        blueAttackMagnification = 0;
        greenAttackMagnification = 0;
        healMagnification = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleMain.puzzleState == "attack")
        {
            // 攻撃ボタンが押下されてからコンボが完了するまで

            // 攻撃中は時間計測
            puzzleMain.comboTime += Time.deltaTime;

            if(puzzleMain.comboState == "waitComboCheck")
            {
                // パーツチェックを待っている状態
                CheckMoldPattern();

                puzzleMain.comboTime = 0;
            }
            else if (puzzleMain.comboState == "waitComboPartsDelete")
            {
                // コンボパーツ削除を待っている状態

                if (puzzleMain.comboTime > 0.4f)
                {
                    // 少しまったらコンボパーツ削除
                    foreach (GameObject part in comboParts)
                    {
                        Destroy(part);
                    }

                    puzzleMain.comboState = "waitComboCheck";
                    puzzleMain.comboTime = 0;
                }
            }
            else if (puzzleMain.comboState == "waitAttackEffect")
            {
                // コンボが完了し敵に攻撃して自分を回復するエフェクトを発生
                if (!isSoundAttackSe)
                {
                    SoundAttack();
                    isSoundAttackSe = true;
                }
                
                puzzleMain.attackEffectTime += Time.deltaTime;

                if(puzzleMain .attackEffectTime < 0.1f)
                {
                    enemyManager.enemyImage.enabled = false;
                }
                else if(puzzleMain.attackEffectTime < 0.2f)
                {
                    enemyManager.enemyImage.enabled = true;
                }
                else if (puzzleMain.attackEffectTime < 0.3f)
                {
                    enemyManager.enemyImage.enabled = false;
                }
                else if (puzzleMain.attackEffectTime < 0.4f)
                {
                    enemyManager.enemyImage.enabled = true;
                }
                else
                {
                    puzzleMain.attackEffectTime = 0;
                    puzzleMain.comboState = "waitComboAttack";
                }
            }
            else if (puzzleMain.comboState == "waitComboAttack")
            {
                // コンボが完了し敵に攻撃する
                UserAttack();

                // 回復する
                Heal();

                // 自動回復
                spEffectManager.AutoHeal();

                // 毒のダメージ
                playerStatusManager.DamagePoison();

                CheckHp();

                puzzleMain.comboState = "waitEnemyAttackEffect";
            }
            else if(puzzleMain.comboState == "waitEnemyAttackEffect")
            {
                // 敵からの攻撃のエフェクト発生
                float bottomY = -20;
                float topY = -20;
                float leftX = 0;
                float rightX = 0;

                if(enemyManager.enemySpAttackTurn == 1)
                {
                    // 特殊攻撃の場合は縦にジャンプ
                    topY = 0;
                }
                else
                {
                    // 通常攻撃の場合は横に
                    rightX = 20;
                }
                puzzleMain.enemyAttackEffectTime += Time.deltaTime;

                if(puzzleMain.enemyAttackEffectTime < 0.5f)
                {

                }
                else if (puzzleMain.enemyAttackEffectTime < 0.6f)
                {
                    if (!isSoundEnemyAttackSe)
                    {
                        if(enemyManager.enemySpAttackTurn == 1)
                        {
                            seManager.SoundEnemySpAttackSe();
                        }
                        else
                        {
                            seManager.SoundEnemyNormalAttackSe();
                        }
                        isSoundEnemyAttackSe = true;
                    }
                    enemyManager.enemyImage.rectTransform.anchoredPosition = new Vector2(rightX, topY);
                }
                else if (puzzleMain.enemyAttackEffectTime < 0.7f)
                {
                    enemyManager.enemyImage.rectTransform.anchoredPosition = new Vector2(leftX, bottomY);
                }
                else if (puzzleMain.enemyAttackEffectTime < 0.8f)
                {
                    enemyManager.enemyImage.rectTransform.anchoredPosition = new Vector2(rightX, topY);
                }
                else if (puzzleMain.enemyAttackEffectTime < 0.9f)
                {
                    enemyManager.enemyImage.rectTransform.anchoredPosition = new Vector2(leftX, bottomY);
                }
                else
                {
                    puzzleMain.enemyAttackEffectTime = 0;
                    puzzleMain.comboState = "waitEnemyAttack";
                }
            }
            else if(puzzleMain.comboState == "waitEnemyAttack")
            {
                // 敵から攻撃される
                EnemyAttack();

                // パーツを消して新しいパーツを生成する。
                CreatePartsAfterAttack();

                allComboParts.Clear();

                puzzleMain.puzzleState = "puzzle";
                puzzleMain.comboState = "";

                // 敵へのダメージをリセット
                enemyDamage = 0;

                // 倍率を戻す
                ResetMagnification();

                // スキルターンを進める
                playerStatusManager.AdvanceSkillTurn();

                // 自分の異常のターンを進める
                playerStatusManager.AdvanceAbnormal();

                // 敵の特殊攻撃ターンを進める
                enemyManager.AdvanceEnemySpAttack();

                // 特殊攻撃ターンが0になったら敵の特殊攻撃をする
                enemyManager.SpAttack();

                // 異常をパラメータに反映する
                playerStatusManager.ApplyAbnormalParam();

                // 異常をリフレッシュ
                playerStatusManager.RefreshAbnormal();

                CheckHp();

                InteractableAttackMenu();
            }
            

        }else if(puzzleMain.puzzleState == "useSkill")
        {
            // スキル使用中（スキルボタンが押下されてからスキル効果が発動完了するまで）

            // スキル使用中は時間計測
            puzzleMain.skillTime += Time.deltaTime;

            if(puzzleMain.skillTime <= 0.5f)
            {
                // ボタン押下から1秒まではエフェクト

            }
            else
            {
                // １秒経ったら実際にスキルの効果使用
                UseSkill();

                puzzleMain.puzzleState = "puzzle";
                puzzleMain.skillTime = 0;
            }

            // 異常をパラメータに反映する
            playerStatusManager.ApplyAbnormalParam();

            CheckHp();

            InteractableAttackMenu();
        }
        else if(puzzleMain.puzzleState == "win")
        {
            // 勝利したとき
            if (!puzzleSceneManager.restrictPanel.activeSelf)
            {
                // 操作を制限
                puzzleSceneManager.restrictPanel.SetActive(true);

                seManager.SoundEraseSe();
            }

            puzzleMain.winTime += Time.deltaTime;

            if(puzzleMain.winTime < 0.3f)
            {
                
            }else if(puzzleMain.winTime < 0.8f)
            {
                enemyManager.eraseTime += Time.deltaTime;
                enemyManager.enemyImage.color = new Color(1, 1, 1, 1 -(enemyManager.eraseTime * 2));
            }
            else
            {
                // 操作制限を解除
                puzzleSceneManager.restrictPanel.SetActive(false);
                Win();
                puzzleMain.puzzleState = "puzzle";
            }
        }
        
    }

    public void Attack()
    {
        if (puzzleMain.puzzleState != "puzzle")
        {
            // パズル時以外押下不可
            return;
        }

        // 装備しているモールドをコンボ待ちにする
        string userMold_1 = playerPrefsManager.GetMold_1();
        string userMold_2 = playerPrefsManager.GetMold_2();

        string[] userMoldInfo_1 = playerStatusManager.GetEquipmentInfo(userMold_1);
        string[] userMoldInfo_2 = playerStatusManager.GetEquipmentInfo(userMold_2);

        string userMoldName_1 = playerStatusManager.GetEquipmentName(userMoldInfo_1);
        string userMoldName_2 = playerStatusManager.GetEquipmentName(userMoldInfo_2);
        string stageMoldName = playerPrefsManager.GetStageMold();

        waitingMoldList.Add(userMoldName_1);
        waitingMoldList.Add(userMoldName_2);
        waitingMoldList.Add(stageMoldName);

        puzzleMain.puzzleState = "attack";
        puzzleMain.comboState = "waitComboCheck";

        // ボタンは押下不可にしておく
        attackButton.interactable = false;
        infoManager.infoButton.interactable = false;
    }

    // 実際に敵を攻撃する
    public void UserAttack()
    {
        enemyManager.enemyCurrentHp -= enemyDamage;
        enemyManager.ChangeEnemyHp();

        isSoundAttackSe = false;
    }

    // 敵への攻撃SEを鳴らす
    public void SoundAttack()
    {
        // 属性のダメージを計算
        float redDamage = playerStatusManager.userCurrentAttackPower * redAttackMagnification;
        float blueDamage = playerStatusManager.userCurrentAttackPower * blueAttackMagnification;
        float greenDamage = playerStatusManager.userCurrentAttackPower * greenAttackMagnification;
        switch (enemyManager.enemyAttribute)
        {
            case "red":
                blueDamage *= 2;
                greenDamage *= 0.5f;
                break;
            case "blue":
                greenDamage *= 2;
                redDamage *= 0.5f;
                break;
            case "green":
                redDamage *= 2;
                blueDamage *= 0.5f;
                break;
        }

        if (playerStatusManager.GetAllAbnormal().Contains("sleep"))
        {
            // 睡眠状態の場合攻撃力ゼロ
            redDamage = 0;
            blueDamage = 0;
            greenDamage = 0;
        }

        int damage = (int)(redDamage + blueDamage + greenDamage);

        // 特殊効果を適用したダメージ
        enemyDamage = spEffectManager.GetApplySpEffectDamage(damage);

        if (enemyDamage == 0)
        {
            return;
        }

        float damageRatio = (float)enemyDamage / (float)enemyManager.enemyMaxHp;

        if (damageRatio <= 0.05f)
        {
            seManager.SoundAttackSe_1();
        }
        else if (damageRatio <= 0.1f)
        {
            seManager.SoundAttackSe_2();
        }
        else if (damageRatio <= 0.15f)
        {
            seManager.SoundAttackSe_3();
        }
        else
        {
            seManager.SoundAttackSe_4();
        }
    }

    // スキルボタン押下時
    public void Skill()
    {
        if (puzzleMain.puzzleState != "puzzle")
        {
            // パズル時以外押下不可
            return;
        }

        puzzleMain.puzzleState = "useSkill";

        // 押されたボタンの名前
        GameObject skillButton = eventSystem.currentSelectedGameObject;
        useSkillButtonName = skillButton.name;

    }

    // 実際にスキルを使用する
    public void UseSkill()
    {

        int skillTurn = 0;
        string skillName = "";
        if(useSkillButtonName == "SkillButton_1")
        {
            skillTurn = playerStatusManager.userCurrentSkillTurn_1;
            skillName = playerStatusManager.userSkillName_1;
        }
        else
        {
            skillTurn = playerStatusManager.userCurrentSkillTurn_2;
            skillName = playerStatusManager.userSkillName_2;
        }

        // スキルターンが0ではない場合発動不可
        if(skillTurn != 0)
        {
            return;
        }

        // スキルに応じて効果を適用する
        switch (skillName)
        {
            case "skillRedBlue":
                ChangePartsColor("red(Clone)", "blue(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillRedGreen":
                ChangePartsColor("red(Clone)", "green(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillRedPink":
                ChangePartsColor("red(Clone)", "pink(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillBlueRed":
                ChangePartsColor("blue(Clone)", "red(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillBlueGreen":
                ChangePartsColor("blue(Clone)", "green(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillBluePink":
                ChangePartsColor("blue(Clone)", "pink(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillGreenRed":
                ChangePartsColor("green(Clone)", "red(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillGreenBlue":
                ChangePartsColor("green(Clone)", "blue(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillGreenPink":
                ChangePartsColor("green(Clone)", "pink(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillPinkRed":
                ChangePartsColor("pink(Clone)", "red(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillPinkBlue":
                ChangePartsColor("pink(Clone)", "blue(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillPinkGreen":
                ChangePartsColor("pink(Clone)", "green(Clone)");
                seManager.SoundChangePanelSe();
                break;
            case "skillPowerUp_1.2":
                playerStatusManager.AddAbnormal("attackUp_1.2", 2);
                seManager.SoundParamUpSe();
                break;
            case "skillPowerUp_1.5":
                playerStatusManager.AddAbnormal("attackUp_1.5", 2);
                seManager.SoundParamUpSe();
                break;
            case "skillHealUp_1.2":
                playerStatusManager.AddAbnormal("healUp_1.2", 2);
                seManager.SoundParamUpSe();
                break;
            case "skillHealUp_1.5":
                playerStatusManager.AddAbnormal("healUp_1.5", 2);
                seManager.SoundParamUpSe();
                break;
            case "skillHealHp_30":
                skillManager.SkillHealHp(30);
                seManager.SoundHealSe();
                break;
            case "skillHealHp_50":
                skillManager.SkillHealHp(50);
                seManager.SoundHealSe();
                break;
            case "skillHealDebuff":
                playerStatusManager.HealAbnormalParam();
                seManager.SoundHealSe();
                break;
            case "skillHealBadStatus":
                playerStatusManager.HealAbnormalStatus();
                seManager.SoundHealSe();
                break;

        }

        // 異常のリフレッシュ
        playerStatusManager.RefreshAbnormal();

        playerStatusManager.ResetSkillTurn(useSkillButtonName);
    }

    // 敵と自分のHPを確認して勝ち負けを判定する
    public void CheckHp()
    {
        if (playerStatusManager.userCurrentHp <= 0)
        {
            // 自分が倒されたとき

            if(playerStatusManager.userCurrentHp < 0)
            {
                playerStatusManager.userCurrentHp = 0;
            }

            if (spEffectManager.IsLost())
            {
                // 特殊効果を適用しても倒された
                bgmManager.SoundLoseBgm();
                puzzleSceneManager.losePanel.SetActive(true);
                puzzleMain.DeleteAllParts();
                playerStatusManager.InactivatePara();
                playerStatusManager.InactivateDarkness();
                puzzleMain.attackBar_1.SetActive(false);
                puzzleMain.attackBar_2.SetActive(false);
                puzzleMain.comboState = "";
                puzzleMain.puzzleState = "puzzle";

                // ステージのモールドは削除する
                playerPrefsManager.SetStageMold("");

                return;
            }
            else
            {
                // 特殊効果で生き残る
                playerStatusManager.userCurrentHp = 1;
                playerStatusManager.ChangeHp();
                return;
            }
        }

        if (enemyManager.enemyCurrentHp <= 0)
        {
            puzzleMain.puzzleState = "win";
        }        
    }

    // 勝利して勝利パネルを表示するときの処理
    public void Win()
    {
        bgmManager.SoundWinBgm();
        puzzleSceneManager.winPanel.SetActive(true);
        clearPanelManager.LotteryBooty();

        // ステージの見た目
        puzzleMain.DeleteAllParts();
        playerStatusManager.InactivatePara();
        playerStatusManager.InactivateDarkness();
        puzzleMain.attackBar_1.SetActive(false);
        puzzleMain.attackBar_2.SetActive(false);

        // ステージのモールドは削除する
        playerPrefsManager.SetStageMold("");

        // クリアレベルの更新
        int stageLevel = playerPrefsManager.GetPlayLevel();
        string stageType = playerPrefsManager.GetPlayStageType();
        if (playerPrefsManager.GetPlayerLevel() == stageLevel)
        {
            if (stageType == "volcano")
            {
                playerPrefsManager.SetClearedLevelVolcano(stageLevel);
            }
            else if (stageType == "ship")
            {
                playerPrefsManager.SetClearedLevelShip(stageLevel);
            }
            else if (stageType == "forest")
            {
                playerPrefsManager.SetClearedLevelForest(stageLevel);
            }
            else if (stageType == "boss")
            {
                playerPrefsManager.SetPlayerLevel(playerPrefsManager.GetPlayerLevel() + 1);
            }
        }

        // 次の敵の設定を保存
        if (stageType == "boss")
        {
            enemyManager.SaveRandomBoss();
        }
        else
        {
            enemyManager.SaveRandomEnemy();
        }

        if (playerPrefsManager.GetFirstWin() == "true")
        {
            // 初めて勝利した場合チュートリアル
            tutorialManager.StartWinTutorial();
        }
    }

    // ボタンを押下可能にする
    public void InteractableAttackMenu()
    {
        attackButton.interactable = true;
        infoManager.infoButton.interactable = true;
    }

    // パーツの色を変更する
    public void ChangePartsColor(string beforeColorPrefabName, string afterColorPrefabName)
    {
        int buttonNum = 0;
        foreach(Dictionary<string, GameObject> block in puzzleMain.partsList)
        {
            var partLr = block["lr"];
            var partUl = block["ul"];
            var partLl = block["ll"];
            var partUr = block["ur"];

            if (partLr && partLr.name == beforeColorPrefabName)
            {
                if(UnityEngine.Random.Range(0,3) <= 1)
                {
                    Destroy(partLr);
                    block["lr"] = puzzleMain.CreatePart(afterColorPrefabName, buttonNum, "lr");
                }
            }
            if (partUl && partUl.name == beforeColorPrefabName)
            {
                if(UnityEngine.Random.Range(0, 3) <= 1)
                {
                    Destroy(partUl);
                    block["ul"] = puzzleMain.CreatePart(afterColorPrefabName, buttonNum, "ul");
                }
            }
            if (partLl && partLl.name == beforeColorPrefabName)
            {
                if (UnityEngine.Random.Range(0, 3) <= 1)
                {
                    Destroy(partLl);
                    block["ll"] = puzzleMain.CreatePart(afterColorPrefabName, buttonNum, "ll");
                }
            }
            if (partUr && partUr.name == beforeColorPrefabName)
            {
                if (UnityEngine.Random.Range(0, 3) <= 1)
                {
                    Destroy(partUr);
                    block["ur"] = puzzleMain.CreatePart(afterColorPrefabName, buttonNum, "ur");
                }
            }

            buttonNum++;
        }
    }

    // ユーザのHPを回復する
    public void Heal()
    {
        int healPoint = (int)(playerStatusManager.userCurrentHealPower * healMagnification);

        int applyHealPoint = spEffectManager.GetApplySpEffectHeal(healPoint);

        if (playerStatusManager.GetAllAbnormal().Contains("confuse"))
        {
            // 混乱状態の場合ダメージを受ける
            playerStatusManager.userCurrentHp -= applyHealPoint;
            if (playerStatusManager.userCurrentHp < 0)
            {
                // HPがマイナスにならないように
                playerStatusManager.userCurrentHp = 0;
            }
        }
        else
        {
            playerStatusManager.userCurrentHp += applyHealPoint;
            if (playerStatusManager.userCurrentHp > playerStatusManager.userMaxHp)
            {
                // 最大HPを上回って回復した場合は最大HPにする
                playerStatusManager.userCurrentHp = playerStatusManager.userMaxHp;
            }
        }        

        playerStatusManager.ChangeHp();
    }

    // 敵から攻撃される
    public void EnemyAttack()
    {
        seManager.SoundEnemyAttackSe();

        enemyManager.SetRandomEnemyAttack();

        // 特殊効果を適用
        int damage = spEffectManager.GetApplySpEffectEnemyDamage((int)enemyManager.enemyAttackPower);

        if (playerStatusManager.GetAllAbnormal().Contains("sleep"))
        {
            // 睡眠状態の場合2倍
            playerStatusManager.userCurrentHp -= damage*2;
        }
        else if (playerStatusManager.GetAllAbnormal().Contains("burn"))
        {
            // 火傷状態の場合1.5倍
            playerStatusManager.userCurrentHp -= (int)(damage*1.5);
        }
        else
        {
            playerStatusManager.userCurrentHp -= damage;
        }

        if (playerStatusManager.userCurrentHp < 0)
        {
            // HPがマイナスにならないように
            playerStatusManager.userCurrentHp = 0;
        }

        playerStatusManager.ChangeHp();

        isSoundEnemyAttackSe = false;
    }

    // HPの割合によってバーの色を変える
    public void ChangeHpColor(Slider hpSlider , GameObject fill)
    {
        float hpRatio = hpSlider.value;
        if(hpRatio >= 0.75f)
        {
            fill.GetComponent<Image>().color = new Color32(135, 255, 65, 255);
        }
        else if(hpRatio >= 0.5f)
        {
            fill.GetComponent<Image>().color = new Color32(236, 255, 65, 255);
        }
        else if (hpRatio >= 0.25f)
        {
            fill.GetComponent<Image>().color = new Color32(255, 162, 65, 255);
        }
        else
        {
            fill.GetComponent<Image>().color = new Color32(255, 78, 65, 255);
        }
    }

    // 引数モールドが同じ色のみで構成されていればコンボさせる。この関数では縦1列または横1行を確認する。
    public void ComboSameColor(int endNum, List<int> blockList, List<string> directionList)
    {
        // 配列に変換
        int[] blockArray = blockList.ToArray();
        string[] directionArray = directionList.ToArray();

        for (int i = 0; i < endNum; i ++)
        {
            // 同じ色かチェックする
            string color = GetSameColor(i, blockArray, directionArray);
            if (color != "")
            {
                // 同じ色だった場合コンボ発生の処理をする
                isCombo = true;

                // パーツをコンボ用パーツに変える
                comboParts.AddRange(ChangeComboPart(color, i, blockArray, directionArray));
            }
        }
    }

    // モールドが全て同じ色かチェックする。同じ色の場合その色（プレハブ名）を返す
    public string GetSameColor(int num, int [] blockArray, string [] directionArray)
    {
        string baseColor = "";
        List<string> sameColorList = new List<string>();

        for (int i = 0; i < blockArray.Length; i++)
        {
            int blockNum = blockArray[i] + num;
            string direction = directionArray[i];

            GameObject part = puzzleMain.partsList[blockNum][direction];

            if (!part)
            {
                // パーツが無い（NULL）の場合は終了
                return "";
            }

            // パーツの色（オブジェクトの名前）例：red(Clone)
            string partColor = part.name;

            if (i == 0)
            {
                // 最初のパーツの場合はとりあえず保存する
                sameColorList.Add(blockNum.ToString() + direction);

                if (partColor == "white(Clone)")
                {
                    // 白の場合は保存しない
                    continue;
                }

                // ベースカラーとして保存する
                baseColor = partColor;
            }
            else
            {
                // 2つ目以降のパーツの場合は同じ色かチェックする
                if (partColor == "white(Clone)")
                {
                    // 白の場合はチェックしない
                    sameColorList.Add(blockNum.ToString() + direction);
                    continue;
                }

                if (baseColor == "" || baseColor == partColor)
                {
                    // ベース色が白または色が同じ場合比較処理を続ける
                    sameColorList.Add(blockNum.ToString() + direction);
                    baseColor = partColor;
                }
                else
                {
                    // 色が異なる場合終了
                    return "";
                }
            }
        }

        // 全てチェックが完了したら全て同じ色とする。
        // 消すべきパーツを保存する。
        if (baseColor != "")
        {
            foreach (string sameColor in sameColorList)
            {
                if (!allComboParts.Contains(sameColor))
                {
                    allComboParts.Add(sameColor);
                }
            }
        }

        // 各攻撃力計算に使うため保存する。
        switch (baseColor)
        {
            case "red(Clone)":
                foreach (string sameColor in sameColorList)
                {
                    if (!redComboList.Contains(sameColor))
                    {
                        redComboList.Add(sameColor);
                    }
                }
                break;
            case "blue(Clone)":
                foreach (string sameColor in sameColorList)
                {
                    if (!blueComboList.Contains(sameColor))
                    {
                        blueComboList.Add(sameColor);
                    }
                }
                break;
            case "green(Clone)":
                foreach (string sameColor in sameColorList)
                {
                    if (!greenComboList.Contains(sameColor))
                    {
                        greenComboList.Add(sameColor);
                    }
                }
                break;
            case "pink(Clone)":
                foreach (string sameColor in sameColorList)
                {
                    if (!pinkComboList.Contains(sameColor))
                    {
                        pinkComboList.Add(sameColor);
                    }
                }
                break;
        }
        
        return baseColor;
    }

    // コンボで消すパーツの上にコンボ用プレハブを生成する。生成したプレハブはリストにいれて返す。
    public List<GameObject> ChangeComboPart(string color, int num, int[] blockArray, string[] directionArray)
    {
        List<GameObject> changedComboParts = new List<GameObject>();

        for (int i = 0; i < blockArray.Length; i++)
        {
            int blockNum = blockArray[i] + num;
            string direction = directionArray[i];

            string comboColor = puzzleMain.GetComboColor(color);

            GameObject comboPart = puzzleMain.CreatePart(comboColor, blockNum, direction);

            changedComboParts.Add(comboPart);
        }

        return changedComboParts;
    }

    // 倍率に追加する
    public void AddMagnification(string mold)
    {
        // モールドの倍率を取得する
        float magnification = moldManager.GetMoldMagnification(mold);

        // 各色毎に倍率を追加する
        redAttackMagnification += magnification * redComboList.Count;
        blueAttackMagnification += magnification * blueComboList.Count;
        greenAttackMagnification += magnification * greenComboList.Count;
        healMagnification += magnification * pinkComboList.Count;

        SetDisplayMag();

        // 追加したら空にする
        redComboList.Clear();
        blueComboList.Clear();
        greenComboList.Clear();
        pinkComboList.Clear();
    }

    // 倍率をリセットする
    public void ResetMagnification()
    {
        redAttackMagnification = 0;
        blueAttackMagnification = 0;
        greenAttackMagnification = 0;
        healMagnification = 0;

        SetDisplayMag();
    }

    // 画面に倍率を表示する
    public void SetDisplayMag()
    {
        Math.Round(0.11, 1);
        redMagText.text = Math.Round(redAttackMagnification, 1).ToString();
        blueMagText.text = Math.Round(blueAttackMagnification, 1).ToString();
        greenMagText.text = Math.Round(greenAttackMagnification, 1).ToString();
        pinkMagText.text = Math.Round(healMagnification, 1).ToString();
    }

    // 攻撃後新しいパーツを生成する
    public void CreatePartsAfterAttack()
    {
        // 既に消すパーツ数に応じて白を生成するかどうか決める。
        bool createWhite = false;
        int x = UnityEngine.Random.Range(1, 11);
        if(allComboParts.Count >= 40 ||
            (allComboParts.Count >= 30 && x <= 6) ||
            (allComboParts.Count >= 20 && x <= 4) ||
            (allComboParts.Count >= 10 && x <= 2))
        {
            createWhite = true;
        }

        int whiteNum = 99;
        if (createWhite)
        {
            whiteNum = UnityEngine.Random.Range(1, allComboParts.Count + 1);
        }

        int roopCount = 0;

        foreach (string part in allComboParts)
        {
            roopCount++;

            string direction = part.Substring(part.Length - 2);
            int blockNum = int.Parse(part.Replace(direction, ""));

            // コンボしたパーツを削除する
            Destroy(puzzleMain.partsList[blockNum][direction]);

            string color = "";
            if(whiteNum == roopCount)
            {
                // 白を生成する。
                color = "white(Clone)";
            }
            else
            {
                // ランダムでパーツを選んで生成する
                color = puzzleMain.GetRandomPart_4();
            }
            
            GameObject newPart = puzzleMain.CreatePart(color, blockNum, direction);
            puzzleMain.partsList[blockNum][direction] = newPart;
        }
    }

    public void ComboWholePanel(List<int> moldParts, int moldVerticalLength, int moldHorizontalLength)
    {
        int blockNum = 0;
        int directionNum = 1;

        List<int> blockList = new List<int>();
        List<string> directionList = new List<string>();

        int repeatVerticalNum = 6 - moldVerticalLength;
        int repeatHorizontalNum = 6 - moldHorizontalLength;

        // ブロックと向きを取得
        while (directionNum < moldParts.Count)
        {
            blockList.Add(moldParts[blockNum]);

            int direction = moldParts[directionNum];
            switch (direction)
            {
                case 1:
                    directionList.Add("ur");
                    break;
                case 2:
                    directionList.Add("lr");
                    break;
                case 3:
                    directionList.Add("ll");
                    break;
                case 4:
                    directionList.Add("ul");
                    break;
            }
            blockNum += 2;
            directionNum += 2;
        }

        // 横にずらして確認
        int repeatAddNum = 0;
        while (repeatHorizontalNum > 0)
        {
            List<int> addBlockList = new List<int>();
            blockList.ForEach(m =>
            {
                addBlockList.Add(m + repeatAddNum);
            });

            ComboSameColor(repeatVerticalNum, addBlockList, directionList);

            repeatHorizontalNum--;
            repeatAddNum +=5;
        }
    }

    // モールド毎にコンボチェックパターンの定義をする
    public void CheckMoldPattern()
    {
        if(waitingMoldList.Count == 0)
        {
            // 全てのモールドの確認が終わったら敵への攻撃エフェクトに移る。

            if(redAttackMagnification == 0 && blueAttackMagnification == 0 && greenAttackMagnification == 0)
            {
                // コンボが発生していない（攻撃の必要なし）場合はエフェクト無し。
                puzzleMain.comboState = "waitComboAttack";
                return;
            }

            puzzleMain.comboState = "waitAttackEffect";
            return;            
        }

        // コンボカウントアップ
        moldComboNum++;

        string mold = waitingMoldList[0];

        switch (mold)
        {
            case "rod_2":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3 }, 1, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 5, 4 }, 1, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 1, 4 }, 2, 1);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1 }, 2, 1);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "triangle_2":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 5, 3 }, 1, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 1, 5, 4 }, 1, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1 }, 2, 1);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 3, 1, 4 }, 2, 1);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "square_2":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3 }, 1, 1);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4 }, 1, 1);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "rod_3":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 4 }, 2, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1 }, 2, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 1, 4, 5, 4 }, 2, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 6, 3 }, 2, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "beak_3":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 3, }, 2, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1,  6, 4 }, 2, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2,  5, 3, 6, 4 }, 2, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> {  1, 1, 5, 3, 6, 4 }, 2, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "house_3":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 1, 3 }, 2, 1);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 3, 1, 2, 1, 4 }, 2, 1);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 1, 3 }, 2, 1);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 1, 4 }, 2, 1);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1 }, 2, 1);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 1 }, 2, 1);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 4 }, 2, 1);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 4 }, 2, 1);
                        break;
                    case 9:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 5, 3 }, 1, 2);
                        break;
                    case 10:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 5, 3 }, 1, 2);
                        break;
                    case 11:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 5, 4 }, 1, 2);
                        break;
                    case 12:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 5, 4 }, 1, 2);
                        break;
                    case 13:
                        ComboWholePanel(new List<int> { 0, 1, 5, 1, 5, 3 }, 1, 2);
                        break;
                    case 14:
                        ComboWholePanel(new List<int> { 0, 1, 5, 2, 5, 4 }, 1, 2);
                        break;
                    case 15:
                        ComboWholePanel(new List<int> { 0, 2, 5, 1, 5, 3 }, 1, 2);
                        break;
                    case 16:
                        ComboWholePanel(new List<int> { 0, 2, 5, 2, 5, 4 }, 1, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "rod_4":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 4, 10, 4 }, 2, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 11, 3 }, 2, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 1, 2, 2, 4, 5, 2, 6, 4 }, 3, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 6, 3, 7, 1 }, 3, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "triangle_4":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 2, 6, 4 }, 2, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 1, 5, 1, 5, 3, 6, 1 }, 2, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 1, 5, 2, 5, 4, 6, 1 }, 2, 2);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 1, 3, 6, 3 }, 2, 2);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 0, 3, 1, 2, 1, 4, 6, 3 }, 2, 2);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 4, 5, 4 }, 2, 2);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 4, 5, 4 }, 2, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "square_4":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 3, 6, 4 }, 2, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "fox_4":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 5, 2, 6, 4 }, 2, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 1, 1, 2, 5, 3, 6, 4 }, 2, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 1, 4, 5, 3, 6, 1 }, 2, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 4, 6, 3 }, 2, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "trapezoid_4":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 5, 1, 5, 3, 10, 3 }, 1, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 5, 2, 5, 4, 10, 3 }, 1, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 1, 5, 1, 5, 3, 10, 4 }, 1, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 1, 5, 2, 5, 4, 10, 4 }, 1, 3);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 1, 3, 2, 1 }, 3, 1);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 1, 4, 2, 1 }, 3, 1);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 1, 3, 2, 4 }, 3, 1);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 3, 1, 2, 1, 4, 2, 4 }, 3, 1);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "bar_4":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 1, 3 }, 2, 1);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 2, 1, 4 }, 2, 1);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 5, 1, 5, 3 }, 1, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 5, 2, 5, 4 }, 1, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "bird_4":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 6, 3, 7, 4 }, 3, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 3, 6, 4 }, 3, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 1, 1, 5, 2, 6, 4, 10, 3 }, 2, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 5, 3, 6, 1, 11, 4 }, 2, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "rod_5":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 2, 2, 6, 2, 7, 4, 10, 2, 11, 4 }, 3, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 2, 2, 4, 5, 2, 6, 4, 10, 4 }, 3, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 6, 3, 7, 1, 12, 3 }, 3, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 11, 3, 12, 1 }, 3, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "ship_5":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 1, 1, 5, 2, 6, 1, 6, 3, 11, 4 }, 2, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 1, 5, 2, 6, 2, 6, 4, 11, 4 }, 2, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 1, 1, 5, 3, 6, 1, 6, 3, 11, 4 }, 2, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 1, 1, 5, 3, 6, 2, 6, 4, 11, 4 }, 2, 3);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 0, 2, 5, 1, 5, 3, 6, 4, 10, 3 }, 2, 3);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 0, 2, 5, 2, 5, 4, 6, 4, 10, 3 }, 2, 3);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 2, 5, 1, 5, 3, 6, 1, 10, 3 }, 2, 3);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 2, 5, 2, 5, 4, 6, 1, 10, 3 }, 2, 3);
                        break;
                    case 9:
                        ComboWholePanel(new List<int> { 1, 1, 5, 3, 6, 1, 6, 3, 7, 4 }, 3, 2);
                        break;
                    case 10:
                        ComboWholePanel(new List<int> { 1, 1, 5, 3, 6, 2, 6, 4, 7, 4 }, 3, 2);
                        break;
                    case 11:
                        ComboWholePanel(new List<int> { 1, 2, 5, 3, 6, 1, 6, 3, 7, 4 }, 3, 2);
                        break;
                    case 12:
                        ComboWholePanel(new List<int> { 1, 2, 5, 3, 6, 2, 6, 4, 7, 4 }, 3, 2);
                        break;
                    case 13:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 1, 3, 2, 1, 6, 4 }, 3, 2);
                        break;
                    case 14:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 1, 4, 2, 1, 6, 4 }, 3, 2);
                        break;
                    case 15:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 1, 3, 2, 1, 6, 3 }, 3, 2);
                        break;
                    case 16:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 1, 4, 2, 1, 6, 3 }, 3, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "house_5":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 5, 3, 6, 4 }, 2, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 1, 5, 3, 6, 4 }, 2, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 1, 5, 3, 6, 4 }, 2, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 2, 5, 4, 6, 4 }, 2, 2);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 3, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 3, 6, 2, 6, 4 }, 2, 2);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 1, 3, 5, 3, 6, 4 }, 2, 2);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 1, 4, 5, 3, 6, 4 }, 2, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "boots_5":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 1, 2, 5, 1, 5, 3, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 5, 4, 6, 2, 6, 4 }, 2, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 1, 3, 6, 3 }, 2, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 2, 1, 4, 6, 3 }, 2, 2);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 0, 1, 5, 1, 5, 3, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 0, 1, 5, 2, 5, 4, 6, 2, 6, 4 }, 2, 2);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 1, 3, 5, 4 }, 2, 2);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 2, 1, 4, 5, 4 }, 2, 2);
                        break;
                    case 9:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 5, 1, 5, 3, 6, 1 }, 2, 2);
                        break;
                    case 10:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 5, 2, 5, 4, 6, 1 }, 2, 2);
                        break;
                    case 11:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 5, 1, 5, 3, 1, 4 }, 2, 2);
                        break;
                    case 12:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 5, 2, 5, 4, 1, 4 }, 2, 2);
                        break;
                    case 13:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 1, 3, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 14:
                        ComboWholePanel(new List<int> { 0, 3, 1, 2, 1, 4, 6, 2, 6, 4 }, 2, 2);
                        break;
                    case 15:
                        ComboWholePanel(new List<int> { 5, 2, 1, 1, 1, 3, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 16:
                        ComboWholePanel(new List<int> { 5, 2, 1, 2, 1, 4, 6, 2, 6, 4 }, 2, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "phone_5":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 1, 3, 5, 1, 5, 3 }, 2, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 1, 4, 5, 2, 5, 4 }, 2, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 6, 4, 1, 1, 1, 3, 5, 1, 5, 3 }, 2, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 6, 4, 1, 2, 1, 4, 5, 2, 5, 4 }, 2, 2);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 1, 6, 2, 6, 4 }, 2, 2);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 5, 3, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 5, 3, 6, 2, 6, 4 }, 2, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "rod_6":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 2, 2, 6, 2, 7, 4, 10, 2, 11, 4, 15, 4 }, 3, 4);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 11, 3, 12, 1, 17, 3 }, 3, 4);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 2, 2, 3, 4, 6, 2, 7, 4, 10, 2, 11, 4 }, 4, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 6, 3, 7, 1, 12, 3, 13, 1 }, 4, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "snake_6":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 2, 2, 5, 4, 6, 3, 7, 4 }, 3, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 1, 1, 2, 2, 1, 5, 3, 6, 4, 7, 3 }, 3, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 5, 2, 6, 4, 10, 3, 11, 1 }, 2, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 1, 4, 5, 3, 6, 1, 10, 2, 11, 4 }, 2, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            
            case "windmill_6":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 1, 1, 5, 2, 6, 1, 6, 3, 7, 4, 11, 3 }, 3, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 1, 5, 2, 6, 2, 6, 4, 7, 4, 11, 3 }, 3, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 1, 2, 5, 3, 6, 1, 6, 3, 7, 1, 11, 4 }, 3, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 1, 2, 5, 3, 6, 2, 6, 4, 7, 1, 11, 4 }, 3, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "v_6":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 10, 2, 11, 4, 15, 4 }, 2, 4);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 4, 10, 3, 11, 1, 16, 3 }, 2, 4);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 2, 6, 4, 7, 3, 8, 1 }, 4, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 2, 2, 3, 4, 6, 3, 7, 4 }, 4, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "rugby_6":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 5, 3, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 1, 5, 3, 6, 2, 6, 4 }, 2, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 1, 3, 5, 1, 5, 3, 6, 4 }, 2, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 1, 4, 5, 2, 5, 4, 6, 4 }, 2, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "rod_7":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 3, 2, 7, 2, 8, 4, 11, 2, 12, 4, 15, 2, 16, 4 }, 4, 4);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 2, 2, 3, 4, 6, 2, 7, 4, 10, 2, 11, 4, 15, 4 }, 4, 4);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 6, 3, 7, 1, 12, 3, 13, 1, 18, 3 }, 4, 4);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 11, 3, 12, 1, 17, 3, 18, 1 }, 4, 4);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "diamond_7":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 1, 3, 5, 1, 5, 3, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 1, 4, 5, 2, 5, 4, 6, 2, 6, 4 }, 2, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 5, 1, 5, 3, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 1, 5, 2, 5, 4, 6, 2, 6, 4 }, 2, 2);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 1, 3, 5, 1, 5, 3, 6, 4 }, 2, 2);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 2, 1, 4, 5, 2, 5, 4, 6, 4 }, 2, 2);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 1, 3, 5, 3, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 2, 1, 4, 5, 3, 6, 2, 6, 4 }, 2, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "v_7":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 2, 2, 7, 1, 7, 3, 10, 2, 11, 1, 11, 3, 12, 4 }, 3, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 2, 2, 7, 2, 7, 4, 10, 2, 11, 2, 11, 4, 12, 4 }, 3, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 1, 5, 1, 5, 3, 10, 3, 11, 1, 11, 3, 12, 1 }, 3, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 1, 5, 2, 5, 4, 10, 3, 11, 2, 11, 4, 12, 1 }, 3, 3);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 1, 3, 2, 4, 5, 1, 5, 3, 10, 4 }, 3, 3);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 1, 4, 2, 4, 5, 2, 5, 4, 10, 4 }, 3, 3);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 1, 3, 2, 1, 7, 1, 7, 3, 12, 3 }, 3, 3);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 3, 1, 2, 1, 4, 2, 1, 7, 2, 7, 4, 12, 3 }, 3, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "staple_7":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 2, 6, 4, 7, 4, 10, 3, 11, 4 }, 3, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 2, 6, 2, 7, 4, 10, 3, 11, 4 }, 3, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 3, 6, 3, 7, 1, 11, 3, 12, 4 }, 3, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 3, 6, 1, 7, 1, 11, 3, 12, 4 }, 3, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "shootingStar_7":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 1, 1, 5, 3, 6, 1, 6, 3, 7, 1, 11, 3, 12, 4 }, 3, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 1, 5, 3, 6, 2, 6, 4, 7, 1, 11, 3, 12, 4 }, 3, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 3, 6, 1, 6, 3, 7, 1, 11, 3 }, 3, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 3, 6, 2, 6, 4, 7, 1, 11, 3 }, 3, 3);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 1, 6, 3, 7, 4, 10, 3, 11, 4 }, 3, 3);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 2, 6, 4, 7, 4, 10, 3, 11, 4 }, 3, 3);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 2, 6, 1, 6, 3, 7, 4, 11, 4 }, 3, 3);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 2, 6, 2, 6, 4, 7, 4, 11, 4 }, 3, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "rod_8":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 11, 3, 12, 1, 17, 3, 18, 1, 23, 3 }, 4, 5);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 3, 2, 7, 2, 8, 4, 11, 2, 12, 4, 15, 2, 16, 4, 20, 4 }, 4, 5);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 3, 2, 4, 4, 7, 2, 8, 4, 11, 2, 12, 4, 15, 2, 16, 4 }, 5, 4);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 6, 3, 7, 1, 12, 3, 13, 1, 18, 3, 19, 1 }, 5, 4);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "snake_8":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 1, 2, 2, 1, 3, 2, 5, 3, 6, 4, 7, 3, 8, 4 }, 4, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 2, 2, 3, 1, 5, 4, 6, 3, 7, 4, 8, 3 }, 4, 2);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 1, 4, 5, 3, 6, 1, 10, 2, 11, 4, 15, 3, 16, 1 }, 2, 4);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 5, 2, 6, 4, 10, 3, 11, 1, 15, 2, 16, 4 }, 2, 4);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "s_8":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 4, 6, 1, 6, 3, 7, 2, 11, 3, 12, 4 }, 3, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 5, 4, 6, 2, 6, 4, 7, 2, 11, 3, 12, 4 }, 3, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 1, 6, 1, 6, 3, 7, 3, 10, 3, 11, 4 }, 3, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 1, 6, 2, 6, 4, 7, 3, 10, 3, 11, 4 }, 3, 3);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 1, 3, 2, 1, 5, 2, 6, 1, 6, 3, 7, 4, 10, 3, 11, 1 }, 3, 3);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 1, 3, 2, 1, 5, 2, 6, 2, 6, 4, 7, 4, 10, 3, 11, 1 }, 3, 3);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 2, 1, 4, 5, 3, 6, 1, 6, 3, 7, 1, 11, 2, 12, 4 }, 3, 3);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 2, 1, 4, 5, 3, 6, 2, 6, 4, 7, 1, 11, 2, 12, 4 }, 3, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "square_8":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 1, 3, 5, 1, 5, 3, 6, 1, 6, 3 }, 2, 2);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 2, 1, 4, 5, 2, 5, 4, 6, 2, 6, 4 }, 2, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "hat_8":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 1, 1, 5, 2, 6, 1, 6, 3, 10, 3, 11, 1, 11, 3, 16, 4 }, 2, 4);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 1, 5, 2, 6, 2, 6, 4, 10, 3, 11, 2, 11, 4, 16, 4 }, 2, 4);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 5, 1, 5, 3, 6, 1, 10, 1, 10, 3, 11, 4, 15, 3 }, 2, 4);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 2, 5, 2, 5, 4, 6, 1, 10, 2, 10, 4, 11, 4, 15, 3 }, 2, 4);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 1, 3, 2, 1, 2, 3, 3, 1, 6, 3, 7, 4 }, 4, 2);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 1, 4, 2, 2, 2, 4, 3, 1, 6, 3, 7, 4 }, 4, 2);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 3, 6, 1, 6, 3, 7, 1, 7, 3, 8, 4 }, 4, 2);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 3, 6, 2, 6, 4, 7, 2, 7, 4, 8, 4 }, 4, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "rod_9":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 4, 2, 8, 2, 9, 4, 12, 2, 13, 4, 16, 2, 17, 4, 20, 2, 21, 4 }, 5, 5);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 6, 3, 7, 1, 12, 3, 13, 1, 18, 3, 19, 1, 24, 3 }, 5, 5);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 11, 3, 12, 1, 17, 3, 18, 1, 23, 3, 24, 1 }, 5, 5);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 3, 2, 4, 4, 7, 2, 8, 4, 11, 2, 12, 4, 15, 2, 16, 4, 20, 4 }, 5, 5);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "arch_9":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 2, 6, 4, 7, 3, 8, 1, 10, 3, 11, 1, 16, 3 }, 4, 4);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 2, 6, 4, 7, 3, 8, 1, 12, 2, 13, 4, 17, 4 }, 4, 4);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 2, 1, 7, 3, 8, 1, 10, 3, 11, 1, 12, 2, 13, 4, 16, 3, 17, 4 }, 4, 4);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 4, 10, 3, 11, 1, 12, 2, 13, 4, 16, 3, 17, 4 }, 4, 4);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "factory_9":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 1, 3, 5, 2, 6, 1, 6, 3, 10, 2, 11, 1, 11, 3 }, 2, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 1, 4, 5, 2, 6, 2, 6, 4, 10, 2, 11, 2, 11, 4 }, 2, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 1, 3, 5, 3, 6, 1, 6, 3, 10, 3, 11, 1, 11, 3 }, 2, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 3, 1, 2, 1, 4, 5, 3, 6, 2, 6, 4, 10, 3, 11, 2, 11, 4 }, 2, 3);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 4, 5, 1, 5, 3, 6, 4, 10, 1, 10, 3, 11, 4 }, 2, 3);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 4, 5, 2, 5, 4, 6, 4, 10, 2, 10, 4, 11, 4 }, 2, 3);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 5, 1, 5, 3, 6, 1, 10, 1, 10, 3, 11, 1 }, 2, 3);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 1, 5, 2, 5, 4, 6, 1, 10, 2, 10, 4, 11, 1 }, 2, 3);
                        break;
                    case 9:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 1, 3, 2, 1, 2, 3, 5, 3, 6, 3, 7, 3 }, 3, 2);
                        break;
                    case 10:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 2, 1, 4, 2, 2, 2, 4, 5, 3, 6, 3, 7, 3 }, 3, 2);
                        break;
                    case 11:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 1, 3, 2, 1, 2, 3, 5, 4, 6, 4, 7, 4 }, 3, 2);
                        break;
                    case 12:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 2, 1, 4, 2, 2, 2, 4, 5, 4, 6, 4, 7, 4 }, 3, 2);
                        break;
                    case 13:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 2, 2, 5, 1, 5, 3, 6, 1, 6, 3, 7, 1, 7, 3 }, 3, 2);
                        break;
                    case 14:
                        ComboWholePanel(new List<int> { 0, 2, 1, 2, 2, 2, 5, 2, 5, 4, 6, 2, 6, 4, 7, 2, 7, 4 }, 3, 2);
                        break;
                    case 15:
                        ComboWholePanel(new List<int> { 0, 1, 1, 1, 2, 1, 5, 1, 5, 3, 6, 1, 6, 3, 7, 1, 7, 3 }, 3, 2);
                        break;
                    case 16:
                        ComboWholePanel(new List<int> { 0, 1, 1, 1, 2, 1, 5, 2, 5, 4, 6, 2, 6, 4, 7, 2, 7, 4 }, 3, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "armani_9":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 10, 3, 11, 1, 11, 3, 15, 2, 16, 4, 20, 4 }, 2, 5);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 10, 3, 11, 2, 11, 4, 15, 2, 16, 4, 20, 4 }, 2, 5);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 10, 2, 11, 1, 11, 3, 15, 2, 16, 4, 20, 4 }, 2, 5);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 10, 2, 11, 2, 11, 4, 15, 2, 16, 4, 20, 4 }, 2, 5);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 4, 10, 1, 10, 3, 11, 1, 15, 3, 16, 1, 21, 3 }, 2, 5);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 4, 10, 2, 10, 4, 11, 1, 15, 3, 16, 1, 21, 3 }, 2, 5);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 4, 10, 1, 10, 3, 11, 4, 15, 3, 16, 1, 21, 3 }, 2, 5);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 1, 2, 5, 2, 6, 4, 10, 2, 10, 4, 11, 4, 15, 3, 16, 1, 21, 3 }, 2, 5);
                        break;
                    case 9:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 2, 3, 3, 1, 5, 2, 6, 4, 7, 4, 8, 3, 9, 1 }, 5, 2);
                        break;
                    case 10:
                        ComboWholePanel(new List<int> { 1, 2, 2, 2, 2, 4, 3, 1, 5, 2, 6, 4, 7, 4, 8, 3, 9, 1 }, 5, 2);
                        break;
                    case 11:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 2, 3, 3, 1, 5, 2, 6, 4, 7, 3, 8, 3, 9, 1 }, 5, 2);
                        break;
                    case 12:
                        ComboWholePanel(new List<int> { 1, 2, 2, 2, 2, 4, 3, 1, 5, 2, 6, 4, 7, 3, 8, 3, 9, 1 }, 5, 2);
                        break;
                    case 13:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 2, 2, 3, 2, 4, 4, 6, 3, 7, 1, 7, 3, 8, 4 }, 5, 2);
                        break;
                    case 14:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 2, 2, 3, 2, 4, 4, 6, 3, 7, 2, 7, 4, 8, 4 }, 5, 2);
                        break;
                    case 15:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 2, 1, 3, 2, 4, 4, 6, 3, 7, 1, 7, 3, 8, 4 }, 5, 2);
                        break;
                    case 16:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 2, 1, 3, 2, 4, 4, 6, 3, 7, 2, 7, 4, 8, 4 }, 5, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "snake_10":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 1, 4, 5, 3, 6, 1, 10, 2, 11, 4, 15, 3, 16, 1, 20, 2, 21, 4 }, 2, 5);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 5, 2, 6, 4, 10, 3, 11, 1, 15, 2, 16, 4, 20, 3, 21, 1 }, 2, 5);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 2, 2, 3, 1, 4, 2, 5, 4, 6, 3, 7, 4, 8, 3, 9, 4 }, 5, 2);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 1, 1, 2, 2, 1, 3, 2, 4, 1, 5, 3, 6, 4, 7, 3, 8, 4, 9, 3 }, 5, 2);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;

            case "windmill_10":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 2, 2, 5, 2, 6, 1, 6, 3, 7, 4, 10, 4, 11, 3, 12, 1 }, 3, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 2, 2, 5, 2, 6, 2, 6, 4, 7, 4, 10, 4, 11, 3, 12, 1 }, 3, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 0, 1, 1, 2, 2, 4, 5, 3, 6, 1, 6, 3, 7, 1, 10, 2, 11, 4, 12, 3 }, 3, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 0, 1, 1, 2, 2, 4, 5, 3, 6, 2, 6, 4, 7, 1, 10, 2, 11, 4, 12, 3 }, 3, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "bison_10":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 6, 3, 7, 1, 12, 1, 12, 3, 16, 2, 17, 4, 20, 3, 21, 4 }, 3, 5);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 1, 1, 6, 3, 7, 1, 12, 2, 12, 4, 16, 2, 17, 4, 20, 3, 21, 4 }, 3, 5);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 2, 6, 4, 10, 1, 10, 3, 15, 3, 16, 1, 21, 3, 22, 4 }, 3, 5);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 5, 2, 6, 4, 10, 2, 10, 4, 15, 3, 16, 1, 21, 3, 22, 4 }, 3, 5);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 2, 3, 3, 1, 5, 2, 6, 4, 8, 3, 9, 1, 10, 3, 14, 4 }, 5, 3);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 1, 2, 2, 2, 2, 4, 3, 1, 5, 2, 6, 4, 8, 3, 9, 1, 10, 3, 14, 4 }, 5, 3);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 2, 4, 1, 5, 3, 6, 1, 8, 2, 9, 4, 11, 3, 12, 1, 12, 3, 13, 4 }, 5, 3);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 2, 4, 1, 5, 3, 6, 1, 8, 2, 9, 4, 11, 3, 12, 2, 12, 4, 13, 4 }, 5, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "plus_10":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 1, 1, 1, 3, 5, 1, 5, 3, 6, 1, 6, 3, 7, 1, 7, 3, 11, 1, 11, 3 }, 3, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 1, 2, 1, 4, 5, 2, 5, 4, 6, 2, 6, 4, 7, 2, 7, 4, 11, 2, 11, 4 }, 3, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "rugby_10":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 0, 3, 1, 1, 5, 3, 6, 1, 6, 3, 7, 1, 11, 3, 12, 1, 12, 3 }, 3, 3);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 2, 0, 4, 1, 1, 5, 3, 6, 2, 6, 4, 7, 1, 11, 3, 12, 2, 12, 4 }, 3, 3);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 1, 2, 2, 1, 2, 3, 5, 2, 6, 1, 6, 3, 7, 4, 10, 1, 10, 3, 11, 4 }, 3, 3);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 1, 2, 2, 2, 2, 4, 5, 2, 6, 2, 6, 4, 7, 4, 10, 2, 10, 4, 11, 4 }, 3, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
            case "y_10":
                switch (moldComboNum)
                {
                    case 1:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 11, 1, 11, 3, 12, 1, 12, 3, 15, 2, 16, 4, 20, 4 }, 3, 5);
                        break;
                    case 2:
                        ComboWholePanel(new List<int> { 0, 1, 5, 3, 6, 1, 11, 2, 11, 4, 12, 2, 12, 4, 15, 2, 16, 4, 20, 4 }, 3, 5);
                        break;
                    case 3:
                        ComboWholePanel(new List<int> { 2, 2, 6, 2, 7, 4, 10, 1, 10, 3, 11, 1, 11, 3, 16, 3, 17, 1, 22, 3 }, 3, 5);
                        break;
                    case 4:
                        ComboWholePanel(new List<int> { 2, 2, 6, 2, 7, 4, 10, 2, 10, 4, 11, 2, 11, 4, 16, 3, 17, 1, 22, 3 }, 3, 5);
                        break;
                    case 5:
                        ComboWholePanel(new List<int> { 2, 1, 2, 3, 6, 2, 7, 1, 7, 3, 8, 1, 10, 2, 11, 4, 13, 3, 14, 1 }, 5, 3);
                        break;
                    case 6:
                        ComboWholePanel(new List<int> { 2, 2, 2, 4, 6, 2, 7, 2, 7, 4, 8, 1, 10, 2, 11, 4, 13, 3, 14, 1 }, 5, 3);
                        break;
                    case 7:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 3, 2, 4, 4, 6, 3, 7, 1, 7, 3, 8, 4, 12, 1, 12, 3 }, 5, 3);
                        break;
                    case 8:
                        ComboWholePanel(new List<int> { 0, 3, 1, 1, 3, 2, 4, 4, 6, 3, 7, 2, 7, 4, 8, 4, 12, 2, 12, 4 }, 5, 3);
                        moldComboNum = 0;
                        waitingMoldList.RemoveRange(0, 1);
                        AddMagnification(mold);
                        break;
                }
                break;
        }

        // コンボ発生してたらコンボプレハブの削除待ちにする
        if (isCombo)
        {
            seManager.SoundComboSe();
            puzzleMain.comboState = "waitComboPartsDelete";
            isCombo = false;
        }

    }
}
