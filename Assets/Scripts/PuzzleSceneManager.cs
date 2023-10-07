using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleSceneManager : MonoBehaviour
{
    public PuzzleMain puzzleMain;
    public ClearPanelManager clearPanelManager;
    public PlayerStatusManager playerStatusManager;
    public SeManager seManager;
    public FadeManager fadeManager;

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject restrictPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // トップ画面に遷移する
    public void GoTop()
    {
        seManager.SoundChoiceSe();
        clearPanelManager.SaveEquipment();
        fadeManager.StartFade("TopScene");
    }

    // もう一度同じゲームをプレイする
    public void Retry()
    {
        seManager.SoundChoiceSe();
        clearPanelManager.SaveEquipment();

        string currentScene = SceneManager.GetActiveScene().name;
        fadeManager.StartFade(currentScene);
    }
}
