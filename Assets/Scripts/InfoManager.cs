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

    // ���p�l���ɕK�v�ȏ����Z�b�g����
    public void SetInfo()
    {
        // ���x���AHP�A�U���́A�񕜗͂̃Z�b�g
        playerLevelText.text = playerPrefsManager.GetPlayerLevel().ToString();
        playerHpText.text = playerStatusManager.userCurrentHp + "(" + playerStatusManager.GetPlayerHp() + ")";
        playerAttackText.text = playerStatusManager.userCurrentAttackPower + "(" + playerStatusManager.GetPlayerAttack() + ")";
        playerHealText.text = playerStatusManager.userCurrentHealPower + "(" + playerStatusManager.GetPlayerHeal() + ")";

        // �����̏��
        string[] moldInfo_1 = playerStatusManager.GetMoldInfo_1();
        string[] moldInfo_2 = playerStatusManager.GetMoldInfo_2();
        string[] skillInfo_1 = playerStatusManager.GetSkillInfo_1();
        string[] skillInfo_2 = playerStatusManager.GetSkillInfo_2();

        
        string moldSp_1 = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(moldInfo_1));
        string moldSp_2 = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(moldInfo_2));
        string skillSp_1 = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(skillInfo_1));
        string skillSp_2 = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(skillInfo_2));

        // ������ʂ̃Z�b�g
        string spEffect = "";
        int spCount = 0;
        if(moldSp_1 != "")
        {
            spCount++;
            spEffect += "�E" + moldSp_1 + "\r\n" ;
        }
        if (moldSp_2 != "")
        {
            spCount++;
            spEffect += "�E" + moldSp_2 + "\r\n";
        }
        if (skillSp_1 != "")
        {
            spCount++;
            spEffect += "�E" + skillSp_1 + "\r\n";
        }
        if (skillSp_2 != "")
        {
            spCount++;
            spEffect += "�E" + skillSp_2;
        }

        if(spCount == 0)
        {
            // ������ʂȂ�
            spEffect = "�[";
        }
        else if(spCount < 4)
        {
            for (var i = 0; i < 3 - spCount; i++)
            {
                spEffect += "\r\n";
            }
        }

        playerSpEffectText.text = spEffect;

        // ��ԁE�p�����[�^�ُ�̃Z�b�g
        string text = "";
        string name = "";
        for(var i = 0; i < playerStatusManager.abnormalList_1.Count;  i++)
        {
            // �c��1�^�[���̂���
            name = playerStatusManager.abnormalList_1[i];
            text += "�E" + playerStatusManager.GetAbnormalName(name) + "(1)" + "�u" + playerStatusManager.GetAbnormalDesc(name)+ "�v" + "\r\n";
        }

        for (var i = 0; i < playerStatusManager.abnormalList_2.Count; i++)
        {
            // �c��2�^�[���̂���
            name = playerStatusManager.abnormalList_2[i];
            text += "�E" + playerStatusManager.GetAbnormalName(name) + "(2)" + "�u" + playerStatusManager.GetAbnormalDesc(name) + "�v" + "\r\n";
        }

        for (var i = 0; i < playerStatusManager.abnormalList_3.Count; i++)
        {
            // �c��3�^�[���̂���
            name = playerStatusManager.abnormalList_3[i];
            text += "�E" + playerStatusManager.GetAbnormalName(name) + "(3)" + "�u" + playerStatusManager.GetAbnormalDesc(name) + "�v" + "\r\n";
        }

        if (text == "")
        {
            // �ُ킪�Ȃ��ꍇ
            abnormalText.text = "�[";
        }
        else
        {
            abnormalText.text = text.Remove(text.Length - 1);
        }
    }

    // ���p�l����\������
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

    // ���p�l�����\���ɂ���
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
