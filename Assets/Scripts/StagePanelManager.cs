using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StagePanelManager : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public SeManager seManager;
    public PlayerPrefsManager playerPrefsManager;
    public FadeManager fadeManager;

    public Image castleImage;
    public GameObject castleButton;

    public GameObject VolcanoPanel;
    public GameObject ShipPanel;
    public GameObject ForestPanel;
    public GameObject CastlePanel;

    public Text clearedLevelVolcanoText;
    public Text clearedLevelShipText;
    public Text clearedLevelForestText;
    public Text clearedLevelBossText;
    public Text choiceLevelVolcanoText;
    public Text choiceLevelShipText;
    public Text choiceLevelForestText;
    public Text choiceLevelBossText;

    public Button addLevelVolcano_1;
    public Button addLevelVolcano_10;
    public Button subtractLevelVolcano_1;
    public Button subtractLevelVolcano_10;
    public Button addLevelShipText_1;
    public Button addLevelShipText_10;
    public Button subtractLevelShip_1;
    public Button subtractLevelShip_10;
    public Button addLevelForestText_1;
    public Button addLevelForestText_10;
    public Button subtractLevelForest_1;
    public Button subtractLevelForest_10;
    public Button addLevelBossText_1;
    public Button addLevelBossText_10;
    public Button subtractLevelBoss_1;
    public Button subtractLevelBoss_10;


    // Start is called before the first frame update
    void Start()
    {
        InactivateStagePanel();
        castleImage.enabled = false;

        SetVolcanoPanel();
        SetShipPanel();
        SetForestPanel();
        SetBossPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �X�e�[�W�p�l����S�Ĕ�\���ɂ���
    public void InactivateStagePanel()
    {
        VolcanoPanel.SetActive(false);
        ShipPanel.SetActive(false);
        ForestPanel.SetActive(false);
        CastlePanel.SetActive(false);
    }

    // �ΎR�{�^��������
    public void ClickVolcano()
    {
        if (VolcanoPanel.activeSelf)
        {
            return;
        }

        seManager.SoundChoiceSe();

        InactivateStagePanel();
        
        VolcanoPanel.SetActive(true);
    }
    // �D�{�^��������
    public void ClickShip()
    {
        if (ShipPanel.activeSelf)
        {
            return;
        }

        seManager.SoundChoiceSe();

        InactivateStagePanel();

        ShipPanel.SetActive(true);
    }
    // �X�{�^��������
    public void ClickForest()
    {
        if (ForestPanel.activeSelf)
        {
            return;
        }

        seManager.SoundChoiceSe();

        InactivateStagePanel();

        ForestPanel.SetActive(true);
    }
    // ��{�^��������
    public void ClickCastle()
    {
        if (CastlePanel.activeSelf)
        {
            return;
        }

        seManager.SoundChoiceSe();

        InactivateStagePanel();

        CastlePanel.SetActive(true);
    }
    // �ΎR���x��+1�{�^��������
    public void ClickAddVolcanoLevel_1()
    {
        AddStageLevel("volcano", 1);
    }
    // �ΎR���x��+10�{�^��������
    public void ClickAddVolcanoLevel_10()
    {
        AddStageLevel("volcano", 10);
    }
    // �ΎR���x��-1�{�^��������
    public void ClickSubtractVolcanoLevel_1()
    {
        SubtractStageLevel("volcano", 1);
    }
    // �ΎR���x��-10�{�^��������
    public void ClickSubtractVolcanoLevel_10()
    {
        SubtractStageLevel("volcano", 10);
    }
    // �C���x��+1�{�^��������
    public void ClickAddShipLevel_1()
    {
        AddStageLevel("ship", 1);
    }
    // �C���x��+10�{�^��������
    public void ClickAddShipLevel_10()
    {
        AddStageLevel("ship", 10);
    }
    // �C���x��-1�{�^��������
    public void ClickSubtractShipLevel_1()
    {
        SubtractStageLevel("ship", 1);
    }
    // �C���x��-10�{�^��������
    public void ClickSubtractShipLevel_10()
    {
        SubtractStageLevel("ship", 10);
    }
    // �X���x��+1�{�^��������
    public void ClickAddForestLevel_1()
    {
        AddStageLevel("forest", 1);
    }
    // �X���x��+10�{�^��������
    public void ClickAddForestLevel_10()
    {
        AddStageLevel("forest", 10);
    }
    // �X���x��-1�{�^��������
    public void ClickSubtractForestLevel_1()
    {
        SubtractStageLevel("forest", 1);
    }
    // �X���x��-10�{�^��������
    public void ClickSubtractForestLevel_10()
    {
        SubtractStageLevel("forest", 10);
    }
    // �{�X���x��+1�{�^��������
    public void ClickAddBossLevel_1()
    {
        AddStageLevel("boss", 1);
    }
    // �{�X���x��+10�{�^��������
    public void ClickAddBossLevel_10()
    {
        AddStageLevel("boss", 10);
    }
    // �{�X���x��-1�{�^��������
    public void ClickSubtractBossLevel_1()
    {
        SubtractStageLevel("boss", 1);
    }
    // �{�X���x��-10�{�^��������
    public void ClickSubtractBossLevel_10()
    {
        SubtractStageLevel("boss", 10);
    }
    // �ΎR�X�e�[�W�̃v���C�{�^��������
    public void ClickPlayVolcano()
    {
        seManager.SoundWalkSe();

        // �v���C����X�e�[�W�̎�ނƃ��x����ۑ�
        playerPrefsManager.SetPlayStageType("volcano");
        int playLevel = int.Parse(choiceLevelVolcanoText.text);
        playerPrefsManager.SetPlayLevel(playLevel);

        fadeManager.StartFade("VolcanoScene");
    }
    // �D�X�e�[�W�̃v���C�{�^��������
    public void ClickPlayShip()
    {
        seManager.SoundWalkSe();

        // �v���C����X�e�[�W�̎�ނƃ��x����ۑ�
        playerPrefsManager.SetPlayStageType("ship");
        int playLevel = int.Parse(choiceLevelShipText.text);
        playerPrefsManager.SetPlayLevel(playLevel);

        fadeManager.StartFade("ShipScene");
    }
    // �X�уX�e�[�W�̃v���C�{�^��������
    public void ClickPlayForest()
    {
        seManager.SoundWalkSe();

        // �v���C����X�e�[�W�̎�ނƃ��x����ۑ�
        playerPrefsManager.SetPlayStageType("forest");
        int playLevel = int.Parse(choiceLevelForestText.text);
        playerPrefsManager.SetPlayLevel(playLevel);

        fadeManager.StartFade("ForestScene");
    }
    // �{�X�X�e�[�W�̃v���C�{�^��������
    public void ClickPlayBoss()
    {
        seManager.SoundOpenDoorSe();

        // �v���C����X�e�[�W�̎�ނƃ��x����ۑ�
        playerPrefsManager.SetPlayStageType("boss");
        int playLevel = int.Parse(choiceLevelBossText.text);
        playerPrefsManager.SetPlayLevel(playLevel);

        fadeManager.StartFade("BossScene");
    }

    // �X�e�[�W�̒��탌�x�����グ��
    public void AddStageLevel(string stageType, int addLevel)
    {
        int setLevel = 0;
        switch (stageType)
        {
            case "forest":
                int forestLevel = int.Parse(choiceLevelForestText.text);
                if((forestLevel + addLevel) > playerPrefsManager.GetPlayerLevel())
                {
                    // ���Z�������ʃv���C���[���x���i����\������x���j�𒴂����ꍇ�̓v���C���[���x���Ƃ���
                    setLevel = playerPrefsManager.GetPlayerLevel();
                }
                else
                {
                    // �����Ă��Ȃ���΂��̂܂ܕ\������
                    setLevel = forestLevel + addLevel;
                }
                choiceLevelForestText.text = setLevel.ToString();
                break;
            case "ship":
                int shipLevel = int.Parse(choiceLevelShipText.text);
                if ((shipLevel + addLevel) > playerPrefsManager.GetPlayerLevel())
                {
                    // ���Z�������ʃv���C���[���x���i����\������x���j�𒴂����ꍇ�̓v���C���[���x���Ƃ���
                    setLevel = playerPrefsManager.GetPlayerLevel();
                }
                else
                {
                    // �����Ă��Ȃ���΂��̂܂ܕ\������
                    setLevel = shipLevel + addLevel;
                }
                choiceLevelShipText.text = setLevel.ToString();
                break;
            case "volcano":
                int volcanoLevel = int.Parse(choiceLevelVolcanoText.text);
                if ((volcanoLevel + addLevel) > playerPrefsManager.GetPlayerLevel())
                {
                    // ���Z�������ʃv���C���[���x���i����\������x���j�𒴂����ꍇ�̓v���C���[���x���Ƃ���
                    setLevel = playerPrefsManager.GetPlayerLevel();
                }
                else
                {
                    // �����Ă��Ȃ���΂��̂܂ܕ\������
                    setLevel = volcanoLevel + addLevel;
                }
                choiceLevelVolcanoText.text = setLevel.ToString();
                break;
            case "boss":
                int bossLevel = int.Parse(choiceLevelBossText.text);
                if ((bossLevel + addLevel) > playerPrefsManager.GetPlayerLevel())
                {
                    // ���Z�������ʃv���C���[���x���i����\������x���j�𒴂����ꍇ�̓v���C���[���x���Ƃ���
                    setLevel = playerPrefsManager.GetPlayerLevel();
                }
                else
                {
                    // �����Ă��Ȃ���΂��̂܂ܕ\������
                    setLevel = bossLevel + addLevel;
                }
                choiceLevelBossText.text = setLevel.ToString();
                break;
        }
    }
    // �X�e�[�W�̒��탌�x����������
    public void SubtractStageLevel(string stageType, int subtractLevel)
    {
        int setLevel = 0;
        switch (stageType)
        {
            case "forest":
                int forestLevel = int.Parse(choiceLevelForestText.text);
                if ((forestLevel - subtractLevel) < 1)
                {
                    setLevel = 1;
                }
                else
                {
                    // �����Ă��Ȃ���΂��̂܂ܕ\������
                    setLevel = forestLevel - subtractLevel;
                }
                choiceLevelForestText.text = setLevel.ToString();
                break;
            case "ship":
                int shipLevel = int.Parse(choiceLevelShipText.text);
                if ((shipLevel - subtractLevel) < 1)
                {
                    setLevel = 1;
                }
                else
                {
                    // �����Ă��Ȃ���΂��̂܂ܕ\������
                    setLevel = shipLevel - subtractLevel;
                }
                choiceLevelShipText.text = setLevel.ToString();
                break;
            case "volcano":
                int volcanoLevel = int.Parse(choiceLevelVolcanoText.text);
                if ((volcanoLevel - subtractLevel) < 1)
                {
                    setLevel = 1;
                }
                else
                {
                    // �����Ă��Ȃ���΂��̂܂ܕ\������
                    setLevel = volcanoLevel - subtractLevel;
                }
                choiceLevelVolcanoText.text = setLevel.ToString();
                break;
            case "boss":
                int bossLevel = int.Parse(choiceLevelBossText.text);
                if ((bossLevel - subtractLevel) < 1)
                {
                    setLevel = 1;
                }
                else
                {
                    // �����Ă��Ȃ���΂��̂܂ܕ\������
                    setLevel = bossLevel - subtractLevel;
                }
                choiceLevelBossText.text = setLevel.ToString();
                break;
        }
    }

    // �ΎR�X�e�[�W�̃e�L�X�g���Z�b�g����
    public void SetVolcanoPanel()
    {
        clearedLevelVolcanoText.text = playerPrefsManager.GetClearedLevelVolcano().ToString();
        choiceLevelVolcanoText.text = playerPrefsManager.GetPlayerLevel().ToString();
    }
    // �C�X�e�[�W�̃e�L�X�g���Z�b�g����
    public void SetShipPanel()
    {
        clearedLevelShipText.text = playerPrefsManager.GetClearedLevelShip().ToString();
        choiceLevelShipText.text = playerPrefsManager.GetPlayerLevel().ToString();
    }
    // �X�X�e�[�W�̃e�L�X�g���Z�b�g����
    public void SetForestPanel()
    {
        clearedLevelForestText.text = playerPrefsManager.GetClearedLevelForest().ToString();
        choiceLevelForestText.text = playerPrefsManager.GetPlayerLevel().ToString();
    }
    // �{�X�X�e�[�W�̃e�L�X�g���Z�b�g�����팠������Ε\������
    public void SetBossPanel()
    {
        clearedLevelBossText.text = (playerPrefsManager.GetPlayerLevel() - 1).ToString();
        choiceLevelBossText.text = playerPrefsManager.GetPlayerLevel().ToString();

        if(IsBossAppear())
        {
            castleImage.enabled = true;
            castleButton.SetActive(true);

            if (playerPrefsManager.GetFirstBossAppear() == "true")
            {
                // �ŏ��̃{�X���o��������`���[�g���A��
                tutorialManager.StartBossAppearTutorial();
            }
        }
    }

    // �{�X�ւ̒��팠�����邩�Ԃ�
    public bool IsBossAppear()
    {
        // �v���C���[���x����3�X�e�[�W�̓��B���x���������ł���΃{�X�X�e�[�W�ɒ���\
        int playerLevel = playerPrefsManager.GetPlayerLevel();
        if (playerLevel == playerPrefsManager.GetClearedLevelVolcano()
            && playerLevel == playerPrefsManager.GetClearedLevelShip()
            && playerLevel == playerPrefsManager.GetClearedLevelForest())
        {
            return true;
        }

        return false;
    }
}
