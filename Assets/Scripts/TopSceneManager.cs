using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopSceneManager : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public PlayerPrefsManager playerPrefsManager;
    public SeManager seManager;
    public EventSystem eventSystem;

    public string selectedLanguage;
    public List<Button> langButtonList;

    // Start is called before the first frame update
    void Start()
    {
        if (playerPrefsManager.GetFirstTop() == "true")
        {
            // トップ画面のチュートリアル
            tutorialManager.StartTopTutorial();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // プライバシーポリシー確認ボタン
    public void ClickConfirmPolicy()
    {
        string url = "https://jkprojectcom.wixsite.com/jkproject/post/mold-fitting-puzzle-privacy-policy";
        Application.OpenURL(url);
    }

    // いずれかの言語の押下
    public void ClickLanguageButton()
    {
        seManager.SoundClickSe();
        GameObject button = eventSystem.currentSelectedGameObject.gameObject;
        ChangeButtonColor(button);

        selectedLanguage = button.name;
    }

    // 言語設定OKボタン
    public void ClickOkLanguage()
    {
        seManager.SoundClickSe();
        playerPrefsManager.SetLanguage(selectedLanguage);
        SceneManager.LoadScene("StartScene");
    }

    public void ChangeButtonColor(GameObject selectedButton)
    {
        foreach (var langButton in langButtonList)
        {
            langButton.image.color = new Color32(180, 180, 180, 255);
        }

        selectedButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
}
