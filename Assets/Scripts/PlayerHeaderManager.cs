using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeaderManager : MonoBehaviour
{
    public PlayerPrefsManager playerPrefsManager;
    public PlayerStatusManager playerStatusManager;
    public MoldManager moldManager;
    public SkillManager skillManager;

    public Text playerLevel;
    public Text playerHpText;
    public Text playerAttackText;
    public Text playerHealText;

    public Image playerMold_1;
    public Image playerMold_2;
    public Image playerSkill_1;
    public Image playerSkill_2;

    public bool isInitialFrame = true;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerHeader();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // プレイヤーのステータス、モールド、スキルを画面上部に表示する
    public void SetPlayerHeader()
    {
        // プレイヤーレベル
        playerLevel.text = playerPrefsManager.GetPlayerLevel().ToString();

        // モールドの情報
        string userMold_1 = PlayerPrefs.GetString("userMold_1");
        string userMold_2 = PlayerPrefs.GetString("userMold_2");

        string[] userMoldInfo_1 = playerStatusManager.GetEquipmentInfo(userMold_1);
        string[] userMoldInfo_2 = playerStatusManager.GetEquipmentInfo(userMold_2);

        string userMoldName_1 = playerStatusManager.GetEquipmentName(userMoldInfo_1);
        string userMoldName_2 = playerStatusManager.GetEquipmentName(userMoldInfo_2);

        playerMold_1.sprite = moldManager.GetMoldSprite(userMoldName_1);
        playerMold_2.sprite = moldManager.GetMoldSprite(userMoldName_2);

        // スキルの情報
        string userSkill_1 = PlayerPrefs.GetString("userSkill_1");
        string userSkill_2 = PlayerPrefs.GetString("userSkill_2");

        string[] skillInfo_1 = playerStatusManager.GetEquipmentInfo(userSkill_1);
        string[] skillInfo_2 = playerStatusManager.GetEquipmentInfo(userSkill_2);

        string skillName_1 = playerStatusManager.GetEquipmentName(skillInfo_1);
        string skillName_2 = playerStatusManager.GetEquipmentName(skillInfo_2);

        playerSkill_1.sprite = skillManager.GetSkillSprite(skillName_1);
        playerSkill_2.sprite = skillManager.GetSkillSprite(skillName_2);

        // ステータス
        playerHpText.text = playerStatusManager.GetPlayerHp().ToString();
        playerAttackText.text = playerStatusManager.GetPlayerAttack().ToString();
        playerHealText.text = playerStatusManager.GetPlayerHeal().ToString();
    }
}
