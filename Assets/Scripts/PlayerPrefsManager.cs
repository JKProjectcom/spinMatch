using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
    }    

    // プレイヤーのレベル
    public int GetPlayerLevel()
    {
        return PlayerPrefs.GetInt("playerLevel");
    }
    public void SetPlayerLevel(int level)
    {
        PlayerPrefs.SetInt("playerLevel", level);
    }

    // 火山ステージの到達レベル
    public int GetClearedLevelVolcano()
    {
        return PlayerPrefs.GetInt("clearedLevelVolcano");
    }
    public void SetClearedLevelVolcano(int level)
    {
        PlayerPrefs.SetInt("clearedLevelVolcano", level);
    }
    // 船ステージの到達レベル
    public int GetClearedLevelShip()
    {
        return PlayerPrefs.GetInt("clearedLevelShip");
    }
    public void SetClearedLevelShip(int level)
    {
        PlayerPrefs.SetInt("clearedLevelShip", level);
    }
    // 森林ステージの到達レベル
    public int GetClearedLevelForest()
    {
        return PlayerPrefs.GetInt("clearedLevelForest");
    }
    public void SetClearedLevelForest(int level)
    {
        PlayerPrefs.SetInt("clearedLevelForest", level);
    }
    // プレイするステージのレベル
    public int GetPlayLevel()
    {
        return PlayerPrefs.GetInt("playLevel");
    }
    public void SetPlayLevel(int level)
    {
        PlayerPrefs.SetInt("playLevel", level);
    }
    // プレイするステージの種類
    public string GetPlayStageType()
    {
        return PlayerPrefs.GetString("playStageType");
    }
    public void SetPlayStageType(string type)
    {
        PlayerPrefs.SetString("playStageType", type);
    }
    // ボスステージで出現する敵の属性
    public string GetBossAttribute()
    {
        return PlayerPrefs.GetString("bossAttribute", "red");
    }
    public void SetBossAttribute(string attribute)
    {
        PlayerPrefs.SetString("bossAttribute", attribute);
    }
    // ボス以外のステージで出てくる敵イメージの添え字
    public int GetEnemySpriteIndex()
    {
        return PlayerPrefs.GetInt("enemySpriteIndex", 0);
    }
    public void SetEnemySpriteIndex(int index)
    {
        PlayerPrefs.SetInt("enemySpriteIndex", index);
    }
    // ボスステージで出てくる敵イメージの添え字
    public int GetBossSpriteIndex()
    {
        return PlayerPrefs.GetInt("bossSpriteIndex", 1);
    }
    public void SetBossSpriteIndex(int index)
    {
        PlayerPrefs.SetInt("bossSpriteIndex", index);
    }
    // 敵の背景イメージの添え字
    public int GetEnemyBackIndex()
    {
        return PlayerPrefs.GetInt("enemyBackIndex", 0);
    }
    public void SetEnemyBackIndex(int index)
    {
        PlayerPrefs.SetInt("enemyBackIndex", index);
    }

    // 装備しているモールド1の情報
    public string GetMold_1()
    {
        return PlayerPrefs.GetString("userMold_1");
    }
    public void SetMold_1(string moldInfo)
    {
        PlayerPrefs.SetString("userMold_1", moldInfo);
    }
    // 装備しているモールド2の情報
    public string GetMold_2()
    {
        return PlayerPrefs.GetString("userMold_2");
    }
    public void SetMold_2(string moldInfo)
    {
        PlayerPrefs.SetString("userMold_2", moldInfo);
    }
    // ステージのモールド情報
    public string GetStageMold()
    {
        return PlayerPrefs.GetString("stageMold");
    }
    public void SetStageMold(string moldInfo)
    {
        PlayerPrefs.SetString("stageMold", moldInfo);
    }
    // 装備しているスキル1の情報
    public string GetSkill_1()
    {
        return PlayerPrefs.GetString("userSkill_1");
    }
    public void SetSkill_1(string skillInfo)
    {
        PlayerPrefs.SetString("userSkill_1", skillInfo);
    }
    // 装備しているスキル2の情報
    public string GetSkill_2()
    {
        return PlayerPrefs.GetString("userSkill_2");
    }
    public void SetSkill_2(string skillInfo)
    {
        PlayerPrefs.SetString("userSkill_2", skillInfo);
    }

    // 広告について
    public string GetAdsTimeString()
    {
        return PlayerPrefs.GetString("adsTime");
    }
    public void SetAdsTimeString(string time)
    {
        PlayerPrefs.SetString("adsTime", time);
    }

    // 言語について
    public string GetLanguage()
    {
        return PlayerPrefs.GetString("language", "en");
    }
    public void SetLanguage(string language)
    {
        PlayerPrefs.SetString("language", language);
    }

    // プライバシーポリシー確認したかどうか
    public string GetConfirmPolicy()
    {
        return PlayerPrefs.GetString("isConfirmPolicy", "false");
    }
    public void SetConfirmPolicy(string TF)
    {
        PlayerPrefs.SetString("isConfirmPolicy", TF);
    }
    // チュートリアル（最初のトップ画面）
    public string GetFirstTop()
    {
        return PlayerPrefs.GetString("isFirstTop", "true");
    }
    public void SetFirstTop(string TF)
    {
        PlayerPrefs.SetString("isFirstTop", TF);
    }
    // チュートリアル（最初のホーム画面）
    public string GetFirstHome()
    {
        return PlayerPrefs.GetString("isFirstHome", "true");
    }
    public void SetFirstHome(string TF)
    {
        PlayerPrefs.SetString("isFirstHome", TF);
    }
    // チュートリアル（最初のパズル画面）
    public string GetFirstPuzzle()
    {
        return PlayerPrefs.GetString("isFirstPuzzle", "true");
    }
    public void SetFirstPuzzle(string TF)
    {
        PlayerPrefs.SetString("isFirstPuzzle", TF);
    }
    // チュートリアル（最初の勝利）
    public string GetFirstWin()
    {
        return PlayerPrefs.GetString("isFirstWin", "true");
    }
    public void SetFirstWin(string TF)
    {
        PlayerPrefs.SetString("isFirstWin", TF);
    }
    // チュートリアル（最初のボス出現）
    public string GetFirstBossAppear()
    {
        return PlayerPrefs.GetString("isFirstBossAppear", "true");
    }
    public void SetFirstBossAppear(string TF)
    {
        PlayerPrefs.SetString("isFirstBossAppear", TF);
    }
    // チュートリアル（最初のボスパズル）
    public string GetFirstBoss()
    {
        return PlayerPrefs.GetString("isFirstBoss", "true");
    }
    public void SetFirstBoss(string TF)
    {
        PlayerPrefs.SetString("isFirstBoss", TF);
    }

    // BGMの音量
    public float GetBgmVolume()
    {
        return PlayerPrefs.GetFloat("bgmVolume");
    }
    public void SetBgmVolume(float volume)
    {
        PlayerPrefs.SetFloat("bgmVolume", volume);
    }
    // SEの音量
    public float GetSeVolume()
    {
        return PlayerPrefs.GetFloat("seVolume");
    }
    public void SetSeVolume(float volume)
    {
        PlayerPrefs.SetFloat("seVolume", volume);
    }
    // インストールして最初のプレイ
    public string GetFirstPlay()
    {
        return PlayerPrefs.GetString("isFirstPlay", "true");
    }
    public void SetFirstPlay(string TF)
    {
        PlayerPrefs.SetString("isFirstPlay", TF);
    }
}
