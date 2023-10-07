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

    // �v���C���[�̃��x��
    public int GetPlayerLevel()
    {
        return PlayerPrefs.GetInt("playerLevel");
    }
    public void SetPlayerLevel(int level)
    {
        PlayerPrefs.SetInt("playerLevel", level);
    }

    // �ΎR�X�e�[�W�̓��B���x��
    public int GetClearedLevelVolcano()
    {
        return PlayerPrefs.GetInt("clearedLevelVolcano");
    }
    public void SetClearedLevelVolcano(int level)
    {
        PlayerPrefs.SetInt("clearedLevelVolcano", level);
    }
    // �D�X�e�[�W�̓��B���x��
    public int GetClearedLevelShip()
    {
        return PlayerPrefs.GetInt("clearedLevelShip");
    }
    public void SetClearedLevelShip(int level)
    {
        PlayerPrefs.SetInt("clearedLevelShip", level);
    }
    // �X�уX�e�[�W�̓��B���x��
    public int GetClearedLevelForest()
    {
        return PlayerPrefs.GetInt("clearedLevelForest");
    }
    public void SetClearedLevelForest(int level)
    {
        PlayerPrefs.SetInt("clearedLevelForest", level);
    }
    // �v���C����X�e�[�W�̃��x��
    public int GetPlayLevel()
    {
        return PlayerPrefs.GetInt("playLevel");
    }
    public void SetPlayLevel(int level)
    {
        PlayerPrefs.SetInt("playLevel", level);
    }
    // �v���C����X�e�[�W�̎��
    public string GetPlayStageType()
    {
        return PlayerPrefs.GetString("playStageType");
    }
    public void SetPlayStageType(string type)
    {
        PlayerPrefs.SetString("playStageType", type);
    }
    // �{�X�X�e�[�W�ŏo������G�̑���
    public string GetBossAttribute()
    {
        return PlayerPrefs.GetString("bossAttribute", "red");
    }
    public void SetBossAttribute(string attribute)
    {
        PlayerPrefs.SetString("bossAttribute", attribute);
    }
    // �{�X�ȊO�̃X�e�[�W�ŏo�Ă���G�C���[�W�̓Y����
    public int GetEnemySpriteIndex()
    {
        return PlayerPrefs.GetInt("enemySpriteIndex", 0);
    }
    public void SetEnemySpriteIndex(int index)
    {
        PlayerPrefs.SetInt("enemySpriteIndex", index);
    }
    // �{�X�X�e�[�W�ŏo�Ă���G�C���[�W�̓Y����
    public int GetBossSpriteIndex()
    {
        return PlayerPrefs.GetInt("bossSpriteIndex", 1);
    }
    public void SetBossSpriteIndex(int index)
    {
        PlayerPrefs.SetInt("bossSpriteIndex", index);
    }
    // �G�̔w�i�C���[�W�̓Y����
    public int GetEnemyBackIndex()
    {
        return PlayerPrefs.GetInt("enemyBackIndex", 0);
    }
    public void SetEnemyBackIndex(int index)
    {
        PlayerPrefs.SetInt("enemyBackIndex", index);
    }

    // �������Ă��郂�[���h1�̏��
    public string GetMold_1()
    {
        return PlayerPrefs.GetString("userMold_1");
    }
    public void SetMold_1(string moldInfo)
    {
        PlayerPrefs.SetString("userMold_1", moldInfo);
    }
    // �������Ă��郂�[���h2�̏��
    public string GetMold_2()
    {
        return PlayerPrefs.GetString("userMold_2");
    }
    public void SetMold_2(string moldInfo)
    {
        PlayerPrefs.SetString("userMold_2", moldInfo);
    }
    // �X�e�[�W�̃��[���h���
    public string GetStageMold()
    {
        return PlayerPrefs.GetString("stageMold");
    }
    public void SetStageMold(string moldInfo)
    {
        PlayerPrefs.SetString("stageMold", moldInfo);
    }
    // �������Ă���X�L��1�̏��
    public string GetSkill_1()
    {
        return PlayerPrefs.GetString("userSkill_1");
    }
    public void SetSkill_1(string skillInfo)
    {
        PlayerPrefs.SetString("userSkill_1", skillInfo);
    }
    // �������Ă���X�L��2�̏��
    public string GetSkill_2()
    {
        return PlayerPrefs.GetString("userSkill_2");
    }
    public void SetSkill_2(string skillInfo)
    {
        PlayerPrefs.SetString("userSkill_2", skillInfo);
    }

    // �L���ɂ���
    public string GetAdsTimeString()
    {
        return PlayerPrefs.GetString("adsTime");
    }
    public void SetAdsTimeString(string time)
    {
        PlayerPrefs.SetString("adsTime", time);
    }

    // ����ɂ���
    public string GetLanguage()
    {
        return PlayerPrefs.GetString("language", "en");
    }
    public void SetLanguage(string language)
    {
        PlayerPrefs.SetString("language", language);
    }

    // �v���C�o�V�[�|���V�[�m�F�������ǂ���
    public string GetConfirmPolicy()
    {
        return PlayerPrefs.GetString("isConfirmPolicy", "false");
    }
    public void SetConfirmPolicy(string TF)
    {
        PlayerPrefs.SetString("isConfirmPolicy", TF);
    }
    // �`���[�g���A���i�ŏ��̃g�b�v��ʁj
    public string GetFirstTop()
    {
        return PlayerPrefs.GetString("isFirstTop", "true");
    }
    public void SetFirstTop(string TF)
    {
        PlayerPrefs.SetString("isFirstTop", TF);
    }
    // �`���[�g���A���i�ŏ��̃z�[����ʁj
    public string GetFirstHome()
    {
        return PlayerPrefs.GetString("isFirstHome", "true");
    }
    public void SetFirstHome(string TF)
    {
        PlayerPrefs.SetString("isFirstHome", TF);
    }
    // �`���[�g���A���i�ŏ��̃p�Y����ʁj
    public string GetFirstPuzzle()
    {
        return PlayerPrefs.GetString("isFirstPuzzle", "true");
    }
    public void SetFirstPuzzle(string TF)
    {
        PlayerPrefs.SetString("isFirstPuzzle", TF);
    }
    // �`���[�g���A���i�ŏ��̏����j
    public string GetFirstWin()
    {
        return PlayerPrefs.GetString("isFirstWin", "true");
    }
    public void SetFirstWin(string TF)
    {
        PlayerPrefs.SetString("isFirstWin", TF);
    }
    // �`���[�g���A���i�ŏ��̃{�X�o���j
    public string GetFirstBossAppear()
    {
        return PlayerPrefs.GetString("isFirstBossAppear", "true");
    }
    public void SetFirstBossAppear(string TF)
    {
        PlayerPrefs.SetString("isFirstBossAppear", TF);
    }
    // �`���[�g���A���i�ŏ��̃{�X�p�Y���j
    public string GetFirstBoss()
    {
        return PlayerPrefs.GetString("isFirstBoss", "true");
    }
    public void SetFirstBoss(string TF)
    {
        PlayerPrefs.SetString("isFirstBoss", TF);
    }

    // BGM�̉���
    public float GetBgmVolume()
    {
        return PlayerPrefs.GetFloat("bgmVolume");
    }
    public void SetBgmVolume(float volume)
    {
        PlayerPrefs.SetFloat("bgmVolume", volume);
    }
    // SE�̉���
    public float GetSeVolume()
    {
        return PlayerPrefs.GetFloat("seVolume");
    }
    public void SetSeVolume(float volume)
    {
        PlayerPrefs.SetFloat("seVolume", volume);
    }
    // �C���X�g�[�����čŏ��̃v���C
    public string GetFirstPlay()
    {
        return PlayerPrefs.GetString("isFirstPlay", "true");
    }
    public void SetFirstPlay(string TF)
    {
        PlayerPrefs.SetString("isFirstPlay", TF);
    }
}
