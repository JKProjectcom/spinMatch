using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public PuzzleMain puzzleMain;
    public PlayerPrefsManager playerPrefsManager;
    public HomePanelManager homePanelManager;
    public TextManager textManager;

    public GameObject tutorialPanel;

    public Text message;

    public Image heroImage;

    public Sprite heroSprite_1;
    public Sprite heroSprite_2;
    public int currentHeroNum = 1;
    public float heroTime;

    public Button nextButton;
    public Button backButton;

    public bool isTutorial;
    public string currentTutorialName;

    public List<string> tutorialTextList = new List<string>();
    public int currentTextNum = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isTutorial)
        {
            heroTime += Time.deltaTime;
            if(heroTime > 0.8f)
            {
                if(currentHeroNum == 1)
                {
                    heroImage.sprite = heroSprite_2;
                    currentHeroNum = 2;
                }
                else
                {
                    heroImage.sprite = heroSprite_1;
                    currentHeroNum = 1;
                }
                heroTime = 0;
            }
        }
    }

    // �g�b�v��ʂ̃`���[�g���A���J�n
    public void StartTopTutorial()
    {
        tutorialTextList = textManager.GetFirstTopTutorialText();

        playerPrefsManager.SetFirstTop("false");

        CommonStartProcess();
    }

    // �z�[����ʂ̃`���[�g���A���J�n
    public void StartHomeTutorial()
    {
        tutorialTextList = textManager.GetFirstHomeTutorialText();

        playerPrefsManager.SetFirstHome("false");
        homePanelManager.homePanelSquare.SetActive(false);
        currentTutorialName = "home";

        CommonStartProcess();
    }

    // �p�Y����ʂ̃`���[�g���A���J�n
    public void StartPuzzleTutorial()
    {
        tutorialTextList = textManager.GetFirstPuzzleTutorialText();

        playerPrefsManager.SetFirstPuzzle("false");
        puzzleMain.ChangePartsActive(new List<int> { 3, 4 ,8,9,13,14,18,19,23,24}, false);
        currentTutorialName = "puzzle";

        CommonStartProcess();
    }

    // ������ʂ̃`���[�g���A���J�n
    public void StartWinTutorial()
    {
        tutorialTextList = textManager.GetFirstWinTutorialText();

        playerPrefsManager.SetFirstWin("false");
        currentTutorialName = "win";

        CommonStartProcess();
    }

    // �{�X�o���̃`���[�g���A���J�n
    public void StartBossAppearTutorial()
    {
        tutorialTextList = textManager.GetFirstBossAppearTutorialText();

        playerPrefsManager.SetFirstBossAppear("false");
        currentTutorialName = "bossAppear";

        CommonStartProcess();
    }

    // �{�X�p�Y���̃`���[�g���A���J�n
    public void StartBossPuzzleTutorial()
    {
        tutorialTextList = textManager.GetFirstBossPuzzleTutorialText();

        playerPrefsManager.SetFirstBoss("false");
        puzzleMain.ChangePartsActive(new List<int> { 3, 4, 8, 9, 13, 14, 18, 19, 23, 24 }, false);
        currentTutorialName = "bossPuzzle";

        CommonStartProcess();
    }

    // �`���[�g���A���J�n�̋��ʏ���
    public void CommonStartProcess()
    {
        message.text = tutorialTextList[0];
        currentTextNum = 0;
        isTutorial = true;
        tutorialPanel.SetActive(true);
    }

    public void ClickNext()
    {
        currentTextNum++;
        if (tutorialTextList.Count <= currentTextNum)
        {
            // �y�[�W�������Ȃ���ΏI��
            tutorialPanel.SetActive(false);
            isTutorial = false;

            if(currentTutorialName == "home")
            {
                homePanelManager.homePanelSquare.SetActive(true);
            }
            else if(currentTutorialName == "puzzle" || currentTutorialName == "bossPuzzle")
            {
                puzzleMain.ChangePartsActive(new List<int> { 3, 4, 8, 9, 13, 14, 18, 19, 23, 24 }, true);
            }

            return;
        }

        message.text = tutorialTextList[currentTextNum];
    }
    public void ClickBack()
    {
        currentTextNum--;
        if (currentTextNum < 0)
        {
            currentTextNum = 0;
        }

        message.text = tutorialTextList[currentTextNum];
    }
}
