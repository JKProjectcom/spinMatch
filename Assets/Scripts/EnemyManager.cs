using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public PlayerPrefsManager playerPrefsManager;
    public PlayerStatusManager playerStatusManager;
    public AttackManager attackManager;
    public PuzzleMain puzzleMain;
    public SpEffectManager spEffectManager;

    // 敵のイメージ（画面上部）
    public Image enemyImage;
    // 敵のイメージ（敗北パネル）
    public Image loseEnemyImage;
    // 勝利後に敵を透過させるのに使う時間
    public float eraseTime;

    // 敵のタイプ（金、銀、通常）
    public string enemyType;

    // 敵の背景
    public Image enemyBackImage;

    // 敵の最大HP
    public int enemyMaxHp;
    // 敵の現在のHP
    public int enemyCurrentHp;
    // 敵のHPバーのスライダー
    public Slider enemyHpSlider;
    // 敵のHPバーのfill
    public GameObject enemyHpfill;
    // 敵の攻撃力
    public int enemyAttackPower;
    // 敵の属性
    public string enemyAttribute;

    // 敵の特殊攻撃の種類
    public string enemySpAttackType;
    // 敵の特殊攻撃ターン
    public int enemySpAttackTurn;
    // 敵の特殊攻撃ターン数表示イメージ
    public Image enemySpAttackImage;
    // 敵の特殊攻撃ターン数表示テキスト
    public Text enemySpAttackText;

    // Start is called before the first frame update
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 敵の初期化
    public void CreateEnemy()
    {
        // 属性
        string stageType = playerPrefsManager.GetPlayStageType();
        if(stageType == "volcano")
        {
            enemyAttribute = "red";
        }
        else if(stageType == "ship")
        {
            enemyAttribute= "blue";
        }
        else if(stageType == "forest")
        {
            enemyAttribute = "green";
        }
        else
        {
            // ボス
            enemyAttribute = playerPrefsManager.GetBossAttribute();
        }

        // レベル
        int stageLevel = playerPrefsManager.GetPlayLevel();

        // 敵のステータス
        SetRandomEnemyHp();
        SetRandomEnemyAttack();

        // 敵HPの初期化
        enemyCurrentHp = enemyMaxHp;
        enemyHpSlider.value = 1;

        // 特殊な敵か抽選
        RandomSpEnemy();

        // ボスの場合特殊攻撃をセット
        if (stageType == "boss")
        {
            enemySpAttackImage.enabled = true;

            // ステージレベルに応じて最初のターン数をセットする
            if (stageLevel >= 70)
            {
                RandomEnemySpAttack(1);
            }
            else if (stageLevel >= 60)
            {
                RandomEnemySpAttack(2);
            }
            else if (stageLevel >= 50)
            {
                RandomEnemySpAttack(3);
            }
            else if (stageLevel >= 40)
            {
                RandomEnemySpAttack(4);
            }
            else if (stageLevel >= 30)
            {
                RandomEnemySpAttack(5);
            }
            else if (stageLevel >= 20)
            {
                RandomEnemySpAttack(6);
            }
            else if (stageLevel >= 10)
            {
                RandomEnemySpAttack(7);
            }
            else
            {
                // ステージレベル1～9
                RandomEnemySpAttack(8);
            }
            SetEnemySpAttackTurn();
        }

        // 敵のイメージをセット
        SetEnemyPanelImage(stageType);

        // 敵の背景のセット
        SetEnemyBack(stageType);        
    }

    // 敵のHPを抽選する
    public void SetRandomEnemyHp()
    {
        string stageType = playerPrefsManager.GetPlayStageType();
        int stageLevel = playerPrefsManager.GetPlayLevel();
        switch (stageLevel)
        {
            case <= 9:
                if (stageType == "boss")
                {
                    enemyMaxHp = stageLevel * 1000;
                }
                else
                {
                    enemyMaxHp = stageLevel * 1000;
                }
                break;
            case <= 19:
                if (stageType == "boss")
                {
                    enemyMaxHp = stageLevel * 1500;
                }
                else
                {
                    enemyMaxHp = stageLevel * 1000;
                }
                break;
            case <= 29:
                if (stageType == "boss")
                {
                    enemyMaxHp = stageLevel * 2000;
                }
                else
                {
                    enemyMaxHp = stageLevel * 1500;
                }
                break;
            case <= 39:
                if (stageType == "boss")
                {
                    enemyMaxHp = stageLevel * 2500;
                }
                else
                {
                    enemyMaxHp = stageLevel * 1500;
                }
                break;
            case <= 49:
                if (stageType == "boss")
                {
                    enemyMaxHp = stageLevel * 3000;
                }
                else
                {
                    enemyMaxHp = stageLevel * 1500;
                }
                break;
            case <= 59:
                if (stageType == "boss")
                {
                    enemyMaxHp = stageLevel * 3500;
                }
                else
                {
                    enemyMaxHp = stageLevel * 1500;
                }
                break;
            case <= 69:
                if (stageType == "boss")
                {
                    enemyMaxHp = stageLevel * 4000;
                }
                else
                {
                    enemyMaxHp = stageLevel * 1500;
                }
                break;
            case <= 79:
                if (stageType == "boss")
                {
                    enemyMaxHp = stageLevel * 4500;
                }
                else
                {
                    enemyMaxHp = stageLevel * 1500;
                }
                break;
            case <= 89:
                if (stageType == "boss")
                {
                    enemyMaxHp = stageLevel * 5000;
                }
                else
                {
                    enemyMaxHp = stageLevel * 1500;
                }
                break;
            case <= 99:
                if (stageType == "boss")
                {
                    enemyMaxHp = stageLevel * 5500;
                }
                else
                {
                    enemyMaxHp = stageLevel * 1500;
                }
                break;
            default:
                if (stageType == "boss")
                {
                    enemyMaxHp = stageLevel * 6000;
                }
                else
                {
                    enemyMaxHp = stageLevel * 2000;
                }
                break;
        }
        Debug.Log("敵HP:"+enemyMaxHp);

        float randomNum = UnityEngine.Random.Range(0.9f, 1.1f);
        enemyMaxHp = (int)(enemyMaxHp * randomNum);
    }

    // 敵の攻撃力を抽選する
    public void SetRandomEnemyAttack()
    {
        string stageType = playerPrefsManager.GetPlayStageType();
        int stageLevel = playerPrefsManager.GetPlayLevel();

        if (stageLevel <= 9)
        {
            // レベル9まではちょっと弱め
            if (stageType == "boss")
            {
                // ボス
                enemyAttackPower = stageLevel * 100;
            }
            else
            {
                // 通常
                enemyAttackPower = stageLevel * 100;
            }
        }
        else
        {
            if (stageType == "boss")
            {
                // ボス
                enemyAttackPower = stageLevel * 250;
            }
            else
            {
                // 通常
                enemyAttackPower = stageLevel * 200;
            }
        }

        float randomNum = UnityEngine.Random.Range(0.9f, 1.1f);
        enemyAttackPower = (int)(enemyAttackPower*randomNum);
    }

    // 特殊な敵かどうか抽選する
    public void RandomSpEnemy()
    {
        int num = UnityEngine.Random.Range(1, 101);
        if(num >= 99)
        {
            enemyType = "gold";
        }
        else if(num >= 96)
        {
            enemyType = "silver";
        }
        else
        {
            enemyType = "normal";
        }
    }

    // ボスの属性とイメージと背景をランダムに抽選して保存する
    public void SaveRandomBoss()
    {
        // 属性
        int randomNum = UnityEngine.Random.Range(0, 3);
        if (randomNum == 0)
        {
            playerPrefsManager.SetBossAttribute("red");
        }
        else if (randomNum == 1)
        {
            playerPrefsManager.SetBossAttribute("blue");
        }
        else
        {
            playerPrefsManager.SetBossAttribute("green");
        }

        // イメージ
        int randomImageNum = UnityEngine.Random.Range(0, 102);
        playerPrefsManager.SetBossSpriteIndex(randomImageNum);

        // 背景
        playerPrefsManager.SetEnemyBackIndex(UnityEngine.Random.Range(0, 5));
    }

    // 通常の敵のイメージをランダムに抽選して保存する
    public void SaveRandomEnemy()
    {
        // イメージ
        int randomImageNum = UnityEngine.Random.Range(0, 102);
        playerPrefsManager.SetEnemySpriteIndex(randomImageNum);
    }

    // 敵の画像をステージの敵パネルに表示する
    public void SetEnemyPanelImage(string stageType)
    {
        string path = "images/enemy/";

        // 特殊な敵
        if (enemyType == "gold")
        {
            // ゴールド
            path += "sp/gold";
            enemyImage.sprite = Resources.Load<Sprite>(path);
            return;
        }
        else if(enemyType == "silver")
        {
            // シルバー
            path += "sp/silver";
            enemyImage.sprite = Resources.Load<Sprite>(path);
            return;
        }

        int enemyIndex = playerPrefsManager.GetEnemySpriteIndex();
        int bossIndex = playerPrefsManager.GetBossSpriteIndex();
        switch (stageType)
        {
            case "volcano":
                path += "red/" + enemyIndex;
                break;
            case "ship":
                path += "blue/" + enemyIndex;
                break;
            case "forest":
                path += "green/" + enemyIndex;
                break;
            case "boss":

                switch (playerPrefsManager.GetBossAttribute())
                {
                    case "red":
                        path += "red/" + bossIndex;
                        break;
                    case "blue":
                        path += "blue/" + bossIndex;
                        break;
                    case "green":
                        path += "green/" + bossIndex;
                        break;
                }
                break;
        }

        enemyImage.sprite = Resources.Load<Sprite>(path);
    }

    // 敵の背景をセットする
    public void SetEnemyBack(string stageType)
    {
        string path = "images/back/" + stageType + "/" + playerPrefsManager.GetEnemyBackIndex();        
        enemyBackImage.sprite = Resources.Load<Sprite>(path);
    }

    // 特殊攻撃のターン数を表示する
    public void SetEnemySpAttackTurn()
    {
        if (playerPrefsManager.GetPlayStageType() != "boss")
        {
            return;
        }

        enemySpAttackText.text = enemySpAttackTurn.ToString();
    }

    // 特殊攻撃のターンを進める
    public void AdvanceEnemySpAttack()
    {
        if(playerPrefsManager.GetPlayStageType() != "boss")
        {
            return;
        }

        enemySpAttackTurn--;

        SetEnemySpAttackTurn();
    }

    // 特殊攻撃をする
    public void SpAttack()
    {
        if (playerPrefsManager.GetPlayStageType() != "boss")
        {
            return;
        }

        if(enemySpAttackTurn != 0)
        {
            return;
        }

        switch (enemySpAttackType)
        {
            case "poison":
                if (spEffectManager.IsGotAbnormalStatus())
                {
                    playerStatusManager.AddAbnormal("poison", 3);
                }
                break;
            case "paralysis":
                if (spEffectManager.IsGotAbnormalStatus())
                {
                    playerStatusManager.AddAbnormal("paralysis", 2);
                    ParalysisAttack();
                }
                break;
            case "burn":
                if (spEffectManager.IsGotAbnormalStatus())
                {
                    playerStatusManager.AddAbnormal("burn", 3);
                }
                break;
            case "sleep":
                if (spEffectManager.IsGotAbnormalStatus())
                {
                    playerStatusManager.AddAbnormal("sleep", 1);
                }
                break;
            case "darkness":
                if (spEffectManager.IsGotAbnormalStatus())
                {
                    playerStatusManager.AddAbnormal("darkness", 2);
                    DarknessAttack();
                }
                break;
            case "confuse":
                if (spEffectManager.IsGotAbnormalStatus())
                {
                    playerStatusManager.AddAbnormal("confuse", 2);
                }
                break;
            case "attackDown":
                if (spEffectManager.IsGotAbnormalParam())
                {
                    playerStatusManager.AddAbnormal("attackDown", 3);
                }
                break;
            case "healDown":
                if (spEffectManager.IsGotAbnormalParam())
                {
                    playerStatusManager.AddAbnormal("healDown", 3);
                }
                break;
            case "heal":
                HealEnemy();
                ChangeEnemyHp();
                break;
            case "triple":
                attackManager.EnemyAttack();
                attackManager.EnemyAttack();
                break;
        }

        // 攻撃後は次に備えて抽選
        RandomEnemySpAttack(0);
        SetEnemySpAttackTurn();
    }

    // 特殊攻撃の抽選
    public void RandomEnemySpAttack(int turn)
    {
        if (playerPrefsManager.GetPlayStageType() != "boss")
        {
            return;
        }

        // ターン数
        if(turn == 1)
        {
            enemySpAttackTurn = 1;
        }
        else
        {
            int turnNum = UnityEngine.Random.Range(1, 101);
            if (turnNum <= 10)
            {
                enemySpAttackTurn = 6;
            }
            else if (turnNum <= 80)
            {
                enemySpAttackTurn = 7;
            }
            else if (turnNum <= 100)
            {
                enemySpAttackTurn = 8;
            }
        }
        

        // 種類
        int typeNum = UnityEngine.Random.Range(1, 101);
        if (typeNum <= 10)
        {
            enemySpAttackType = "poison";
        }
        else if (typeNum <= 20)
        {
            enemySpAttackType = "paralysis";
        }
        else if (typeNum <= 30)
        {
            enemySpAttackType = "burn";
        }
        else if (typeNum <= 40)
        {
            enemySpAttackType = "sleep";
        }
        else if (typeNum <= 50)
        {
            enemySpAttackType = "darkness";
        }
        else if (typeNum <= 60)
        {
            enemySpAttackType = "confuse";
        }
        else if (typeNum <= 70)
        {
            enemySpAttackType = "attackDown";
        }
        else if (typeNum <= 80)
        {
            enemySpAttackType = "healDown";
        }
        else if (typeNum <= 90)
        {
            enemySpAttackType = "heal";
        }
        else if (typeNum <= 100)
        {
            enemySpAttackType = "triple";
        }
    }

    // 敵の麻痺攻撃
    public void ParalysisAttack()
    {
        // 回転不可にするものを抽選
        List<int> blockList = new List<int>();
        for (int i = 0; i < 25; i++)
        {
            blockList.Add(i);
        }

        List<int> targetList = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            // 10個回転不可にする
            int randomIndex = UnityEngine.Random.Range(0, blockList.Count);
            int randomNum = blockList[randomIndex];
            blockList.Remove(randomNum);
            targetList.Add(randomNum);
        }

        playerStatusManager.paralysisBlockList = targetList;
    }

    // 敵の暗闇攻撃
    public void DarknessAttack()
    {
        // 暗闇にするものを抽選
        List<int> blockList = new List<int>();
        for (int i = 0; i < 25; i++)
        {
            blockList.Add(i);
        }

        List<int> targetList = new List<int>();
        for (int i = 0; i < 8; i++)
        {
            // 8個暗闇にする
            int randomIndex = UnityEngine.Random.Range(0, blockList.Count);
            int randomNum = blockList[randomIndex];
            blockList.Remove(randomNum);
            targetList.Add(randomNum);
        }

        playerStatusManager.darknessBlockList = targetList;
    }

    // 敵のHPの変更を反映する
    public void ChangeEnemyHp()
    {
        // HPバーに反映
        enemyHpSlider.value = (float)enemyCurrentHp / (float)enemyMaxHp;
        attackManager.ChangeHpColor(enemyHpSlider, enemyHpfill);
    }

    // 敵のHPを回復する
    public void HealEnemy()
    {
        int healHp = (int)(enemyMaxHp * 0.3f);

        enemyCurrentHp += healHp;

        if(enemyMaxHp < enemyCurrentHp)
        {
            enemyCurrentHp = enemyMaxHp;
        }
    }
}
