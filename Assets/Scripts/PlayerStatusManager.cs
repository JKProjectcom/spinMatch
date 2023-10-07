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

    // ���[�U��HP�̃e�L�X�g
    public Text userHpText;

    // ���[�U��HP�o�[�̃X���C�_�[
    public Slider userHpSlider;
    // ���[�U��HP�o�[��fill
    public GameObject userHpfill;

    public int userCurrentHp;
    public int userCurrentAttackPower;
    public int userCurrentHealPower;
    public int userCurrentSkillTurn_1;
    public int userCurrentSkillTurn_2;

    // �����X�L���̏��B�z��
    public string[] userSkillInfoArray_1;
    public string[] userSkillInfoArray_2;

    // �������Ă���X�L���̖���
    public string userSkillName_1;
    public string userSkillName_2;

    // �X�L���{�^��
    public Button userSkill_1_button;
    public Button userSkill_2_button;

    // �X�L�������܂�܂ł̃^�[����\������e�L�X�g
    public Text skillTurnText_1;
    public Text skillTurnText_2;

    // ���[���h�̔{����\������e�L�X�g
    public Text userMoldMag_1;
    public Text userMoldMag_2;
    public Text stageMoldMag;

    // ��ԁE�p�����[�^�ُ��ۑ�������́i�c��1�^�[���̂��́j
    public List<string> abnormalList_1 = new List<string>();
    // ��ԁE�p�����[�^�ُ��ۑ�������́i�c��2�^�[���̂��́j
    public List<string> abnormalList_2 = new List<string>();
    // ��ԁE�p�����[�^�ُ��ۑ�������́i�c��3�^�[���̂��́j
    public List<string> abnormalList_3 = new List<string>();

    // �p�����[�^�ω��A��Ԉُ�̃A�C�R���\���̈�
    public Image changeImage;

    // ��Ԉُ�̃A�C�R���\���̈�
    public Image abnormalStatusImage;
    // �p�����[�^�ُ�̃A�C�R���\���̈�
    public Image abnormalParamImage;

    // �p�����[�^�ω��A��Ԉُ�̃A�C�R��
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

    // �p�����[�^�ُ�̈ꗗ
    public List<string> abnormalParamName = new List<string>() { "attackDown", "healDown", "attackUp_1.5", "healUp_1.5", "attackUp_1.2", "healUp_1.2" };
    // �����p�����[�^�ُ�̈ꗗ
    public List<string> abnormalBadParamName = new List<string>() { "attackDown", "healDown" };
    // ��Ԉُ�̈ꗗ
    public List<string> abnormalStatusName = new List<string>() { "poison", "paralysis", "burn", "sleep", "darkness", "confuse" };

    // �p�����[�^�ُ�̌��ݕ\�����̂���
    public string currentAbnormalParam;

    // �p�����[�^�ُ�̃A�C�R���ύX�Ǘ�����
    public float abnormalParamTime;

    // ��჏�ԂɂȂ��Ă���u���b�N
    public List<int> paralysisBlockList = new List<int>();

    // ��჏�ԂŐ��������G�t�F�N�g
    public List<GameObject> paralysisPrefabList = new List<GameObject>();

    // �Èŏ�ԂɂȂ��Ă���u���b�N
    public List<int> darknessBlockList = new List<int>();

    // �Èŏ�ԂŐ��������G�t�F�N�g
    public List<GameObject> darknessPrefabList = new List<GameObject>();

    public Image userMoldIImage_1;
    public Image userMoldIImage_2;
    public Image stageMoldIImage;

    // Start is called before the first frame update
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        // �p�Y����ʈȊO�͏I��
        if (sceneName != "VolcanoScene" && sceneName != "ShipScene" && sceneName != "ForestScene" && sceneName != "BossScene")
        {
            return;
        }

        InitializePlayerStatus();

        // ������
        userCurrentHp = userMaxHp;
        userHpSlider.value = 1;
        userCurrentAttackPower = userAttackPower;
        userCurrentHealPower = userHealPower;

        // HP�ݒ�
        ChangeHp();

        // �X�L���ݒ�
        SetSkill();

        // ���[���h�ݒ�
        SetMold();
    }

    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        // �p�Y����ʈȊO�͏I��
        if (sceneName != "VolcanoScene" && sceneName != "ShipScene" && sceneName != "ForestScene" && sceneName != "BossScene")
        {
            return;
        }

        // �p�����[�^�ُ�̕\���ؑ�
        abnormalParamTime += Time.deltaTime;
        if( abnormalParamTime > 1 )
        {
            ChangeAbnormalParamIcon();
            abnormalParamTime = 0;
        }
    }

    // �����ُ�̖��O����\������Ԃ�
    public string GetAbnormalName(string name)
    {
        switch (name)
        {
            case "poison":
                return textManager.GetLocalizeText("��");
            case "paralysis":
                return textManager.GetLocalizeText("���");
            case "burn":
                return textManager.GetLocalizeText("�Ώ�");
            case "sleep":
                return textManager.GetLocalizeText("����");
            case "darkness":
                return textManager.GetLocalizeText("�È�");
            case "confuse":
                return textManager.GetLocalizeText("����");
            case "attackDown":
                return textManager.GetLocalizeText("�U���̓_�E��");
            case "healDown":
                return textManager.GetLocalizeText("�񕜗̓_�E��");
            case "attackUp_1.5":
                return textManager.GetLocalizeText("�U���̓A�b�v");
            case "healUp_1.5":
                return textManager.GetLocalizeText("�񕜗̓A�b�v");
            case "attackUp_1.2":
                return textManager.GetLocalizeText("�U���̓A�b�v");
            case "healUp_1.2":
                return textManager.GetLocalizeText("�񕜗̓A�b�v");
        }
        return "";
    }

    // �����ُ�̖��O���������Ԃ�
    public string GetAbnormalDesc(string name)
    {
        switch (name)
        {
            case "poison":
                return textManager.GetLocalizeText("���^�[��HP��5%�̃_���[�W���󂯂�");
            case "paralysis":
                return textManager.GetLocalizeText("�����_���Ńp�l���̉�]�s��");
            case "burn":
                return textManager.GetLocalizeText("�󂯂�_���[�W��1.5�{ ������ʂ�����");
            case "sleep":
                return textManager.GetLocalizeText("�^����_���[�W��0�{ �󂯂�_���[�W��2�{");
            case "darkness":
                return textManager.GetLocalizeText("�����_���Ńp�l���������Ȃ��Ȃ�");
            case "confuse":
                return textManager.GetLocalizeText("�񕜃p�l���������ƃ_���[�W���󂯂�");
            case "attackDown":
                return textManager.GetLocalizeText("�U���͂�0.5�{");
            case "healDown":
                return textManager.GetLocalizeText("�񕜗͂�0.5�{");
            case "attackUp_1.5":
                return textManager.GetLocalizeText("�U���͂�1.5�{");
            case "healUp_1.5":
                return textManager.GetLocalizeText("�񕜗͂�1.5�{");
            case "attackUp_1.2":
                return textManager.GetLocalizeText("�U���͂�1.2�{");
            case "healUp_1.2":
                return textManager.GetLocalizeText("�񕜗͂�1.2�{");
        }

        return "";
    }

    // �p�����[�^�Ɋւ��ُ��K�p����
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

        // �����_�͐؂�グ
        userCurrentAttackPower = (int)Math.Ceiling(attack);
        userCurrentHealPower = (int)Math.Ceiling(heal);
    }

    // �ُ�����t���b�V������
    public void RefreshAbnormal()
    {
        List<string> all = GetAllAbnormal();
        bool isAbnormalStatus = false;

        // ��
        if (all.Contains("poison"))
        {
            abnormalStatusImage.sprite = poisonSprite;
            isAbnormalStatus = true;
        }

        // ���
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
            // ��჏��
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
            // ��Ⴢł͂Ȃ�
            paralysisBlockList.Clear();
        }

        // �Ώ�
        if (all.Contains("burn"))
        {
            abnormalStatusImage.sprite = burnSprite;
            isAbnormalStatus = true;
        }

        // ����
        if (all.Contains("sleep"))
        {
            abnormalStatusImage.sprite = sleepSprite;
            isAbnormalStatus = true;
        }

        // �È�
        foreach (var prefab in darknessPrefabList)
        {
            Destroy(prefab);
        }
        darknessPrefabList.Clear();

        if (all.Contains("darkness"))
        {
            // �Èŏ��
            foreach (var blockNum in darknessBlockList)
            {
                darknessPrefabList.Add(puzzleMain.CreatePartDarkness(blockNum));
            }

            abnormalStatusImage.sprite = darknessSprite;
            isAbnormalStatus = true;
        }
        else
        {
            // �Èłł͂Ȃ�
            darknessBlockList.Clear();
        }

        // ����
        if (all.Contains("confuse"))
        {
            abnormalStatusImage.sprite = confuseSprite;
            isAbnormalStatus = true;
        }

        // ��Ԉُ�̏ꍇ�A�C�R����\������
        if (isAbnormalStatus)
        {
            abnormalStatusImage.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            abnormalStatusImage.color = new Color32(255, 255, 255, 0);
        }

        // �p�����[�^�ُ�
        ApplyAbnormalParam();
    }

    // �ُ��S�Ď擾����
    public List<string> GetAllAbnormal()
    {
        List<string> list = new List<string>();

        list.AddRange(abnormalList_1);
        list.AddRange(abnormalList_2);
        list.AddRange(abnormalList_3);

        return list;
    }


    // �ُ��ǉ�����
    public void AddAbnormal(string abnormalName, int turn)
    {
        // ���ɓ������̂Ń^�[�����̑������̂�����Ώd�����邽�ߒǉ����Ȃ�
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

        // ���ɓ������̂Ń^�[�����̏��Ȃ����̂�����Ώ��Ȃ������폜����
        if (turn == 3)
        {
            abnormalList_1.Remove(abnormalName);
            abnormalList_2.Remove(abnormalName);
        }
        else if(turn == 2)
        {
            abnormalList_1.Remove(abnormalName);
        }

        // �ǉ�����
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

    // �p�����[�^�ُ���񕜂���
    public void HealAbnormalParam()
    {
        List<string> allAbnormal = GetAllAbnormal();
        if (!IsAbnormalBadParam(allAbnormal))
        {
            // �����p�����[�^�ُ�ɂȂ��Ă��Ȃ���ΏI��
            return;
        }

        foreach (var item in abnormalBadParamName)
        {
            RemoveAbnormal(item);
        }
    }

    // ��Ԉُ���񕜂���
    public void HealAbnormalStatus()
    {
        List<string> allAbnormal = GetAllAbnormal();
        if (!IsAbnormalStatus(allAbnormal))
        {
            // ��Ԉُ�ɂȂ��Ă��Ȃ���ΏI��
            return;
        }
        foreach (var item in abnormalStatusName)
        {
            RemoveAbnormal(item);
        }
    }

    // �����ُ���񕜂���
    public void RemoveAbnormal(string abnormalName)
    {
        // �c�^�[�����X�g����폜
        abnormalList_1.Remove(abnormalName);
        abnormalList_2.Remove(abnormalName);
        abnormalList_3.Remove(abnormalName);
    }

    // �ُ�̃^�[������i�߂�
    public void AdvanceAbnormal()
    {
        abnormalList_1.Clear();
        abnormalList_1.AddRange(abnormalList_2);
        abnormalList_2.Clear();
        abnormalList_2.AddRange(abnormalList_3);
        abnormalList_3.Clear();
    }

    // ��჏�Ԃ̃v���n�u��S�ĕ\������
    public void ActivatePara()
    {
        foreach (var item in paralysisPrefabList)
        {
            item.SetActive(true);
        }
    }

    // ��჏�Ԃ̃v���n�u��S�Ĕ�\���ɂ���
    public void InactivatePara()
    {
        foreach (var item in paralysisPrefabList)
        {
            item.SetActive(false);
        }
    }

    // �Èŏ�Ԃ̃v���n�u��S�ĕ\������
    public void ActivateDarkness()
    {
        foreach (var item in darknessPrefabList)
        {
            item.SetActive(true);
        }
    }

    // �Èŏ�Ԃ̃v���n�u��S�Ĕ�\���ɂ���
    public void InactivateDarkness()
    {
        foreach (var item in darknessPrefabList)
        {
            item.SetActive(false);
        }
    }

    // �p�����[�^�ُ�̃A�C�R����ω�������
    public void ChangeAbnormalParamIcon()
    {
        List<string> allAbnormal = GetAllAbnormal();

        if (!IsAbnormalParam(allAbnormal)) {
            // �p�����[�^�ُ�ɂȂ��Ă��Ȃ���ΏI��
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

    // �p�����[�^�ُ�ɂȂ��Ă��邩�ǂ���
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

    // �����p�����[�^�ُ�ɂȂ��Ă��邩�ǂ���
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

    // ��Ԉُ�ɂȂ��Ă��邩�ǂ���
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

    // �ُ�̖��O����Sprite��Ԃ�
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


    // �p�Y���J�n���̃v���C���[�X�e�[�^�X�̏�����
    public void InitializePlayerStatus()
    {
        userMaxHp = GetPlayerHp();
        userAttackPower = GetPlayerAttack();
        userHealPower = GetPlayerHeal();
    }

    // �������Ă���X�L��1�̏���Ԃ�
    public string[] GetSkillInfo_1()
    {
        string userSkill_1 = playerPrefsManager.GetSkill_1();
        return GetEquipmentInfo(userSkill_1);
    }

    // �������Ă���X�L��2�̏���Ԃ�
    public string[] GetSkillInfo_2()
    {
        string userSkill_2 = playerPrefsManager.GetSkill_2();
        return GetEquipmentInfo(userSkill_2);
    }

    // �������Ă��郂�[���h1�̏���Ԃ�
    public string[] GetMoldInfo_1()
    {
        string mold_1 = playerPrefsManager.GetMold_1();
        return GetEquipmentInfo(mold_1);
    }

    // �������Ă��郂�[���h2�̏���Ԃ�
    public string[] GetMoldInfo_2()
    {
        string mold_2 = playerPrefsManager.GetMold_2();
        return GetEquipmentInfo(mold_2);
    }

    // �v���C���[�̑����i���݂�HP��Ԃ�
    public int GetPlayerHp()
    {
        int moldHp_1 = int.Parse(GetEquipmentHp(GetMoldInfo_1()));
        int moldHp_2 = int.Parse(GetEquipmentHp(GetMoldInfo_2()));

        int skillHp_1 = int.Parse(GetEquipmentHp(GetSkillInfo_1()));
        int skillHp_2 = int.Parse(GetEquipmentHp(GetSkillInfo_2()));

        int hp = moldHp_1 + moldHp_2 + skillHp_1 + skillHp_2;

        return hp;
    }

    // �v���C���[�̑����i���݂̍U���͂�Ԃ�
    public int GetPlayerAttack()
    {
        int moldAttack_1 = int.Parse(GetEquipmentPower(GetMoldInfo_1()));
        int moldAttack_2 = int.Parse(GetEquipmentPower(GetMoldInfo_2()));

        int skillAttack_1 = int.Parse(GetEquipmentPower(GetSkillInfo_1()));
        int skillAttack_2 = int.Parse(GetEquipmentPower(GetSkillInfo_2()));

        int attack = moldAttack_1 + moldAttack_2 + skillAttack_1 + skillAttack_2;

        return attack;
    }

    // �v���C���[�̑����i���݂̉񕜗͂�Ԃ�
    public int GetPlayerHeal()
    {
        int moldHeal_1 = int.Parse(GetEquipmentHeal(GetMoldInfo_1()));
        int moldHeal_2 = int.Parse(GetEquipmentHeal(GetMoldInfo_2()));

        int skillHeal_1 = int.Parse(GetEquipmentHeal(GetSkillInfo_1()));
        int skillHeal_2 = int.Parse(GetEquipmentHeal(GetSkillInfo_2()));

        int heal = moldHeal_1 + moldHeal_2 + skillHeal_1 + skillHeal_2;

        return heal;
    }

    // ���[�U��HP�̕ύX�𔽉f����
    public void ChangeHp()
    {
        // HP�̃e�L�X�g�ɔ��f
        userHpText.text = "HP "+ userCurrentHp + " / " + userMaxHp;

        // HP�o�[�ɔ��f
        userHpSlider.value = (float)userCurrentHp / (float)userMaxHp;
        attackManager.ChangeHpColor(userHpSlider, userHpfill);
    }

    // �U���͂�������
    public void PowerDown()
    {
        userCurrentAttackPower -= userAttackPower / 2;
    }

    // �񕜗͂�������
    public void HealDown()
    {
        userCurrentHealPower -= userHealPower / 2;
    }

    // �ł̃_���[�W���󂯂�
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

    // �X�L���^�[����i�߂�
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

    // �X�L���^�[���������ɖ߂�
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

    // �X�L���{�^���ɃX�L���̃C���X�g���Z�b�g����B�����^�[�����Z�b�g����
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
            // ������ʂŃX�L���^�[�������܂�����ԂŊJ�n����
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

    // ���[���h�ɑ����ƃX�e�[�W�̃��[���h���Z�b�g����
    public void SetMold()
    {
        // �������Ă��郂�[���h���Z�b�g����
        string userMold_1 = playerPrefsManager.GetMold_1();
        string userMold_2 = playerPrefsManager.GetMold_2();

        string[] userMoldInfo_1 = GetEquipmentInfo(userMold_1);
        string[] userMoldInfo_2 = GetEquipmentInfo(userMold_2);

        string userMoldName_1 = GetEquipmentName(userMoldInfo_1);
        string userMoldName_2 = GetEquipmentName(userMoldInfo_2);

        userMoldIImage_1.sprite = moldManager.GetMoldSprite(userMoldName_1);
        userMoldIImage_2.sprite = moldManager.GetMoldSprite(userMoldName_2);
        userMoldMag_1.text = "�~ " + moldManager.GetMoldMagnification(userMoldName_1).ToString();
        userMoldMag_2.text = "�~ " + moldManager.GetMoldMagnification(userMoldName_2).ToString();

        // �X�e�[�W�̃��[���h���Z�b�g����
        string stageMold = moldManager.GetRandomStageMoldName(userMoldName_1, userMoldName_2);
        playerPrefsManager.SetStageMold(stageMold);
        stageMoldIImage.sprite = moldManager.GetMoldSprite(stageMold);
        stageMoldMag.text = "�~ " + moldManager.GetMoldMagnification(stageMold).ToString();
    }


    // ���[���h�A�X�L���̏��i������j��z��ɂ��ĕԂ�
    public string[] GetEquipmentInfo(string equipment)
    {
        return equipment.Split(',');
        // ["���O","HP�㏸�l","�U���͏㏸�l","�񕜗͏㏸�l","�ǉ�����","�����^�[����"]
        // ��j["skillHealHp","100","150","300","powerUp","4"] �ǉ����ʂ��������"empty"�����Ă����B�����^�[�����̓X�L���̂�
    }

    // ���[���h�A�X�L���̖��̂�Ԃ�
    public string GetEquipmentName(string[] equipmentArray)
    {
        return equipmentArray[0];
    }

    // ���[���h�A�X�L����HP��Ԃ�
    public string GetEquipmentHp(string[] equipmentArray)
    {
        return equipmentArray[1];
    }

    // ���[���h�A�X�L���̍U���͂�Ԃ�
    public string GetEquipmentPower(string[] equipmentArray)
    {
        return equipmentArray[2];
    }

    // ���[���h�A�X�L���̉񕜗͂�Ԃ�
    public string GetEquipmentHeal(string[] equipmentArray)
    {
        return equipmentArray[3];
    }

    // ���[���h�A�X�L���̒ǉ����ʂ�Ԃ�
    public string GetEquipmentSpEffect(string[] equipmentArray)
    {
        return equipmentArray[4];
    }

    // �X�L���̔����^�[������Ԃ�
    public string GetSkillTurn(string[] equipmentArray)
    {
        return equipmentArray[5];
    }
}
