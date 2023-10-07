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

    // �p�Y���S�̂̏��
    public string puzzleState;

    // �R���{�̏��
    public string comboState;

    // �R���{�Ɋւ���o�ߎ��ԁB�U���{�^���������ꂽ�Ƃ����瑪��J�n�B
    public float comboTime;
    // �U���Ɖ񕜂Ɋւ���o�ߎ���
    public float attackEffectTime;
    // �G����̍U���Ɋւ���o�ߎ���
    public float enemyAttackEffectTime;

    // �X�L���g�p�Ɋւ���o�ߎ��ԁB�X�L���{�^���������ꂽ�Ƃ����瑪��J�n�B
    public float skillTime;
    
    // ������̏����p�l����\������܂łɎg�p���鎞��
    public float winTime;

    // 5�~5���̃u���b�N
    public GameObject[] PartsButtonList;

    // �v���n�u
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

    // ���ꂼ��̃p�[�c�i�v���n�u�j��ۑ����Ă�������
    public List<Dictionary<string, GameObject>> partsList;

    // 1��̍U���ŏ����ׂ��p�[�c�̈ʒu���
    public List<Dictionary<int, string>> comboPartsPosition;

    // �R���{��
    public int comboCount;

    // �U���p�l���̃o�[
    public GameObject attackBar_1;
    public GameObject attackBar_2;

    // Start is called before the first frame update
    void Start()
    {
        // ���낢�돉����
        partsList = new List<Dictionary<string, GameObject>>();
        comboPartsPosition = new List<Dictionary<int, string>>();
        comboCount = 0;
        puzzleState = "puzzle";

        // �G�̏�����
        enemyManager.CreateEnemy();

        GetUserRatio();
        FirstCreateParts();

        string sceneName = SceneManager.GetActiveScene().name;

        if((sceneName == "VolcanoScene" || sceneName == "ShipScene" || sceneName == "ForestScene") && playerPrefsManager.GetFirstPuzzle() == "true")
        {
            // �ŏ��̃p�Y���ł���΃`���[�g���A��
            tutorialManager.StartPuzzleTutorial();
        }
        
        if((sceneName == "BossScene") && playerPrefsManager.GetFirstBoss() == "true")
        {
            // �ŏ��̃{�X�p�Y���ł���΃`���[�g���A��
            tutorialManager.StartBossPuzzleTutorial();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �Q�[���J�n���Ƀp�[�c�𐶐�����
    public void FirstCreateParts()
    {
        // ���[�U�̗��p�f�o�C�X�ɍ��킹�Đ�������v���n�u�̑傫�����v�Z����B
        float userRatio = GetUserRatio();
        float createPrefabScale = StandardPrefabScale * userRatio;

        // �v���n�u�̑傫����ύX����B
        ChangePrefabSize(createPrefabScale);

        // �u���b�N���ɏ���
        foreach (GameObject button in PartsButtonList)
        {
            // �u���b�N�̍���̍��W���擾
            float x = button.transform.position.x;
            float y = button.transform.position.y;

            // �����_���Ƀp�[�c����
            GameObject prefab_1 = GetRandomPrefab_4();
            GameObject part_1 = Instantiate(prefab_1, new Vector3(x, y, 0), Quaternion.identity);

            GameObject prefab_2 = GetRandomPrefab_4();
            GameObject part_2 = Instantiate(prefab_2, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 180));

            // ���������p�[�c��ۑ�����
            Dictionary<string, GameObject> block = new Dictionary<string, GameObject>();
            block["lr"] = part_1;
            block["ul"] = part_2;
            block["ll"] = null;
            block["ur"] = null;
            partsList.Add(block);
        }
    }

    // 4��ނ̃p�[�c����1�������_���őI�ԁB�Ԃ��̂̓v���n�u�B
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

    // 4��ނ̃p�[�c����1�������_���őI�ԁB�Ԃ��̂͐F�B
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

    // �S�Ẵp�[�c���폜����
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

    // �S�Ẵp�[�c��\���ɂ���
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

    // �S�Ẵp�[�c���\���ɂ���
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

    // �p�[�c�̕\����\����؂�ւ���
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

    // �p�[�c�𐶐�����
    public GameObject CreatePart(string color, int buttonNum, string direction)
    {
        // �u���b�N�̍���̍��W���擾
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

    // ��ჃG�t�F�N�g�𐶐�����
    public GameObject CreatePartPara(int buttonNum)
    {
        // �u���b�N�̍���̍��W���擾
        float x = PartsButtonList[buttonNum].transform.position.x;
        float y = PartsButtonList[buttonNum].transform.position.y;

        return Instantiate(PrefabParalysis, new Vector3(x, y, 0), Quaternion.identity);
    }

    // �ÈŃG�t�F�N�g�𐶐�����
    public GameObject CreatePartDarkness(int buttonNum)
    {
        // �u���b�N�̍���̍��W���擾
        float x = PartsButtonList[buttonNum].transform.position.x;
        float y = PartsButtonList[buttonNum].transform.position.y;

        return Instantiate(PrefabDarkness, new Vector3(x, y, 0), Quaternion.identity);
    }

    // �����{�^���ԍ��Ɉ����u���b�N�̏��i�p�[�c�j��ۑ�����
    public void SaveBlock(int buttonNum, Dictionary<string, GameObject> block)
    {
        partsList[buttonNum] = block;
    }

    // �����{�^���ԍ��ɃZ�b�g����Ă���p�[�c���擾����
    public Dictionary<string, GameObject> GetBlock(int buttonNum)
    {
        return partsList[buttonNum];
    }

    // �����{�^���ԍ��̃p�[�c�̖��邳��ύX����
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

    // �N���A���������X�e�[�W���x�����烉���_���ɃX�e�[�^�X�̒l��Ԃ��B�험�i��HP�ȊO�̒��I�Ɏg���B
    public int GetRandomBootyStatus()
    {
        // �N���A�����X�e�[�W�̃��x��
        int level = playerPrefsManager.GetPlayLevel();

        // ����ȓG�̏ꍇ�����l
        if (enemyManager.enemyType == "gold")
        {
            return Random.Range(9, 11) * level;
        }
        else if(enemyManager.enemyType == "silver")
        {
            return Random.Range(7, 11) * level;
        }

        // �͈͂̓��x���~1���烌�x���~10�܂ł̊�
        return Random.Range(1, 11) * level;
    }

    // �N���A���������X�e�[�W���x�����烉���_���ɃX�e�[�^�X�̒l��Ԃ��B�험�i��HP�̒��I�Ɏg���B
    public int GetRandomBootyHp()
    {
        // �N���A�����X�e�[�W�̃��x��
        int level = playerPrefsManager.GetPlayLevel();

        // ����ȓG�̏ꍇ�����l
        if (enemyManager.enemyType == "gold")
        {
            return Random.Range(900, 1000) * level;
        }
        else if (enemyManager.enemyType == "silver")
        {
            return Random.Range(700, 1000) * level;
        }

        // �͈͂̓��x���~100���烌�x���~1000�܂ł̊�
        return Random.Range(100, 1001) * level;
    }

    // �����i�̃X�e�[�^�X�̋����������̈ʒu�ɂ��邩�Ԃ�
    public int GetParamAve(int hp, int attack, int heal)
    {
        // �N���A�����X�e�[�W�̃��x��
        int level = playerPrefsManager.GetPlayLevel();

        int attack_100 = attack * 100;
        int heal_100 = heal * 100;

        return (hp + attack_100 + heal_100) / (3 * 100 * level);
    }

    // �험�i�̕󔠂̃O���[�h��Ԃ�
    public string GetTreasureGrade(int hp, int attack, int heal, string spEffect)
    {
        if(spEffect == "empty")
        {
            // ������ʖ����̓m�[�}��
            return "normal";
        }

        int ave = GetParamAve(hp, attack, heal);
        if(ave >= 8)
        {
            // 8���ȏ�̓S�[���h
            return "gold";
        }
        else if(ave >= 6)
        {
            // 6���ȏ�̓V���o�[
            return "silver";
        }

        return "normal";
    }

    // ���[�U�̗��p�f�o�C�X�ɍ��킹�ĉ��{����Β��x�悭�Ȃ邩�v�Z����
    public float GetUserRatio()
    {       
        // ���ɕۑ��ς݂ł���΂�����v�Z�Ɏg���ĕԂ�
        if (PlayerPrefs.HasKey("userRatio"))
        {
            return PlayerPrefs.GetFloat("userRatio") / StandardBlockLossyScale ;
        }

        // ���ۑ��ł���Όv�Z���ĕۑ����Ă���Ԃ�
        float userBlockScale = PartsButtonList[0].GetComponent<RectTransform>().lossyScale.x;
        PlayerPrefs.SetFloat("userRatio", userBlockScale);
        PlayerPrefs.Save();

        return (userBlockScale / StandardBlockLossyScale);
    }

    // �p�[�c�̐F����p�[�c�̃v���n�u��Ԃ�
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

    // �����F�̃R���{�p�̐F��Ԃ�
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

    // �v���n�u�̃T�C�Y��ύX����
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
