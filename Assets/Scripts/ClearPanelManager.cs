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

    // 宝箱のグレード
    public string treasureGrade_1;
    public string treasureGrade_2;
    // 宝箱を開くのに関わるもの
    public string treasureState;
    public int rotateCount;
    public float treasureTime;
    public bool isShakedTreasure;
    public bool isOpenedTreasure;
    // 抽選された戦利品の種類
    public string bootyType;
    // 抽選された戦利品の情報
    public string bootyInfo;
    // 抽選された広告戦利品の情報
    public string adsInfo;
    // 前回広告視聴からx時間経過しているか
    public bool isPassedAds;
    // x時間
    public int adsHour = 1;
    // 選択されている装備品を格納しておく
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

    // 戦利品パネルのイメージをセットする
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

    // 戦利品の抽選をする
    public void LotteryBooty()
    {
        puzzleMain.GetRandomBootyStatus();

        // ステータスの抽選
        int hp = puzzleMain.GetRandomBootyHp();
        int attack = puzzleMain.GetRandomBootyStatus();
        int heal = puzzleMain.GetRandomBootyStatus();
        // 追加効果の抽選
        string spEffect = spEffectManager.GetRandomSpEffect();
        // 宝箱のグレード
        treasureGrade_1 = puzzleMain.GetTreasureGrade(hp, attack, heal, spEffect);
        // 宝箱のイメージセット
        SetTreasure(treasureImage_1, treasureGrade_1);

        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            // 1/2でモールド獲得
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

            // モールドの抽選
            string moldName = moldManager.GetRandomMoldName();
            bootyInfo = moldName;

            // 倍率
            float mag = moldManager.GetMoldMagnification(moldName);
            bootyMoldMag.text = mag.ToString();

            // モールドのイメージ
            bootyMoldImage.sprite = moldManager.GetMoldSprite(moldName);

            // ステータス
            bootyInfo += "," + hp + "," + attack + "," + heal;
            bootyMoldHp.text = hp.ToString();
            bootyMoldAttack.text = attack.ToString();
            bootyMoldHeal.text = heal.ToString();

            // 追加効果
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
            // 1/2でスキル獲得
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

            // スキルの抽選
            string skillName = skillManager.GetRandomSkill();
            bootyInfo = skillName;

            // スキルの説明
            bootySkillDesc.text = skillManager.GetSkillDesc(skillName);

            // スキルのイメージ
            bootySkillImage.sprite = skillManager.GetSkillSprite(skillName);

            // ステータス
            bootyInfo += "," + hp + "," + attack + "," + heal;
            bootySkillHp.text = hp.ToString();
            bootySkillAttack.text = attack.ToString();
            bootySkillHeal.text = heal.ToString();

            // 追加効果
            bootyInfo += "," + spEffect;
            if (spEffect == "empty")
            {
                bootySkillSpEffect.text = "";
            }
            else
            {
                bootySkillSpEffect.text = spEffectManager.GetSpEffectDesc(spEffect);
            }

            // スキルの場合ターン数も抽選
            int turn = UnityEngine.Random.Range(5, 10);
            bootyInfo += "," + turn;
            bootySkillTurn.text = turn.ToString();
        }

        // 広告視聴による報酬追加
        isPassedAds = IsPassedAdsTime(adsHour);
        if (!isPassedAds)
        {
            // 広告が有効

            // ステータスの抽選
            int adsHp = puzzleMain.GetRandomBootyHp();
            int adsAttack = puzzleMain.GetRandomBootyStatus();
            int adsHeal = puzzleMain.GetRandomBootyStatus();
            // 追加効果の抽選
            string adsSpEffect = spEffectManager.GetRandomSpEffect();
            // 宝箱のグレード
            treasureGrade_2 = puzzleMain.GetTreasureGrade(adsHp, adsAttack, adsHeal, adsSpEffect);
            // 宝箱のイメージセット
            SetTreasure(treasureImage_2, treasureGrade_2);
            treasureImage_2.color = new Color32(255, 255, 255, 255);

            if (bootyType == "mold")
            {
                // 通常報酬がモールドなので追加もモールド
                adsMoldPanel.SetActive(true);
                adsMoldCheckImage.color = new Color32(255, 255, 255, 0);
                adsMoldPanel.GetComponent<Image>().color = new Color32(180, 180, 180, 255);

                // モールドの抽選
                string adsMoldName = moldManager.GetRandomMoldName();
                adsInfo = adsMoldName;

                // 倍率
                float adsMag = moldManager.GetMoldMagnification(adsMoldName);
                adsMoldMag.text = adsMag.ToString();

                // モールドのイメージ
                adsMoldImage.sprite = moldManager.GetMoldSprite(adsMoldName);

                // ステータス
                adsInfo += "," + adsHp + "," + adsAttack + "," + adsHeal;
                adsMoldHp.text = adsHp.ToString();
                adsMoldAttack.text = adsAttack.ToString();
                adsMoldHeal.text = adsHeal.ToString();

                // 追加効果
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
                // スキル
                adsSkillPanel.SetActive(true);
                adsSkillCheckImage.color = new Color32(255, 255, 255, 0);
                adsSkillPanel.GetComponent<Image>().color = new Color32(180, 180, 180, 255);

                // スキルの抽選
                string adsSkillName = skillManager.GetRandomSkill();
                adsInfo = adsSkillName;

                // スキルの説明
                adsSkillDesc.text = skillManager.GetSkillDesc(adsSkillName);

                // スキルのイメージ
                adsSkillImage.sprite = skillManager.GetSkillSprite(adsSkillName);

                // ステータス
                adsInfo += "," + adsHp + "," + adsAttack + "," + adsHeal;
                adsSkillHp.text = adsHp.ToString();
                adsSkillAttack.text = adsAttack.ToString();
                adsSkillHeal.text = adsHeal.ToString();

                // 追加効果
                adsInfo += "," + adsSpEffect;
                if (adsSpEffect == "empty")
                {
                    adsSkillSpEffect.text = "";
                }
                else
                {
                    adsSkillSpEffect.text = spEffectManager.GetSpEffectDesc(adsSpEffect);
                }

                // スキルの場合ターン数も抽選
                int adsTurn = UnityEngine.Random.Range(7, 9);
                adsInfo += "," + adsTurn;
                adsSkillTurn.text = adsTurn.ToString();
            }
        }
        else
        {
            // 広告が無効。広告視聴ができるようにする。

            SeeAdsPanel.SetActive(true);
        }
    }

    // 宝箱のイメージをセットする
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

    // 選択された装備品をデータに保存する
    public void SaveEquipment()
    {
        bool isSelectedMoldBooty = selectedButtonNameList.Contains("moldBootyButton");
        bool isSelectedMoldAds = selectedButtonNameList.Contains("moldAdsButton");
        if (isSelectedMoldBooty && isSelectedMoldAds)
        {
            // 通常と広告モールド両方選択
            playerPrefsManager.SetMold_1(bootyInfo);
            playerPrefsManager.SetMold_2(adsInfo);
            return;
        }

        if (isSelectedMoldBooty)
        {
            // 通常モールドのみ選択

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
            // 広告モールドのみ選択

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
            // 通常と広告スキル両方選択
            playerPrefsManager.SetSkill_1(bootyInfo);
            playerPrefsManager.SetSkill_2(adsInfo);
            return;
        }

        if (isSelectedSkillBooty)
        {
            // 通常スキルのみ選択

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
            // 広告スキルのみ選択

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

    // 宝箱の押下
    public void ClickTreasure()
    {
        treasureState = "open";
    }

    // 引数宝箱グレードから開いた宝箱のspriteを返す
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

    // 装備品の押下
    public void ClickEquipment()
    {
        // 押下されたボタンのオブジェクト
        GameObject button = eventSystem.currentSelectedGameObject;

        string buttonName = button.name;

        if (!buttonName.Contains(bootyType))
        {
            // 抽選された戦利品と同じタイプでなければ押下は無効
            return;
        }

        if (selectedButtonNameList.Contains(buttonName))
        {
            // 既に選択されている装備品を押下したら選択解除
            selectedButtonNameList.Remove(buttonName);

            UnselectEquipment(buttonName);
        }
        else
        {
            // 未選択の場合選択済みの装備品が2個未満であれば選択
            if (selectedButtonNameList.Count < 2)
            {
                selectedButtonNameList.Add(buttonName);

                SelectEquipment(buttonName);
            }
        }

        // 装備品をまだ2つ選択していない場合トップに遷移したりやリプレイは不可
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

    // 引数ボタン名から装備品パネルの選択状態に変更する
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

    // 引数ボタン名から装備品パネルの未選択状態に変更する
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

    // 広告を見てからx時間経過したかどうか返す
    public bool IsPassedAdsTime(int x)
    {
        // 現在時刻
        DateTime now = DateTime.Now;
        // 前回広告視聴時刻文字列
        string lastAdsTimeString = playerPrefsManager.GetAdsTimeString();
        if(lastAdsTimeString == "")
        {
            return true;
        }

        // 前回広告視聴時刻
        DateTime lastAdsTime = DateTime.Parse(lastAdsTimeString);

        // 差分
        TimeSpan diff = now - lastAdsTime;
        if (diff.TotalHours > x)
        {
            // x時間経過している
            return true;
        }

        return false;
    }

    // 装備の情報をセットする
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
