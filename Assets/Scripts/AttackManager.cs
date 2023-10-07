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

    // �X�L���{�^���������ꂽ�Ƃ����̃{�^���̖��O��ۑ�����
    public string useSkillButtonName;

    // �R���{���蒆�Ɏg�����[���h�̃p�^�[��
    public string comboMold;
    public int comboEndNum;
    public int comboDiff;
    public List<int> comboBlockList;
    public List<string> comboDirectionList;

    // ���v����p�^�[�������݂������ǂ���TRUE:�L��
    public bool isCombo;

    // �R���{�J�E���g
    public int moldComboNum;

    // �R���{���ɂ܂����肵�Ă��Ȃ����[���h
    public List<string> waitingMoldList;

    // �R���{�ŏ����ׂ��S�Ẵp�[�c�B�U���̍Ō�ɐV�����p�[�c�𐶐�����̂Ɏg���B
    public List<string> allComboParts;

    // �R���{�ŏ����ׂ��΂̃p�[�c�B���[���h���ɕۑ����čU���͉񕜗͌v�Z�Ɏg�p����B
    public List<string> redComboList;
    // �R���{�ŏ����ׂ����̃p�[�c�B���[���h���ɕۑ����čU���͉񕜗͌v�Z�Ɏg�p����B
    public List<string> blueComboList;
    // �R���{�ŏ����ׂ��؂̃p�[�c�B���[���h���ɕۑ����čU���͉񕜗͌v�Z�Ɏg�p����B
    public List<string> greenComboList;
    // �R���{�ŏ����ׂ��񕜂̃p�[�c�B���[���h���ɕۑ����čU���͉񕜗͌v�Z�Ɏg�p����B
    public List<string> pinkComboList;

    // �΍U���{��
    public float redAttackMagnification;
    // ���U���{��
    public float blueAttackMagnification;
    // �؍U���{��
    public float greenAttackMagnification;
    // �񕜔{��
    public float healMagnification;

    // �e�{����\���������
    public Text redMagText;
    public Text blueMagText;
    public Text greenMagText;
    public Text pinkMagText;

    // �G�ւ̃_���[�W
    public int enemyDamage;

    // �G�ւ̍U��SE��炵�����ǂ���
    public bool isSoundAttackSe;

    // �G����̍U��SE��炵�����ǂ���
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
            // �U���{�^������������Ă���R���{����������܂�

            // �U�����͎��Ԍv��
            puzzleMain.comboTime += Time.deltaTime;

            if(puzzleMain.comboState == "waitComboCheck")
            {
                // �p�[�c�`�F�b�N��҂��Ă�����
                CheckMoldPattern();

                puzzleMain.comboTime = 0;
            }
            else if (puzzleMain.comboState == "waitComboPartsDelete")
            {
                // �R���{�p�[�c�폜��҂��Ă�����

                if (puzzleMain.comboTime > 0.4f)
                {
                    // �����܂�����R���{�p�[�c�폜
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
                // �R���{���������G�ɍU�����Ď������񕜂���G�t�F�N�g�𔭐�
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
                // �R���{���������G�ɍU������
                UserAttack();

                // �񕜂���
                Heal();

                // ������
                spEffectManager.AutoHeal();

                // �ł̃_���[�W
                playerStatusManager.DamagePoison();

                CheckHp();

                puzzleMain.comboState = "waitEnemyAttackEffect";
            }
            else if(puzzleMain.comboState == "waitEnemyAttackEffect")
            {
                // �G����̍U���̃G�t�F�N�g����
                float bottomY = -20;
                float topY = -20;
                float leftX = 0;
                float rightX = 0;

                if(enemyManager.enemySpAttackTurn == 1)
                {
                    // ����U���̏ꍇ�͏c�ɃW�����v
                    topY = 0;
                }
                else
                {
                    // �ʏ�U���̏ꍇ�͉���
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
                // �G����U�������
                EnemyAttack();

                // �p�[�c�������ĐV�����p�[�c�𐶐�����B
                CreatePartsAfterAttack();

                allComboParts.Clear();

                puzzleMain.puzzleState = "puzzle";
                puzzleMain.comboState = "";

                // �G�ւ̃_���[�W�����Z�b�g
                enemyDamage = 0;

                // �{����߂�
                ResetMagnification();

                // �X�L���^�[����i�߂�
                playerStatusManager.AdvanceSkillTurn();

                // �����ُ̈�̃^�[����i�߂�
                playerStatusManager.AdvanceAbnormal();

                // �G�̓���U���^�[����i�߂�
                enemyManager.AdvanceEnemySpAttack();

                // ����U���^�[����0�ɂȂ�����G�̓���U��������
                enemyManager.SpAttack();

                // �ُ���p�����[�^�ɔ��f����
                playerStatusManager.ApplyAbnormalParam();

                // �ُ�����t���b�V��
                playerStatusManager.RefreshAbnormal();

                CheckHp();

                InteractableAttackMenu();
            }
            

        }else if(puzzleMain.puzzleState == "useSkill")
        {
            // �X�L���g�p���i�X�L���{�^������������Ă���X�L�����ʂ�������������܂Łj

            // �X�L���g�p���͎��Ԍv��
            puzzleMain.skillTime += Time.deltaTime;

            if(puzzleMain.skillTime <= 0.5f)
            {
                // �{�^����������1�b�܂ł̓G�t�F�N�g

            }
            else
            {
                // �P�b�o��������ۂɃX�L���̌��ʎg�p
                UseSkill();

                puzzleMain.puzzleState = "puzzle";
                puzzleMain.skillTime = 0;
            }

            // �ُ���p�����[�^�ɔ��f����
            playerStatusManager.ApplyAbnormalParam();

            CheckHp();

            InteractableAttackMenu();
        }
        else if(puzzleMain.puzzleState == "win")
        {
            // ���������Ƃ�
            if (!puzzleSceneManager.restrictPanel.activeSelf)
            {
                // ����𐧌�
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
                // ���쐧��������
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
            // �p�Y�����ȊO�����s��
            return;
        }

        // �������Ă��郂�[���h���R���{�҂��ɂ���
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

        // �{�^���͉����s�ɂ��Ă���
        attackButton.interactable = false;
        infoManager.infoButton.interactable = false;
    }

    // ���ۂɓG���U������
    public void UserAttack()
    {
        enemyManager.enemyCurrentHp -= enemyDamage;
        enemyManager.ChangeEnemyHp();

        isSoundAttackSe = false;
    }

    // �G�ւ̍U��SE��炷
    public void SoundAttack()
    {
        // �����̃_���[�W���v�Z
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
            // ������Ԃ̏ꍇ�U���̓[��
            redDamage = 0;
            blueDamage = 0;
            greenDamage = 0;
        }

        int damage = (int)(redDamage + blueDamage + greenDamage);

        // ������ʂ�K�p�����_���[�W
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

    // �X�L���{�^��������
    public void Skill()
    {
        if (puzzleMain.puzzleState != "puzzle")
        {
            // �p�Y�����ȊO�����s��
            return;
        }

        puzzleMain.puzzleState = "useSkill";

        // �����ꂽ�{�^���̖��O
        GameObject skillButton = eventSystem.currentSelectedGameObject;
        useSkillButtonName = skillButton.name;

    }

    // ���ۂɃX�L�����g�p����
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

        // �X�L���^�[����0�ł͂Ȃ��ꍇ�����s��
        if(skillTurn != 0)
        {
            return;
        }

        // �X�L���ɉ����Č��ʂ�K�p����
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

        // �ُ�̃��t���b�V��
        playerStatusManager.RefreshAbnormal();

        playerStatusManager.ResetSkillTurn(useSkillButtonName);
    }

    // �G�Ǝ�����HP���m�F���ď��������𔻒肷��
    public void CheckHp()
    {
        if (playerStatusManager.userCurrentHp <= 0)
        {
            // �������|���ꂽ�Ƃ�

            if(playerStatusManager.userCurrentHp < 0)
            {
                playerStatusManager.userCurrentHp = 0;
            }

            if (spEffectManager.IsLost())
            {
                // ������ʂ�K�p���Ă��|���ꂽ
                bgmManager.SoundLoseBgm();
                puzzleSceneManager.losePanel.SetActive(true);
                puzzleMain.DeleteAllParts();
                playerStatusManager.InactivatePara();
                playerStatusManager.InactivateDarkness();
                puzzleMain.attackBar_1.SetActive(false);
                puzzleMain.attackBar_2.SetActive(false);
                puzzleMain.comboState = "";
                puzzleMain.puzzleState = "puzzle";

                // �X�e�[�W�̃��[���h�͍폜����
                playerPrefsManager.SetStageMold("");

                return;
            }
            else
            {
                // ������ʂŐ����c��
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

    // �������ď����p�l����\������Ƃ��̏���
    public void Win()
    {
        bgmManager.SoundWinBgm();
        puzzleSceneManager.winPanel.SetActive(true);
        clearPanelManager.LotteryBooty();

        // �X�e�[�W�̌�����
        puzzleMain.DeleteAllParts();
        playerStatusManager.InactivatePara();
        playerStatusManager.InactivateDarkness();
        puzzleMain.attackBar_1.SetActive(false);
        puzzleMain.attackBar_2.SetActive(false);

        // �X�e�[�W�̃��[���h�͍폜����
        playerPrefsManager.SetStageMold("");

        // �N���A���x���̍X�V
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

        // ���̓G�̐ݒ��ۑ�
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
            // ���߂ď��������ꍇ�`���[�g���A��
            tutorialManager.StartWinTutorial();
        }
    }

    // �{�^���������\�ɂ���
    public void InteractableAttackMenu()
    {
        attackButton.interactable = true;
        infoManager.infoButton.interactable = true;
    }

    // �p�[�c�̐F��ύX����
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

    // ���[�U��HP���񕜂���
    public void Heal()
    {
        int healPoint = (int)(playerStatusManager.userCurrentHealPower * healMagnification);

        int applyHealPoint = spEffectManager.GetApplySpEffectHeal(healPoint);

        if (playerStatusManager.GetAllAbnormal().Contains("confuse"))
        {
            // ������Ԃ̏ꍇ�_���[�W���󂯂�
            playerStatusManager.userCurrentHp -= applyHealPoint;
            if (playerStatusManager.userCurrentHp < 0)
            {
                // HP���}�C�i�X�ɂȂ�Ȃ��悤��
                playerStatusManager.userCurrentHp = 0;
            }
        }
        else
        {
            playerStatusManager.userCurrentHp += applyHealPoint;
            if (playerStatusManager.userCurrentHp > playerStatusManager.userMaxHp)
            {
                // �ő�HP�������ĉ񕜂����ꍇ�͍ő�HP�ɂ���
                playerStatusManager.userCurrentHp = playerStatusManager.userMaxHp;
            }
        }        

        playerStatusManager.ChangeHp();
    }

    // �G����U�������
    public void EnemyAttack()
    {
        seManager.SoundEnemyAttackSe();

        enemyManager.SetRandomEnemyAttack();

        // ������ʂ�K�p
        int damage = spEffectManager.GetApplySpEffectEnemyDamage((int)enemyManager.enemyAttackPower);

        if (playerStatusManager.GetAllAbnormal().Contains("sleep"))
        {
            // ������Ԃ̏ꍇ2�{
            playerStatusManager.userCurrentHp -= damage*2;
        }
        else if (playerStatusManager.GetAllAbnormal().Contains("burn"))
        {
            // �Ώ���Ԃ̏ꍇ1.5�{
            playerStatusManager.userCurrentHp -= (int)(damage*1.5);
        }
        else
        {
            playerStatusManager.userCurrentHp -= damage;
        }

        if (playerStatusManager.userCurrentHp < 0)
        {
            // HP���}�C�i�X�ɂȂ�Ȃ��悤��
            playerStatusManager.userCurrentHp = 0;
        }

        playerStatusManager.ChangeHp();

        isSoundEnemyAttackSe = false;
    }

    // HP�̊����ɂ���ăo�[�̐F��ς���
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

    // �������[���h�������F�݂̂ō\������Ă���΃R���{������B���̊֐��ł͏c1��܂��͉�1�s���m�F����B
    public void ComboSameColor(int endNum, List<int> blockList, List<string> directionList)
    {
        // �z��ɕϊ�
        int[] blockArray = blockList.ToArray();
        string[] directionArray = directionList.ToArray();

        for (int i = 0; i < endNum; i ++)
        {
            // �����F���`�F�b�N����
            string color = GetSameColor(i, blockArray, directionArray);
            if (color != "")
            {
                // �����F�������ꍇ�R���{�����̏���������
                isCombo = true;

                // �p�[�c���R���{�p�p�[�c�ɕς���
                comboParts.AddRange(ChangeComboPart(color, i, blockArray, directionArray));
            }
        }
    }

    // ���[���h���S�ē����F���`�F�b�N����B�����F�̏ꍇ���̐F�i�v���n�u���j��Ԃ�
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
                // �p�[�c�������iNULL�j�̏ꍇ�͏I��
                return "";
            }

            // �p�[�c�̐F�i�I�u�W�F�N�g�̖��O�j��Fred(Clone)
            string partColor = part.name;

            if (i == 0)
            {
                // �ŏ��̃p�[�c�̏ꍇ�͂Ƃ肠�����ۑ�����
                sameColorList.Add(blockNum.ToString() + direction);

                if (partColor == "white(Clone)")
                {
                    // ���̏ꍇ�͕ۑ����Ȃ�
                    continue;
                }

                // �x�[�X�J���[�Ƃ��ĕۑ�����
                baseColor = partColor;
            }
            else
            {
                // 2�ڈȍ~�̃p�[�c�̏ꍇ�͓����F���`�F�b�N����
                if (partColor == "white(Clone)")
                {
                    // ���̏ꍇ�̓`�F�b�N���Ȃ�
                    sameColorList.Add(blockNum.ToString() + direction);
                    continue;
                }

                if (baseColor == "" || baseColor == partColor)
                {
                    // �x�[�X�F�����܂��͐F�������ꍇ��r�����𑱂���
                    sameColorList.Add(blockNum.ToString() + direction);
                    baseColor = partColor;
                }
                else
                {
                    // �F���قȂ�ꍇ�I��
                    return "";
                }
            }
        }

        // �S�ă`�F�b�N������������S�ē����F�Ƃ���B
        // �����ׂ��p�[�c��ۑ�����B
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

        // �e�U���͌v�Z�Ɏg�����ߕۑ�����B
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

    // �R���{�ŏ����p�[�c�̏�ɃR���{�p�v���n�u�𐶐�����B���������v���n�u�̓��X�g�ɂ���ĕԂ��B
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

    // �{���ɒǉ�����
    public void AddMagnification(string mold)
    {
        // ���[���h�̔{�����擾����
        float magnification = moldManager.GetMoldMagnification(mold);

        // �e�F���ɔ{����ǉ�����
        redAttackMagnification += magnification * redComboList.Count;
        blueAttackMagnification += magnification * blueComboList.Count;
        greenAttackMagnification += magnification * greenComboList.Count;
        healMagnification += magnification * pinkComboList.Count;

        SetDisplayMag();

        // �ǉ��������ɂ���
        redComboList.Clear();
        blueComboList.Clear();
        greenComboList.Clear();
        pinkComboList.Clear();
    }

    // �{�������Z�b�g����
    public void ResetMagnification()
    {
        redAttackMagnification = 0;
        blueAttackMagnification = 0;
        greenAttackMagnification = 0;
        healMagnification = 0;

        SetDisplayMag();
    }

    // ��ʂɔ{����\������
    public void SetDisplayMag()
    {
        Math.Round(0.11, 1);
        redMagText.text = Math.Round(redAttackMagnification, 1).ToString();
        blueMagText.text = Math.Round(blueAttackMagnification, 1).ToString();
        greenMagText.text = Math.Round(greenAttackMagnification, 1).ToString();
        pinkMagText.text = Math.Round(healMagnification, 1).ToString();
    }

    // �U����V�����p�[�c�𐶐�����
    public void CreatePartsAfterAttack()
    {
        // ���ɏ����p�[�c���ɉ����Ĕ��𐶐����邩�ǂ������߂�B
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

            // �R���{�����p�[�c���폜����
            Destroy(puzzleMain.partsList[blockNum][direction]);

            string color = "";
            if(whiteNum == roopCount)
            {
                // ���𐶐�����B
                color = "white(Clone)";
            }
            else
            {
                // �����_���Ńp�[�c��I��Ő�������
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

        // �u���b�N�ƌ������擾
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

        // ���ɂ��炵�Ċm�F
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

    // ���[���h���ɃR���{�`�F�b�N�p�^�[���̒�`������
    public void CheckMoldPattern()
    {
        if(waitingMoldList.Count == 0)
        {
            // �S�Ẵ��[���h�̊m�F���I�������G�ւ̍U���G�t�F�N�g�Ɉڂ�B

            if(redAttackMagnification == 0 && blueAttackMagnification == 0 && greenAttackMagnification == 0)
            {
                // �R���{���������Ă��Ȃ��i�U���̕K�v�Ȃ��j�ꍇ�̓G�t�F�N�g�����B
                puzzleMain.comboState = "waitComboAttack";
                return;
            }

            puzzleMain.comboState = "waitAttackEffect";
            return;            
        }

        // �R���{�J�E���g�A�b�v
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

        // �R���{�������Ă���R���{�v���n�u�̍폜�҂��ɂ���
        if (isCombo)
        {
            seManager.SoundComboSe();
            puzzleMain.comboState = "waitComboPartsDelete";
            isCombo = false;
        }

    }
}
