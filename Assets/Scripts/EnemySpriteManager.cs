using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpriteManager : MonoBehaviour
{
    // 敵のイメージ一覧
    public Sprite[] enemyRedSpriteArray;
    public Sprite[] enemyBlueSpriteArray;
    public Sprite[] enemyGreenSpriteArray;

    // Start is called before the first frame update
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "StartScene")
        {
            LoadEnemySprite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 敵の画像を読み込む。ゲーム開始時に一度だけ行う。
    public void LoadEnemySprite()
    {
        enemyRedSpriteArray = Resources.LoadAll<Sprite>("Images/enemy/red/");
        enemyBlueSpriteArray = Resources.LoadAll<Sprite>("Images/enemy/blue/");
        enemyGreenSpriteArray = Resources.LoadAll<Sprite>("Images/enemy/green/");
    }
}
