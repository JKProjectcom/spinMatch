using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public PlayerPrefsManager playerPrefsManager;
    public BgmManager bgmManager;
    public GameObject fadePanel;

    float time = 0;

    // 画面が暗くなって遷移するまでの時間
    float limitTime = 2;

    // 画面を暗くするかどうか。TRUE:暗くする
    bool isFade = false;
    // 遷移可能かどうか。TRUE:遷移可能
    bool isPreparedLoad = false;

    public float diffBgm;
    public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        diffBgm = GetFadeBgm();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFade)
        {
            // 段々暗くする
            time += Time.deltaTime;
            float fadeRatio = time / limitTime;

            if (time >= limitTime)
            {
                // 決まった時間が経過したら遷移する
                SceneManager.LoadScene(nextSceneName);
                return;
            }

            if(fadeRatio > 1)
            {
                fadeRatio = 1;
            }

            // 暗くする
            fadePanel.GetComponent<Image>().color = new Color(0, 0, 0, fadeRatio);

            // BGMも小さくする
            float reduceBgm = playerPrefsManager.GetBgmVolume() - (diffBgm * fadeRatio);
            bgmManager.ChangeVolume("bgmGroup", reduceBgm);
        }
    }

    // 引数シーンへの遷移を始める
    public void StartFade(string sceneName)
    {
        nextSceneName = sceneName;

        isFade = true;

        fadePanel.SetActive(true);
    }

    public float GetFadeBgm()
    {
        // 設定しているBGMの音量（-80から10）
        float playerBgmVolume = playerPrefsManager.GetBgmVolume();

        // 音量をほぼゼロ（-50）にするまで下げる必要がある数値
        float diffVolume = playerBgmVolume + 50f;

        return diffVolume;
    }
}
