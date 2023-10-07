using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearPanelManager : MonoBehaviour
{
    public PuzzleMain puzzleMain;
    public PlayerStatusManager playerStatusManager;
    public PlayerPrefsManager playerPrefsManager;
    public SkillManager skillManager;
    public MoldManager moldManager;
    public SpEffectManager spEffectManager;
    public SeManager seManager;
    public EventSystem eventSystem;

    public GameObject treasurePanel;
    public GameObject bootyPanel;
    public GameObject SeeAdsPanel;
    public GameObject bootyMoldPanel;
    public GameObject bootySkillPanel;
    public GameObject adsMoldPanel;
    public GameObject adsSkillPanel;
    public GameObject moldPanel_1;
    public GameObject moldPanel_2;
    public GameObject skillPanel_1;
    public GameObject skillPanel_2;

    public Button openButton;

    public Button bootyMoldButton;
    public Button bootySkillButton;
    public Button adsMoldButton;
    public Button adsSkillButton;
    public Button moldButton_1;
    public Button moldButton_2;
    public Button skillButton_1;
    public Button skillButton_2;

    public Button goTopButton;
    public Button replayButton;

    public Image treasureImage_1;
    public Image treasureImage_2;

    public Image bootyMoldImage;
    public Image bootySkillImage;
    public Image adsMoldImage;
    public Image adsSkillImage;
    public Image moldImage_1;
    public Image moldImage_2;
    public Image skillImage_1;
    public Image skillImage_2;

    public Image bootyMoldCheckImage;
    public Image bootySkillCheckImage;
    public Image adsMoldCheckImage;
    public Image adsSkillCheckImage;
    public Image moldCheckImage_1;
    public Image moldCheckImage_2;
    public Image skillCheckImage_1;
    public Image skillCheckImage_2;

    public Sprite volcanoBootySprite;
    public Sprite shipBootySprite;
    public Sprite forestBootySprite;
    public Sprite bossBootySprite;

    public Sprite closeNormalTreasure;
    public Sprite closeSilverTreasure;
    public Sprite closeGoldTreasure;
    public Sprite openNormalTreasure;
    public Sprite openSilverTreasure;
    public Sprite openGoldTreasure;

    public Text bootyMoldHp;
    public Text bootyMoldAttack;
    public Text bootyMoldHeal;
    public Text bootyMoldSpEffect;
    public Text bootyMoldMag;

    public Text adsMoldHp;
    public Text adsMoldAttack;
    public Text adsMoldHeal;
    public Text adsMoldSpEffect;
    public Text adsMoldMag;

    public Text moldHp_1;
    public Text moldAttack_1;
    public Text moldHeal_1;
    public Text moldSpEffect_1;
    public Text moldMag_1;

    public Text moldHp_2;
    public Text moldAttack_2;
    public Text moldHeal_2;
    public Text moldSpEffect_2;
    public Text moldMag_2;

    public Text bootySkillDesc;
    public Text bootySkillTurn;
    public Text bootySkillHp;
    public Text bootySkillAttack;
    public Text bootySkillHeal;
    public Text bootySkillSpEffect;

    public Text adsSkillDesc;
    public Text adsSkillTurn;
    public Text adsSkillHp;
    public Text adsSkillAttack;
    public Text adsSkillHeal;
    public Text adsSkillSpEffect;

    public Text skillDesc_1;
    public Text skillTurn_1;
    public Text skillHp_1;
    public Text skillAttack_1;
    public Text skillHeal_1;
    public Text skillSpEffect_1;

    public Text skillDesc_2;
    public Text skillTurn_2;
    public Text skillHp_2;
    public Text skillAttack_2;
    public Text skillHeal_2;
    public Text skillSpEffect_2;

    // �󔠂̃O���[�h
    public string treasureGrade_1;
    public string treasureGrade_2;
    // �󔠂��J���̂Ɋւ�����
    public string treasureState;
    public int rotateCount;
    public float treasureTime;
    public bool isShakedTreasure;
    public bool isOpenedTreasure;
    // ���I���ꂽ�험�i�̎��
    public string bootyType;
    // ���I���ꂽ�험�i�̏��
    public string bootyInfo;
    // ���I���ꂽ�L���험�i�̏��
    public string adsInfo;
    // �O��L����������x���Ԍo�߂��Ă��邩
    public bool isPassedAds;
    // x����
    public int adsHour = 1;
    // �I������Ă��鑕���i���i�[���Ă���
    public List<string> selectedButtonNameList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        SetEquipmentInfo();
        SetBootyPanelSprite();

        goTopButton.interactable = true;
        replayButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(treasureState == "open")
        {
            treasureTime += Time.deltaTime;

            if (rotateCount == 0 && treasureTime > 0.1f)
            {
                if (!isShakedTreasure)
                {
                    seManager.SoundShakeTreasureSe();
                    isShakedTreasure = true;
                }

                treasureImage_1.transform.Rotate(0, 0, 10);
                treasureImage_2.transform.Rotate(0, 0, 10);
                rotateCount++;
            }
            else if(rotateCount == 1 && treasureTime > 0.2f)
            {
                treasureImage_1.transform.Rotate(0, 0, -10);
                treasureImage_2.transform.Rotate(0, 0, -10);
                rotateCount++;
            }
            else if (rotateCount == 2 && treasureTime > 0.3f)
            {
                treasureImage_1.transform.Rotate(0, 0, 10);
                treasureImage_2.transform.Rotate(0, 0, 10);
                rotateCount++;
            }
            else if (rotateCount == 3 && treasureTime > 0.4f)
            {
                treasureImage_1.transform.Rotate(0, 0, -10);
                treasureImage_2.transform.Rotate(0, 0, -10);
                rotateCount++;
            }
            else if (rotateCount == 4 && treasureTime > 0.6f)
            {
                if (!isOpenedTreasure)
                {
                    seManager.SoundOpenTreasureSe();
                    isOpenedTreasure = true;
                }

                Sprite openSprite_1 = GetOpenSprite(treasureGrade_1);
                Sprite openSprite_2 = GetOpenSprite(treasureGrade_2);
                treasureImage_1.sprite = openSprite_1;
                treasureImage_2.sprite = openSprite_2;
                rotateCount++;
            }
            else if(rotateCount == 5 && treasureTime > 0.8f)
            {
                treasurePanel.SetActive(false);
                treasureState = "opened";
            }
        }
    }

    // �험�i�p�l���̃C���[�W���Z�b�g����
    public void SetBootyPanelSprite()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "VolcanoScene":
                bootyPanel.GetComponent<Image>().sprite = volcanoBootySprite;
                treasurePanel.GetComponent<Image>().sprite = volcanoBootySprite;
                return;
            case "ShipScene":
                bootyPanel.GetComponent<Image>().sprite = shipBootySprite;
                treasurePanel.GetComponent<Image>().sprite = shipBootySprite;
                return;
            case "ForestScene":
                bootyPanel.GetComponent<Image>().sprite = forestBootySprite;
                treasurePanel.GetComponent<Image>().sprite = forestBootySprite;
                return;
            case "BossScene":
                bootyPanel.GetComponent<Image>().sprite = bossBootySprite;
                treasurePanel.GetComponent<Image>().sprite = bossBootySprite;
                return;
        }
    }

    // �험�i�̒��I������
    public void LotteryBooty()
    {
        puzzleMain.GetRandomBootyStatus();

        // �X�e�[�^�X�̒��I
        int hp = puzzleMain.GetRandomBootyHp();
        int attack = puzzleMain.GetRandomBootyStatus();
        int heal = puzzleMain.GetRandomBootyStatus();
        // �ǉ����ʂ̒��I
        string spEffect = spEffectManager.GetRandomSpEffect();
        // �󔠂̃O���[�h
        treasureGrade_1 = puzzleMain.GetTreasureGrade(hp, attack, heal, spEffect);
        // �󔠂̃C���[�W�Z�b�g
        SetTreasure(treasureImage_1, treasureGrade_1);

        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            // 1/2�Ń��[���h�l��
            bootyType = "mold";

            bootyMoldPanel.SetActive(true);
            moldPanel_1.SetActive(true);
            moldPanel_2.SetActive(true);
            moldCheckImage_1.color = new Color32(255, 255, 255, 255);
            moldCheckImage_2.color = new Color32(255, 255, 255, 255);
            moldPanel_1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            moldPanel_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            selectedButtonNameList.Add("moldButton_1");
            selectedButtonNameList.Add("moldButton_2");

            // ���[���h�̒��I
            string moldName = moldManager.GetRandomMoldName();
            bootyInfo = moldName;

            // �{��
            float mag = moldManager.GetMoldMagnification(moldName);
            bootyMoldMag.text = mag.ToString();

            // ���[���h�̃C���[�W
            bootyMoldImage.sprite = moldManager.GetMoldSprite(moldName);

            // �X�e�[�^�X
            bootyInfo += "," + hp + "," + attack + "," + heal;
            bootyMoldHp.text = hp.ToString();
            bootyMoldAttack.text = attack.ToString();
            bootyMoldHeal.text = heal.ToString();

            // �ǉ�����
            bootyInfo += "," + spEffect;
            if(spEffect == "empty")
            {
                bootyMoldSpEffect.text = "";
            }
            else
            {
                bootyMoldSpEffect.text = spEffectManager.GetSpEffectDesc(spEffect);
            }
        }
        else
        {
            // 1/2�ŃX�L���l��
            bootyType = "skill";

            bootySkillPanel.SetActive(true);
            skillPanel_1.SetActive(true);
            skillPanel_2.SetActive(true);
            skillCheckImage_1.color = new Color32(255, 255, 255, 255);
            skillCheckImage_2.color = new Color32(255, 255, 255, 255);
            skillPanel_1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            skillPanel_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            selectedButtonNameList.Add("skillButton_1");
            selectedButtonNameList.Add("skillButton_2");

            // �X�L���̒��I
            string skillName = skillManager.GetRandomSkill();
            bootyInfo = skillName;

            // �X�L���̐���
            bootySkillDesc.text = skillManager.GetSkillDesc(skillName);

            // �X�L���̃C���[�W
            bootySkillImage.sprite = skillManager.GetSkillSprite(skillName);

            // �X�e�[�^�X
            bootyInfo += "," + hp + "," + attack + "," + heal;
            bootySkillHp.text = hp.ToString();
            bootySkillAttack.text = attack.ToString();
            bootySkillHeal.text = heal.ToString();

            // �ǉ�����
            bootyInfo += "," + spEffect;
            if (spEffect == "empty")
            {
                bootySkillSpEffect.text = "";
            }
            else
            {
                bootySkillSpEffect.text = spEffectManager.GetSpEffectDesc(spEffect);
            }

            // �X�L���̏ꍇ�^�[���������I
            int turn = UnityEngine.Random.Range(5, 10);
            bootyInfo += "," + turn;
            bootySkillTurn.text = turn.ToString();
        }

        // �L�������ɂ���V�ǉ�
        isPassedAds = IsPassedAdsTime(adsHour);
        if (!isPassedAds)
        {
            // �L�����L��

            // �X�e�[�^�X�̒��I
            int adsHp = puzzleMain.GetRandomBootyHp();
            int adsAttack = puzzleMain.GetRandomBootyStatus();
            int adsHeal = puzzleMain.GetRandomBootyStatus();
            // �ǉ����ʂ̒��I
            string adsSpEffect = spEffectManager.GetRandomSpEffect();
            // �󔠂̃O���[�h
            treasureGrade_2 = puzzleMain.GetTreasureGrade(adsHp, adsAttack, adsHeal, adsSpEffect);
            // �󔠂̃C���[�W�Z�b�g
            SetTreasure(treasureImage_2, treasureGrade_2);
            treasureImage_2.color = new Color32(255, 255, 255, 255);

            if (bootyType == "mold")
            {
                // �ʏ��V�����[���h�Ȃ̂Œǉ������[���h
                adsMoldPanel.SetActive(true);
                adsMoldCheckImage.color = new Color32(255, 255, 255, 0);
                adsMoldPanel.GetComponent<Image>().color = new Color32(180, 180, 180, 255);

                // ���[���h�̒��I
                string adsMoldName = moldManager.GetRandomMoldName();
                adsInfo = adsMoldName;

                // �{��
                float adsMag = moldManager.GetMoldMagnification(adsMoldName);
                adsMoldMag.text = adsMag.ToString();

                // ���[���h�̃C���[�W
                adsMoldImage.sprite = moldManager.GetMoldSprite(adsMoldName);

                // �X�e�[�^�X
                adsInfo += "," + adsHp + "," + adsAttack + "," + adsHeal;
                adsMoldHp.text = adsHp.ToString();
                adsMoldAttack.text = adsAttack.ToString();
                adsMoldHeal.text = adsHeal.ToString();

                // �ǉ�����
                adsInfo += "," + adsSpEffect;
                if (adsSpEffect == "empty")
                {
                    adsMoldSpEffect.text = "";
                }
                else
                {
                    adsMoldSpEffect.text = spEffectManager.GetSpEffectDesc(adsSpEffect);
                }
            }
            else
            {
                // �X�L��
                adsSkillPanel.SetActive(true);
                adsSkillCheckImage.color = new Color32(255, 255, 255, 0);
                adsSkillPanel.GetComponent<Image>().color = new Color32(180, 180, 180, 255);

                // �X�L���̒��I
                string adsSkillName = skillManager.GetRandomSkill();
                adsInfo = adsSkillName;

                // �X�L���̐���
                adsSkillDesc.text = skillManager.GetSkillDesc(adsSkillName);

                // �X�L���̃C���[�W
                adsSkillImage.sprite = skillManager.GetSkillSprite(adsSkillName);

                // �X�e�[�^�X
                adsInfo += "," + adsHp + "," + adsAttack + "," + adsHeal;
                adsSkillHp.text = adsHp.ToString();
                adsSkillAttack.text = adsAttack.ToString();
                adsSkillHeal.text = adsHeal.ToString();

                // �ǉ�����
                adsInfo += "," + adsSpEffect;
                if (adsSpEffect == "empty")
                {
                    adsSkillSpEffect.text = "";
                }
                else
                {
                    adsSkillSpEffect.text = spEffectManager.GetSpEffectDesc(adsSpEffect);
                }

                // �X�L���̏ꍇ�^�[���������I
                int adsTurn = UnityEngine.Random.Range(7, 9);
                adsInfo += "," + adsTurn;
                adsSkillTurn.text = adsTurn.ToString();
            }
        }
        else
        {
            // �L���������B�L���������ł���悤�ɂ���B

            SeeAdsPanel.SetActive(true);
        }
    }

    // �󔠂̃C���[�W���Z�b�g����
    public void SetTreasure(Image treasureImage, string grade)
    {
        if (grade == "normal")
        {
            treasureImage.sprite = closeNormalTreasure;
        }else if(grade == "silver")
        {
            treasureImage.sprite=closeSilverTreasure;
        }else if(grade == "gold")
        {
            treasureImage.sprite = closeGoldTreasure;
        }
    }

    // �I�����ꂽ�����i���f�[�^�ɕۑ�����
    public void SaveEquipment()
    {
        bool isSelectedMoldBooty = selectedButtonNameList.Contains("moldBootyButton");
        bool isSelectedMoldAds = selectedButtonNameList.Contains("moldAdsButton");
        if (isSelectedMoldBooty && isSelectedMoldAds)
        {
            // �ʏ�ƍL�����[���h�����I��
            playerPrefsManager.SetMold_1(bootyInfo);
            playerPrefsManager.SetMold_2(adsInfo);
            return;
        }

        if (isSelectedMoldBooty)
        {
            // �ʏ탂�[���h�̂ݑI��

            if (selectedButtonNameList.Contains("moldButton_1"))
            {
                playerPrefsManager.SetMold_2(bootyInfo);
            }
            else
            {
                playerPrefsManager.SetMold_1(bootyInfo);
            }
            return;
        }

        if (isSelectedMoldAds)
        {
            // �L�����[���h�̂ݑI��

            if (selectedButtonNameList.Contains("moldButton_1"))
            {
                playerPrefsManager.SetMold_2(adsInfo);
            }
            else
            {
                playerPrefsManager.SetMold_1(adsInfo);
            }
            return;
        }

        bool isSelectedSkillBooty = selectedButtonNameList.Contains("skillBootyButton");
        bool isSelectedSkillAds = selectedButtonNameList.Contains("skillAdsButton");
        if (isSelectedSkillBooty && isSelectedSkillAds)
        {
            // �ʏ�ƍL���X�L�������I��
            playerPrefsManager.SetSkill_1(bootyInfo);
            playerPrefsManager.SetSkill_2(adsInfo);
            return;
        }

        if (isSelectedSkillBooty)
        {
            // �ʏ�X�L���̂ݑI��

            if (selectedButtonNameList.Contains("skillButton_1"))
            {
                playerPrefsManager.SetSkill_2(bootyInfo);
            }
            else
            {
                playerPrefsManager.SetSkill_1(bootyInfo);
            }
            return;
        }

        if (isSelectedSkillAds)
        {
            // �L���X�L���̂ݑI��

            if (selectedButtonNameList.Contains("skillButton_1"))
            {
                playerPrefsManager.SetSkill_2(adsInfo);
            }
            else
            {
                playerPrefsManager.SetSkill_1(adsInfo);
            }
            return;
        }
    }

    // �󔠂̉���
    public void ClickTreasure()
    {
        treasureState = "open";
    }

    // �����󔠃O���[�h����J�����󔠂�sprite��Ԃ�
    public Sprite GetOpenSprite(string treasureGrade)
    {
        if(treasureGrade == "normal")
        {
            return openNormalTreasure;
        }
        else if(treasureGrade == "silver")
        {
            return openSilverTreasure;
        }
        else if(treasureGrade == "gold")
        {
            return openGoldTreasure;
        }
        return openNormalTreasure;
    }

    // �����i�̉���
    public void ClickEquipment()
    {
        // �������ꂽ�{�^���̃I�u�W�F�N�g
        GameObject button = eventSystem.currentSelectedGameObject;

        string buttonName = button.name;

        if (!buttonName.Contains(bootyType))
        {
            // ���I���ꂽ�험�i�Ɠ����^�C�v�łȂ���Ή����͖���
            return;
        }

        if (selectedButtonNameList.Contains(buttonName))
        {
            // ���ɑI������Ă��鑕���i������������I������
            selectedButtonNameList.Remove(buttonName);

            UnselectEquipment(buttonName);
        }
        else
        {
            // ���I���̏ꍇ�I���ς݂̑����i��2�����ł���ΑI��
            if (selectedButtonNameList.Count < 2)
            {
                selectedButtonNameList.Add(buttonName);

                SelectEquipment(buttonName);
            }
        }

        // �����i���܂�2�I�����Ă��Ȃ��ꍇ�g�b�v�ɑJ�ڂ�����⃊�v���C�͕s��
        if(selectedButtonNameList.Count < 2)
        {
            goTopButton.interactable = false;
            replayButton.interactable = false;
        }
        else
        {
            goTopButton.interactable = true;
            replayButton.interactable = true;
        }
    }

    // �����{�^�������瑕���i�p�l���̑I����ԂɕύX����
    public void SelectEquipment(string buttonName)
    {
        seManager.SoundChoiceSe();
        GameObject selectPanel = bootyMoldPanel;
        Image selectCheckImage = bootyMoldCheckImage;

        switch (buttonName)
        {
            case "moldBootyButton":
                selectPanel = bootyMoldPanel;
                selectCheckImage = bootyMoldCheckImage;
                break;
            case "skillBootyButton":
                selectPanel = bootySkillPanel;
                selectCheckImage = bootySkillCheckImage;
                break;
            case "moldAdsButton":
                selectPanel = adsMoldPanel;
                selectCheckImage = adsMoldCheckImage;
                break;
            case "skillAdsButton":
                selectPanel = adsSkillPanel;
                selectCheckImage = adsSkillCheckImage;
                break;
            case "moldButton_1":
                selectPanel = moldPanel_1;
                selectCheckImage = moldCheckImage_1;
                break;
            case "moldButton_2":
                selectPanel = moldPanel_2;
                selectCheckImage = moldCheckImage_2;
                break;
            case "skillButton_1":
                selectPanel = skillPanel_1;
                selectCheckImage = skillCheckImage_1;
                break;
            case "skillButton_2":
                selectPanel = skillPanel_2;
                selectCheckImage = skillCheckImage_2;
                break;
        }

        selectPanel.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        selectCheckImage.color = new Color32(255, 255, 255, 255);
    }

    // �����{�^�������瑕���i�p�l���̖��I����ԂɕύX����
    public void UnselectEquipment(string buttonName)
    {
        seManager.SoundChoiceSe();
        GameObject selectPanel = bootyMoldPanel;
        Image selectCheckImage = bootyMoldCheckImage;

        switch (buttonName)
        {
            case "moldBootyButton":
                selectPanel = bootyMoldPanel;
                selectCheckImage = bootyMoldCheckImage;
                break;
            case "skillBootyButton":
                selectPanel = bootySkillPanel;
                selectCheckImage = bootySkillCheckImage;
                break;
            case "moldAdsButton":
                selectPanel = adsMoldPanel;
                selectCheckImage = adsMoldCheckImage;
                break;
            case "skillAdsButton":
                selectPanel = adsSkillPanel;
                selectCheckImage = adsSkillCheckImage;
                break;
            case "moldButton_1":
                selectPanel = moldPanel_1;
                selectCheckImage = moldCheckImage_1;
                break;
            case "moldButton_2":
                selectPanel = moldPanel_2;
                selectCheckImage = moldCheckImage_2;
                break;
            case "skillButton_1":
                selectPanel = skillPanel_1;
                selectCheckImage = skillCheckImage_1;
                break;
            case "skillButton_2":
                selectPanel = skillPanel_2;
                selectCheckImage = skillCheckImage_2;
                break;
        }

        selectPanel.GetComponent<Image>().color = new Color32(180, 180, 180, 255);
        selectCheckImage.color = new Color32(255, 255, 255, 0);
    }

    // �L�������Ă���x���Ԍo�߂������ǂ����Ԃ�
    public bool IsPassedAdsTime(int x)
    {
        // ���ݎ���
        DateTime now = DateTime.Now;
        // �O��L����������������
        string lastAdsTimeString = playerPrefsManager.GetAdsTimeString();
        if(lastAdsTimeString == "")
        {
            return true;
        }

        // �O��L����������
        DateTime lastAdsTime = DateTime.Parse(lastAdsTimeString);

        // ����
        TimeSpan diff = now - lastAdsTime;
        if (diff.TotalHours > x)
        {
            // x���Ԍo�߂��Ă���
            return true;
        }

        return false;
    }

    // �����̏����Z�b�g����
    public void SetEquipmentInfo()
    {
        string[] moldInfo_1 = playerStatusManager.GetMoldInfo_1();
        string[] moldInfo_2 = playerStatusManager.GetMoldInfo_2();
        string[] skillInfo_1 = playerStatusManager.GetSkillInfo_1();
        string[] skillInfo_2 = playerStatusManager.GetSkillInfo_2();

        moldHp_1.text = playerStatusManager.GetEquipmentHp(moldInfo_1);
        moldHp_2.text = playerStatusManager.GetEquipmentHp(moldInfo_2);
        skillHp_1.text = playerStatusManager.GetEquipmentHp(skillInfo_1);
        skillHp_2.text = playerStatusManager.GetEquipmentHp(skillInfo_2);

        moldAttack_1.text = playerStatusManager.GetEquipmentPower(moldInfo_1);
        moldAttack_2.text = playerStatusManager.GetEquipmentPower(moldInfo_2);
        skillAttack_1.text = playerStatusManager.GetEquipmentPower(skillInfo_1);
        skillAttack_2.text = playerStatusManager.GetEquipmentPower(skillInfo_2);

        moldHeal_1.text = playerStatusManager.GetEquipmentHeal(moldInfo_1);
        moldHeal_2.text = playerStatusManager.GetEquipmentHeal(moldInfo_2);
        skillHeal_1.text = playerStatusManager.GetEquipmentHeal(skillInfo_1);
        skillHeal_2.text = playerStatusManager.GetEquipmentHeal(skillInfo_2);

        moldSpEffect_1.text = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(moldInfo_1));
        moldSpEffect_2.text = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(moldInfo_2));
        skillSpEffect_1.text = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(skillInfo_1));
        skillSpEffect_2.text = spEffectManager.GetSpEffectDesc(playerStatusManager.GetEquipmentSpEffect(skillInfo_2));

        string moldName_1 = playerStatusManager.GetEquipmentName(moldInfo_1);
        string moldName_2 = playerStatusManager.GetEquipmentName(moldInfo_2);

        moldMag_1.text = moldManager.GetMoldMagnification(moldName_1).ToString();
        moldMag_2.text = moldManager.GetMoldMagnification(moldName_2).ToString();

        string skillName_1 = playerStatusManager.GetEquipmentName(skillInfo_1);
        string skillName_2 = playerStatusManager.GetEquipmentName(skillInfo_2);

        skillDesc_1.text = skillManager.GetSkillDesc(skillName_1);
        skillDesc_2.text = skillManager.GetSkillDesc(skillName_2);

        skillTurn_1.text = playerStatusManager.GetSkillTurn(skillInfo_1);
        skillTurn_2.text = playerStatusManager.GetSkillTurn(skillInfo_2);

        moldImage_1.sprite = moldManager.GetMoldSprite(playerStatusManager.GetEquipmentName(moldInfo_1));
        moldImage_2.sprite = moldManager.GetMoldSprite(playerStatusManager.GetEquipmentName(moldInfo_2));
        skillImage_1.sprite = skillManager.GetSkillSprite(playerStatusManager.GetEquipmentName(skillInfo_1));
        skillImage_2.sprite = skillManager.GetSkillSprite(playerStatusManager.GetEquipmentName(skillInfo_2));
    }
}
