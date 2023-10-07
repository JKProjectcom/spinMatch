using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleMain : MonoBehaviour
{
    public PlayerPrefsManager playerPrefsManager;
    public EnemyManager enemyManager;
    public TutorialManager tutorialManager;

    public float StandardBlockLossyScale;
    public float StandardPrefabScale;

    // パズル全体の状態
    public string puzzleState;

    // コンボの状態
    public string comboState;

    // コンボに関する経過時間。攻撃ボタンが押されたときから測定開始。
    public float comboTime;
    // 攻撃と回復に関する経過時間
    public float attackEffectTime;
    // 敵からの攻撃に関する経過時間
    public float enemyAttackEffectTime;

    // スキル使用に関する経過時間。スキルボタンが押されたときから測定開始。
    public float skillTime;
    
    // 勝利後の勝利パネルを表示するまでに使用する時間
    public float winTime;

    // 5×5個分のブロック
    public GameObject[] PartsButtonList;

    // プレハブ
    public GameObject PrefabRed;
    public GameObject PrefabBlue;
    public GameObject PrefabGreen;
    public GameObject PrefabPink;
    public GameObject PrefabWhite;
    public GameObject PrefabComboRed;
    public GameObject PrefabComboBlue;
    public GameObject PrefabComboGreen;
    public GameObject PrefabComboPink;
    public GameObject PrefabComboWhite;

    public GameObject PrefabParalysis;
    public GameObject PrefabDarkness;

    // それぞれのパーツ（プレハブ）を保存しておくもの
    public List<Dictionary<string, GameObject>> partsList;

    // 1回の攻撃で消すべきパーツの位置情報
    public List<Dictionary<int, string>> comboPartsPosition;

    // コンボ数
    public int comboCount;

    // 攻撃パネルのバー
    public GameObject attackBar_1;
    public GameObject attackBar_2;

    // Start is called before the first frame update
    void Start()
    {
        // いろいろ初期化
        partsList = new List<Dictionary<string, GameObject>>();
        comboPartsPosition = new List<Dictionary<int, string>>();
        comboCount = 0;
        puzzleState = "puzzle";

        // 敵の初期化
        enemyManager.CreateEnemy();

        GetUserRatio();
        FirstCreateParts();

        string sceneName = SceneManager.GetActiveScene().name;

        if((sceneName == "VolcanoScene" || sceneName == "ShipScene" || sceneName == "ForestScene") && playerPrefsManager.GetFirstPuzzle() == "true")
        {
            // 最初のパズルであればチュートリアル
            tutorialManager.StartPuzzleTutorial();
        }
        
        if((sceneName == "BossScene") && playerPrefsManager.GetFirstBoss() == "true")
        {
            // 最初のボスパズルであればチュートリアル
            tutorialManager.StartBossPuzzleTutorial();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ゲーム開始時にパーツを生成する
    public void FirstCreateParts()
    {
        // ユーザの利用デバイスに合わせて生成するプレハブの大きさを計算する。
        float userRatio = GetUserRatio();
        float createPrefabScale = StandardPrefabScale * userRatio;

        // プレハブの大きさを変更する。
        ChangePrefabSize(createPrefabScale);

        // ブロック毎に処理
        foreach (GameObject button in PartsButtonList)
        {
            // ブロックの左上の座標を取得
            float x = button.transform.position.x;
            float y = button.transform.position.y;

            // ランダムにパーツ生成
            GameObject prefab_1 = GetRandomPrefab_4();
            GameObject part_1 = Instantiate(prefab_1, new Vector3(x, y, 0), Quaternion.identity);

            GameObject prefab_2 = GetRandomPrefab_4();
            GameObject part_2 = Instantiate(prefab_2, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 180));

            // 生成したパーツを保存する
            Dictionary<string, GameObject> block = new Dictionary<string, GameObject>();
            block["lr"] = part_1;
            block["ul"] = part_2;
            block["ll"] = null;
            block["ur"] = null;
            partsList.Add(block);
        }
    }

    // 4種類のパーツから1つをランダムで選ぶ。返すのはプレハブ。
    public GameObject GetRandomPrefab_4()
    {
        int x = Random.Range(1, 5);

        if(x == 1)
        {
            return PrefabRed;

        }else if(x == 2)
        {
            return PrefabBlue;
        }
        else if (x == 3)
        {
            return PrefabGreen;
        }
        else if (x == 4)
        {
            return PrefabPink;
        }

        return PrefabPink;
    }

    // 4種類のパーツから1つをランダムで選ぶ。返すのは色。
    public string GetRandomPart_4()
    {
        int x = Random.Range(1, 5);

        if (x == 1)
        {
            return "red(Clone)";

        }
        else if (x == 2)
        {
            return "blue(Clone)";
        }
        else if (x == 3)
        {
            return "green(Clone)";
        }
        else if (x == 4)
        {
            return "pink(Clone)";
        }

        return "pink(Clone)";
    }

    // 全てのパーツを削除する
    public void DeleteAllParts()
    {
        foreach (var block in partsList)
        {
            if (block["lr"])
            {
                Destroy(block["lr"]);
            }
            if (block["ul"])
            {
                Destroy(block["ul"]);
            }
            if (block["ll"])
            {
                Destroy(block["ll"]);
            }
            if (block["ur"])
            {
                Destroy(block["ur"]);
            }
        }
    }

    // 全てのパーツを表示にする
    public void ActivateAllParts()
    {
        foreach (var block in partsList)
        {
            if (block["lr"])
            {
                block["lr"].SetActive(true);
            }
            if (block["ul"])
            {
                block["ul"].SetActive(true);
            }
            if (block["ll"])
            {
                block["ll"].SetActive(true);
            }
            if (block["ur"])
            {
                block["ur"].SetActive(true);
            }
        }
    }

    // 全てのパーツを非表示にする
    public void InactivateAllParts()
    {
        foreach (var block in partsList)
        {
            if (block["lr"])
            {
                block["lr"].SetActive(false);
            }
            if (block["ul"])
            {
                block["ul"].SetActive(false);
            }
            if (block["ll"])
            {
                block["ll"].SetActive(false);
            }
            if (block["ur"])
            {
                block["ur"].SetActive(false);
            }
        }
    }

    // パーツの表示非表示を切り替える
    public void ChangePartsActive(List<int> blockNumList, bool TF)
    {
        int blockNum = 0;
        foreach (var block in partsList)
        {
            if (blockNumList.Contains(blockNum)){
                if (block["lr"])
                {
                    block["lr"].SetActive(TF);
                }
                if (block["ul"])
                {
                    block["ul"].SetActive(TF);
                }
                if (block["ll"])
                {
                    block["ll"].SetActive(TF);
                }
                if (block["ur"])
                {
                    block["ur"].SetActive(TF);
                }
            }
            
            blockNum++;
        }
    }

    // パーツを生成する
    public GameObject CreatePart(string color, int buttonNum, string direction)
    {
        // ブロックの左上の座標を取得
        float x = PartsButtonList[buttonNum].transform.position.x;
        float y = PartsButtonList[buttonNum].transform.position.y;

        GameObject prefab = GetColorPart(color);

        if(direction == "lr")
        {
            return Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
        }
        else if(direction == "ll")
        {
            return Instantiate(prefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 270));
        }
        else if (direction == "ul")
        {
            return Instantiate(prefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 180));
        }
        else if (direction == "ur")
        {
            return Instantiate(prefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 90));
        }

        return Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
    }

    // 麻痺エフェクトを生成する
    public GameObject CreatePartPara(int buttonNum)
    {
        // ブロックの左上の座標を取得
        float x = PartsButtonList[buttonNum].transform.position.x;
        float y = PartsButtonList[buttonNum].transform.position.y;

        return Instantiate(PrefabParalysis, new Vector3(x, y, 0), Quaternion.identity);
    }

    // 暗闇エフェクトを生成する
    public GameObject CreatePartDarkness(int buttonNum)
    {
        // ブロックの左上の座標を取得
        float x = PartsButtonList[buttonNum].transform.position.x;
        float y = PartsButtonList[buttonNum].transform.position.y;

        return Instantiate(PrefabDarkness, new Vector3(x, y, 0), Quaternion.identity);
    }

    // 引数ボタン番号に引数ブロックの情報（パーツ）を保存する
    public void SaveBlock(int buttonNum, Dictionary<string, GameObject> block)
    {
        partsList[buttonNum] = block;
    }

    // 引数ボタン番号にセットされているパーツを取得する
    public Dictionary<string, GameObject> GetBlock(int buttonNum)
    {
        return partsList[buttonNum];
    }

    // 引数ボタン番号のパーツの明るさを変更する
    public void ChangePartsBright(int buttonNum, bool isDarken)
    {
        var block = partsList[buttonNum];

        byte colorByte = 255;
        if (isDarken)
        {
            colorByte = 160;
        }

        if (block["lr"])
        {
            block["lr"].GetComponent<Renderer>().material.color = new Color32(colorByte, colorByte, colorByte, 255);
        }
        if (block["ul"])
        {
            block["ul"].GetComponent<Renderer>().material.color = new Color32(colorByte, colorByte, colorByte, 255);
        }
        if (block["ll"])
        {
            block["ll"].GetComponent<Renderer>().material.color = new Color32(colorByte, colorByte, colorByte, 255);
        }
        if (block["ur"])
        {
            block["ur"].GetComponent<Renderer>().material.color = new Color32(colorByte, colorByte, colorByte, 255);
        }
    }

    // クリアした引数ステージレベルからランダムにステータスの値を返す。戦利品のHP以外の抽選に使う。
    public int GetRandomBootyStatus()
    {
        // クリアしたステージのレベル
        int level = playerPrefsManager.GetPlayLevel();

        // 特殊な敵の場合高い値
        if (enemyManager.enemyType == "gold")
        {
            return Random.Range(9, 11) * level;
        }
        else if(enemyManager.enemyType == "silver")
        {
            return Random.Range(7, 11) * level;
        }

        // 範囲はレベル×1からレベル×10までの間
        return Random.Range(1, 11) * level;
    }

    // クリアした引数ステージレベルからランダムにステータスの値を返す。戦利品のHPの抽選に使う。
    public int GetRandomBootyHp()
    {
        // クリアしたステージのレベル
        int level = playerPrefsManager.GetPlayLevel();

        // 特殊な敵の場合高い値
        if (enemyManager.enemyType == "gold")
        {
            return Random.Range(900, 1000) * level;
        }
        else if (enemyManager.enemyType == "silver")
        {
            return Random.Range(700, 1000) * level;
        }

        // 範囲はレベル×100からレベル×1000までの間
        return Random.Range(100, 1001) * level;
    }

    // 装備品のステータスの強さが何割の位置にあるか返す
    public int GetParamAve(int hp, int attack, int heal)
    {
        // クリアしたステージのレベル
        int level = playerPrefsManager.GetPlayLevel();

        int attack_100 = attack * 100;
        int heal_100 = heal * 100;

        return (hp + attack_100 + heal_100) / (3 * 100 * level);
    }

    // 戦利品の宝箱のグレードを返す
    public string GetTreasureGrade(int hp, int attack, int heal, string spEffect)
    {
        if(spEffect == "empty")
        {
            // 特殊効果無しはノーマル
            return "normal";
        }

        int ave = GetParamAve(hp, attack, heal);
        if(ave >= 8)
        {
            // 8割以上はゴールド
            return "gold";
        }
        else if(ave >= 6)
        {
            // 6割以上はシルバー
            return "silver";
        }

        return "normal";
    }

    // ユーザの利用デバイスに合わせて何倍すれば丁度よくなるか計算する
    public float GetUserRatio()
    {       
        // 既に保存済みであればそれを計算に使って返す
        if (PlayerPrefs.HasKey("userRatio"))
        {
            return PlayerPrefs.GetFloat("userRatio") / StandardBlockLossyScale ;
        }

        // 未保存であれば計算して保存してから返す
        float userBlockScale = PartsButtonList[0].GetComponent<RectTransform>().lossyScale.x;
        PlayerPrefs.SetFloat("userRatio", userBlockScale);
        PlayerPrefs.Save();

        return (userBlockScale / StandardBlockLossyScale);
    }

    // パーツの色からパーツのプレハブを返す
    public GameObject GetColorPart(string color)
    {
        switch (color)
        {
            case "red(Clone)":
                return PrefabRed;
            case "blue(Clone)":
                return PrefabBlue;
            case "green(Clone)":
                return PrefabGreen;
            case "pink(Clone)":
                return PrefabPink;
            case "white(Clone)":
                return PrefabWhite;
            case "combo_red(Clone)":
                return PrefabComboRed;
            case "combo_blue(Clone)":
                return PrefabComboBlue;
            case "combo_green(Clone)":
                return PrefabComboGreen;
            case "combo_pink(Clone)":
                return PrefabComboPink;
            case "combo_white(Clone)":
                return PrefabComboWhite;
        }
        return PrefabRed;
    }

    // 引数色のコンボ用の色を返す
    public string GetComboColor(string color)
    {
        switch (color)
        {
            case "red(Clone)":
                return "combo_red(Clone)";
            case "blue(Clone)":
                return "combo_blue(Clone)";
            case "green(Clone)":
                return "combo_green(Clone)";
            case "pink(Clone)":
                return "combo_pink(Clone)";
            case "white(Clone)":
                return "combo_white(Clone)";
        }

        return "combo_red(Clone)";
    }

    // プレハブのサイズを変更する
    public void ChangePrefabSize(float createPrefabScale)
    {
        PrefabRed.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);
        PrefabBlue.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);
        PrefabGreen.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);
        PrefabPink.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);
        PrefabWhite.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);
        PrefabComboRed.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);
        PrefabComboBlue.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);
        PrefabComboGreen.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);
        PrefabComboPink.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);
        PrefabComboWhite.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);

        PrefabParalysis.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);
        PrefabDarkness.transform.localScale = new Vector3(createPrefabScale, createPrefabScale, 1);
    }
}
