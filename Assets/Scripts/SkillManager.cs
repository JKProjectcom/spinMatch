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

    // �X�L��������X�L���̐�������Ԃ�
    public string GetSkillDesc(string skillName)
    {
        switch (skillName)
        {
            case "skillRedBlue":
                return textManager.GetLocalizeText("�����_���ŉ΂𐅂ɕϊ�����");
            case "skillRedGreen":
                return textManager.GetLocalizeText("�����_���ŉ΂�؂ɕϊ�����");
            case "skillRedPink":
                return textManager.GetLocalizeText("�����_���ŉ΂��񕜂ɕϊ�����");
            case "skillBlueRed":
                return textManager.GetLocalizeText("�����_���Ő����΂ɕϊ�����");
            case "skillBlueGreen":
                return textManager.GetLocalizeText("�����_���Ő���؂ɕϊ�����");
            case "skillBluePink":
                return textManager.GetLocalizeText("�����_���Ő����񕜂ɕϊ�����");
            case "skillGreenRed":
                return textManager.GetLocalizeText("�����_���Ŗ؂��΂ɕϊ�����");
            case "skillGreenBlue":
                return textManager.GetLocalizeText("�����_���Ŗ؂𐅂ɕϊ�����");
            case "skillGreenPink":
                return textManager.GetLocalizeText("�����_���Ŗ؂��񕜂ɕϊ�����");
            case "skillPinkRed":
                return textManager.GetLocalizeText("�����_���ŉ񕜂��΂ɕϊ�����");
            case "skillPinkBlue":
                return textManager.GetLocalizeText("�����_���ŉ񕜂𐅂ɕϊ�����");
            case "skillPinkGreen":
                return textManager.GetLocalizeText("�����_���ŉ񕜂�؂ɕϊ�����");
            case "skillPowerUp_1.2":
                return textManager.GetLocalizeText("�U���͂�1.2�{�ɂ���");
            case "skillPowerUp_1.5":
                return textManager.GetLocalizeText("�U���͂�1.5�{�ɂ���");
            case "skillHealUp_1.2":
                return textManager.GetLocalizeText("�񕜗͂�1.2�{�ɂ���");
            case "skillHealUp_1.5":
                return textManager.GetLocalizeText("�񕜗͂�1.5�{�ɂ���");
            case "skillHealHp_30":
                return textManager.GetLocalizeText("HP��30%�񕜂���");
            case "skillHealHp_50":
                return textManager.GetLocalizeText("HP��50%�񕜂���");
            case "skillHealDebuff":
                return textManager.GetLocalizeText("�p�����[�^�ُ������");
            case "skillHealBadStatus":
                return textManager.GetLocalizeText("��Ԉُ������");
        }
        return "��Ԉُ���񕜂���";
    }

    // �X�L��������X�L���̃C���X�g��Ԃ�
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

    // �����_���ɃX�L����I��ŕԂ�
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

    // �X�L���ł�HP�񕜂�����
    public void SkillHealHp(int ratio)
    {
        // �񕜗�
        int healPoint = (int)(playerStatusManager.userMaxHp * ratio / 100);

        playerStatusManager.userCurrentHp += (int)healPoint;
        if (playerStatusManager.userCurrentHp > playerStatusManager.userMaxHp)
        {
            // �ő�HP�������ĉ񕜂����ꍇ�͍ő�HP�ɂ���
            playerStatusManager.userCurrentHp = playerStatusManager.userMaxHp;
        }

        playerStatusManager.ChangeHp();
    }
}
