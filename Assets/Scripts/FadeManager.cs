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

    // ��ʂ��Â��Ȃ��đJ�ڂ���܂ł̎���
    float limitTime = 2;

    // ��ʂ��Â����邩�ǂ����BTRUE:�Â�����
    bool isFade = false;
    // �J�ډ\���ǂ����BTRUE:�J�ډ\
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
            // �i�X�Â�����
            time += Time.deltaTime;
            float fadeRatio = time / limitTime;

            if (time >= limitTime)
            {
                // ���܂������Ԃ��o�߂�����J�ڂ���
                SceneManager.LoadScene(nextSceneName);
                return;
            }

            if(fadeRatio > 1)
            {
                fadeRatio = 1;
            }

            // �Â�����
            fadePanel.GetComponent<Image>().color = new Color(0, 0, 0, fadeRatio);

            // BGM������������
            float reduceBgm = playerPrefsManager.GetBgmVolume() - (diffBgm * fadeRatio);
            bgmManager.ChangeVolume("bgmGroup", reduceBgm);
        }
    }

    // �����V�[���ւ̑J�ڂ��n�߂�
    public void StartFade(string sceneName)
    {
        nextSceneName = sceneName;

        isFade = true;

        fadePanel.SetActive(true);
    }

    public float GetFadeBgm()
    {
        // �ݒ肵�Ă���BGM�̉��ʁi-80����10�j
        float playerBgmVolume = playerPrefsManager.GetBgmVolume();

        // ���ʂ��قڃ[���i-50�j�ɂ���܂ŉ�����K�v�����鐔�l
        float diffVolume = playerBgmVolume + 50f;

        return diffVolume;
    }
}
