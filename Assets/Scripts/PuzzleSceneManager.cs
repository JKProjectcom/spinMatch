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

    // �g�b�v��ʂɑJ�ڂ���
    public void GoTop()
    {
        seManager.SoundChoiceSe();
        clearPanelManager.SaveEquipment();
        fadeManager.StartFade("TopScene");
    }

    // ������x�����Q�[�����v���C����
    public void Retry()
    {
        seManager.SoundChoiceSe();
        clearPanelManager.SaveEquipment();

        string currentScene = SceneManager.GetActiveScene().name;
        fadeManager.StartFade(currentScene);
    }
}
