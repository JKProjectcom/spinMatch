using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SeManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip gameStartSe;
    public AudioClip choiceSe;
    public AudioClip clickSe;
    public AudioClip returnSe;

    public AudioClip walkSe;
    public AudioClip bikeSe;
    public AudioClip helicopterSe;
    public AudioClip openDoorSe;

    public AudioClip spinSe;
    public AudioClip comboSe;
    public AudioClip attackSe_1;
    public AudioClip attackSe_2;
    public AudioClip attackSe_3;
    public AudioClip attackSe_4;

    public AudioClip enemyNormalAttackSe;
    public AudioClip enemySpAttackSe;
    public AudioClip enemyAttackSe;

    public AudioClip healSe;
    public AudioClip paramUpSe;
    public AudioClip changePanelSe;

    public AudioClip eraseSe;

    public AudioClip shakeTreasureSe;
    public AudioClip openTreasureSe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ゲームスタート時のSE
    public void SoundGameStartSe()
    {
        audioSource.PlayOneShot(gameStartSe);
    }
    // 選択時のSE
    public void SoundChoiceSe()
    {
        audioSource.PlayOneShot(choiceSe);
    }
    // ボタンクリック時のSE
    public void SoundClickSe()
    {
        audioSource.PlayOneShot(clickSe);
    }
    // 戻る時のSE
    public void SoundReturnSe()
    {
        audioSource.PlayOneShot(returnSe);
    }
    // 歩く時のSE
    public void SoundWalkSe()
    {
        audioSource.PlayOneShot(walkSe);
    }
    // バイクのSE
    public void SoundBikeSe()
    {
        audioSource.PlayOneShot(bikeSe);
    }
    // ヘリコプターのSE
    public void SoundHelicopterSe()
    {
        audioSource.PlayOneShot(helicopterSe);
    }
    // 扉を開くときのSE
    public void SoundOpenDoorSe()
    {
        audioSource.PlayOneShot(openDoorSe);
    }
    // パネルを回転させるときのSE
    public void SoundSpinSe()
    {
        audioSource.PlayOneShot(spinSe);
    }
    // コンボのSE
    public void SoundComboSe()
    {
        audioSource.PlayOneShot(comboSe);
    }
    // 攻撃1のSE
    public void SoundAttackSe_1()
    {
        audioSource.PlayOneShot(attackSe_1);
    }
    // 攻撃2のSE
    public void SoundAttackSe_2()
    {
        audioSource.PlayOneShot(attackSe_2);
    }
    // 攻撃3のSE
    public void SoundAttackSe_3()
    {
        audioSource.PlayOneShot(attackSe_3);
    }
    // 攻撃4のSE
    public void SoundAttackSe_4()
    {
        audioSource.PlayOneShot(attackSe_4);
    }
    // 敵の通常攻撃のSE
    public void SoundEnemyNormalAttackSe()
    {
        audioSource.PlayOneShot(enemyNormalAttackSe);
    }
    // 敵の特殊攻撃のSE
    public void SoundEnemySpAttackSe()
    {
        audioSource.PlayOneShot(enemySpAttackSe);
    }
    // 敵の攻撃ヒットのSE
    public void SoundEnemyAttackSe()
    {
        audioSource.PlayOneShot(enemyAttackSe);
    }
    // 回復のSE
    public void SoundHealSe()
    {
        audioSource.PlayOneShot(healSe);
    }
    // パラメータ上昇のSE
    public void SoundParamUpSe()
    {
        audioSource.PlayOneShot(paramUpSe);
    }
    // パネル変換のSE
    public void SoundChangePanelSe()
    {
        audioSource.PlayOneShot(changePanelSe);
    }
    // 敵の消えるSE
    public void SoundEraseSe()
    {
        audioSource.PlayOneShot(eraseSe);
    }
    // 宝箱を振るのSE
    public void SoundShakeTreasureSe()
    {
        audioSource.PlayOneShot(shakeTreasureSe);
    }
    // 宝箱を開けるSE
    public void SoundOpenTreasureSe()
    {
        audioSource.PlayOneShot(openTreasureSe);
    }
}
