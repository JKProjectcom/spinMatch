using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class BgmManager : MonoBehaviour
{
    public SeManager seManager;
    public HomePanelManager homePanelManager;
    public PlayerPrefsManager playerPrefsManager;

    public AudioMixer audioMixer;
    public string bgmGroup;
    public string seGroup;

    public AudioSource currentAudioSource;
    public AudioSource topBgm;
    public AudioSource volcanoBgm;
    public AudioSource shipBgm;
    public AudioSource forestBgm;
    public AudioSource bossBgm;

    public AudioSource winBgm;
    public AudioSource loseBgm;

    // Start is called before the first frame update
    void Start()
    {
        SetBgmVolume();
        SetSeVolume();

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "TopScene"){
            currentAudioSource = topBgm;
        }else if (sceneName == "VolcanoScene") {
            currentAudioSource = volcanoBgm;
        } else if (sceneName == "ShipScene") {
            currentAudioSource = shipBgm;
        } else if (sceneName == "ForestScene"){
            currentAudioSource = forestBgm;
        } else if (sceneName == "BossScene"){
            currentAudioSource = bossBgm;
        }

        if(sceneName != "StartScene")
        {
            currentAudioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundWinBgm()
    {
        currentAudioSource.Stop();
        winBgm.Play();
    }
    public void SoundLoseBgm()
    {
        currentAudioSource.Stop();
        loseBgm.Play();
    }

    // ユーザ設定のBGM音量を適用する
    public void SetBgmVolume()
    {
        float volume = playerPrefsManager.GetBgmVolume();

        ChangeVolume(bgmGroup, volume);
    }
    // ユーザ設定のSE音量を適用する
    public void SetSeVolume()
    {
        float volume = playerPrefsManager.GetSeVolume();

        ChangeVolume(seGroup, volume);
    }

    public void ClickBgm_0()
    {
        seManager.SoundClickSe();

        ChangeVolume(bgmGroup, -80);

        playerPrefsManager.SetBgmVolume(-80);

        homePanelManager.BrightenVolumeButton("bgm", 0);
    }
    public void ClickBgm_1()
    {
        seManager.SoundClickSe();

        ChangeVolume(bgmGroup, -20);

        playerPrefsManager.SetBgmVolume(-20);

        homePanelManager.BrightenVolumeButton("bgm", 1);
    }
    public void ClickBgm_2()
    {
        seManager.SoundClickSe();

        ChangeVolume(bgmGroup, -10);

        playerPrefsManager.SetBgmVolume(-10);

        homePanelManager.BrightenVolumeButton("bgm", 2);
    }
    public void ClickBgm_3()
    {
        seManager.SoundClickSe();

        ChangeVolume(bgmGroup, 0);

        playerPrefsManager.SetBgmVolume(0);

        homePanelManager.BrightenVolumeButton("bgm", 3);
    }
    public void ClickBgm_4()
    {
        seManager.SoundClickSe();

        ChangeVolume(bgmGroup, 5);

        playerPrefsManager.SetBgmVolume(5);

        homePanelManager.BrightenVolumeButton("bgm", 4);
    }
    public void ClickBgm_5()
    {
        seManager.SoundClickSe();

        ChangeVolume(bgmGroup, 10);

        playerPrefsManager.SetBgmVolume(10);

        homePanelManager.BrightenVolumeButton("bgm", 5);
    }

    public void ClickSe_0()
    {
        seManager.SoundClickSe();

        ChangeVolume(seGroup, -80);

        playerPrefsManager.SetSeVolume(-80);

        homePanelManager.BrightenVolumeButton("se", 0);
    }
    public void ClickSe_1()
    {
        seManager.SoundClickSe();

        ChangeVolume(seGroup, -20);

        playerPrefsManager.SetSeVolume(-20);

        homePanelManager.BrightenVolumeButton("se", 1);
    }
    public void ClickSe_2()
    {
        seManager.SoundClickSe();

        ChangeVolume(seGroup, -10);

        playerPrefsManager.SetSeVolume(-10);

        homePanelManager.BrightenVolumeButton("se", 2);
    }
    public void ClickSe_3()
    {
        seManager.SoundClickSe();

        ChangeVolume(seGroup, 0);

        playerPrefsManager.SetSeVolume(0);

        homePanelManager.BrightenVolumeButton("se", 3);
    }
    public void ClickSe_4()
    {
        seManager.SoundClickSe();

        ChangeVolume(seGroup, 5);

        playerPrefsManager.SetSeVolume(5);

        homePanelManager.BrightenVolumeButton("se", 4);
    }
    public void ClickSe_5()
    {
        seManager.SoundClickSe();

        ChangeVolume(seGroup, 10);

        playerPrefsManager.SetSeVolume(10);

        homePanelManager.BrightenVolumeButton("se", 5);
    }


    // 引数グループの音量を引数音量に変更
    public void ChangeVolume(string groupName, float volume)
    {
        audioMixer.SetFloat(groupName, volume);
    }
}
