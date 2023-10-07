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

    // �G�̃C���[�W�i��ʏ㕔�j
    public Image enemyImage;
    // �G�̃C���[�W�i�s�k�p�l���j
    public Image loseEnemyImage;
    // ������ɓG�𓧉߂�����̂Ɏg������
    public float eraseTime;

    // �G�̃^�C�v�i���A��A�ʏ�j
    public string enemyType;

    // �G�̔w�i
    public Image enemyBackImage;

    // �G�̍ő�HP
    public int enemyMaxHp;
    // �G�̌��݂�HP
    public int enemyCurrentHp;
    // �G��HP�o�[�̃X���C�_�[
    public Slider enemyHpSlider;
    // �G��HP�o�[��fill
    public GameObject enemyHpfill;
    // �G�̍U����
    public int enemyAttackPower;
    // �G�̑���
    public string enemyAttribute;

    // �G�̓���U���̎��
    public string enemySpAttackType;
    // �G�̓���U���^�[��
    public int enemySpAttackTurn;
    // �G�̓���U���^�[�����\���C���[�W
    public Image enemySpAttackImage;
    // �G�̓���U���^�[�����\���e�L�X�g
    public Text enemySpAttackText;

    // Start is called before the first frame update
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �G�̏�����
    public void CreateEnemy()
    {
        // ����
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
            // �{�X
            enemyAttribute = playerPrefsManager.GetBossAttribute();
        }

        // ���x��
        int stageLevel = playerPrefsManager.GetPlayLevel();

        // �G�̃X�e�[�^�X
        SetRandomEnemyHp();
        SetRandomEnemyAttack();

        // �GHP�̏�����
        enemyCurrentHp = enemyMaxHp;
        enemyHpSlider.value = 1;

        // ����ȓG�����I
        RandomSpEnemy();

        // �{�X�̏ꍇ����U�����Z�b�g
        if (stageType == "boss")
        {
            enemySpAttackImage.enabled = true;

            // �X�e�[�W���x���ɉ����čŏ��̃^�[�������Z�b�g����
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
                // �X�e�[�W���x��1�`9
                RandomEnemySpAttack(8);
            }
            SetEnemySpAttackTurn();
        }

        // �G�̃C���[�W���Z�b�g
        SetEnemyPanelImage(stageType);

        // �G�̔w�i�̃Z�b�g
        SetEnemyBack(stageType);        
    }

    // �G��HP�𒊑I����
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
        Debug.Log("�GHP:"+enemyMaxHp);

        float randomNum = UnityEngine.Random.Range(0.9f, 1.1f);
        enemyMaxHp = (int)(enemyMaxHp * randomNum);
    }

    // �G�̍U���͂𒊑I����
    public void SetRandomEnemyAttack()
    {
        string stageType = playerPrefsManager.GetPlayStageType();
        int stageLevel = playerPrefsManager.GetPlayLevel();

        if (stageLevel <= 9)
        {
            // ���x��9�܂ł͂�����Ǝ��
            if (stageType == "boss")
            {
                // �{�X
                enemyAttackPower = stageLevel * 100;
            }
            else
            {
                // �ʏ�
                enemyAttackPower = stageLevel * 100;
            }
        }
        else
        {
            if (stageType == "boss")
            {
                // �{�X
                enemyAttackPower = stageLevel * 250;
            }
            else
            {
                // �ʏ�
                enemyAttackPower = stageLevel * 200;
            }
        }

        float randomNum = UnityEngine.Random.Range(0.9f, 1.1f);
        enemyAttackPower = (int)(enemyAttackPower*randomNum);
    }

    // ����ȓG���ǂ������I����
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

    // �{�X�̑����ƃC���[�W�Ɣw�i�������_���ɒ��I���ĕۑ�����
    public void SaveRandomBoss()
    {
        // ����
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

        // �C���[�W
        int randomImageNum = UnityEngine.Random.Range(0, 102);
        playerPrefsManager.SetBossSpriteIndex(randomImageNum);

        // �w�i
        playerPrefsManager.SetEnemyBackIndex(UnityEngine.Random.Range(0, 5));
    }

    // �ʏ�̓G�̃C���[�W�������_���ɒ��I���ĕۑ�����
    public void SaveRandomEnemy()
    {
        // �C���[�W
        int randomImageNum = UnityEngine.Random.Range(0, 102);
        playerPrefsManager.SetEnemySpriteIndex(randomImageNum);
    }

    // �G�̉摜���X�e�[�W�̓G�p�l���ɕ\������
    public void SetEnemyPanelImage(string stageType)
    {
        string path = "images/enemy/";

        // ����ȓG
        if (enemyType == "gold")
        {
            // �S�[���h
            path += "sp/gold";
            enemyImage.sprite = Resources.Load<Sprite>(path);
            return;
        }
        else if(enemyType == "silver")
        {
            // �V���o�[
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

    // �G�̔w�i���Z�b�g����
    public void SetEnemyBack(string stageType)
    {
        string path = "images/back/" + stageType + "/" + playerPrefsManager.GetEnemyBackIndex();        
        enemyBackImage.sprite = Resources.Load<Sprite>(path);
    }

    // ����U���̃^�[������\������
    public void SetEnemySpAttackTurn()
    {
        if (playerPrefsManager.GetPlayStageType() != "boss")
        {
            return;
        }

        enemySpAttackText.text = enemySpAttackTurn.ToString();
    }

    // ����U���̃^�[����i�߂�
    public void AdvanceEnemySpAttack()
    {
        if(playerPrefsManager.GetPlayStageType() != "boss")
        {
            return;
        }

        enemySpAttackTurn--;

        SetEnemySpAttackTurn();
    }

    // ����U��������
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

        // �U����͎��ɔ����Ē��I
        RandomEnemySpAttack(0);
        SetEnemySpAttackTurn();
    }

    // ����U���̒��I
    public void RandomEnemySpAttack(int turn)
    {
        if (playerPrefsManager.GetPlayStageType() != "boss")
        {
            return;
        }

        // �^�[����
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
        

        // ���
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

    // �G�̖�ჍU��
    public void ParalysisAttack()
    {
        // ��]�s�ɂ�����̂𒊑I
        List<int> blockList = new List<int>();
        for (int i = 0; i < 25; i++)
        {
            blockList.Add(i);
        }

        List<int> targetList = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            // 10��]�s�ɂ���
            int randomIndex = UnityEngine.Random.Range(0, blockList.Count);
            int randomNum = blockList[randomIndex];
            blockList.Remove(randomNum);
            targetList.Add(randomNum);
        }

        playerStatusManager.paralysisBlockList = targetList;
    }

    // �G�̈ÈōU��
    public void DarknessAttack()
    {
        // �Èłɂ�����̂𒊑I
        List<int> blockList = new List<int>();
        for (int i = 0; i < 25; i++)
        {
            blockList.Add(i);
        }

        List<int> targetList = new List<int>();
        for (int i = 0; i < 8; i++)
        {
            // 8�Èłɂ���
            int randomIndex = UnityEngine.Random.Range(0, blockList.Count);
            int randomNum = blockList[randomIndex];
            blockList.Remove(randomNum);
            targetList.Add(randomNum);
        }

        playerStatusManager.darknessBlockList = targetList;
    }

    // �G��HP�̕ύX�𔽉f����
    public void ChangeEnemyHp()
    {
        // HP�o�[�ɔ��f
        enemyHpSlider.value = (float)enemyCurrentHp / (float)enemyMaxHp;
        attackManager.ChangeHpColor(enemyHpSlider, enemyHpfill);
    }

    // �G��HP���񕜂���
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
