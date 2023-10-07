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

    // �Q�[���X�^�[�g����SE
    public void SoundGameStartSe()
    {
        audioSource.PlayOneShot(gameStartSe);
    }
    // �I������SE
    public void SoundChoiceSe()
    {
        audioSource.PlayOneShot(choiceSe);
    }
    // �{�^���N���b�N����SE
    public void SoundClickSe()
    {
        audioSource.PlayOneShot(clickSe);
    }
    // �߂鎞��SE
    public void SoundReturnSe()
    {
        audioSource.PlayOneShot(returnSe);
    }
    // ��������SE
    public void SoundWalkSe()
    {
        audioSource.PlayOneShot(walkSe);
    }
    // �o�C�N��SE
    public void SoundBikeSe()
    {
        audioSource.PlayOneShot(bikeSe);
    }
    // �w���R�v�^�[��SE
    public void SoundHelicopterSe()
    {
        audioSource.PlayOneShot(helicopterSe);
    }
    // �����J���Ƃ���SE
    public void SoundOpenDoorSe()
    {
        audioSource.PlayOneShot(openDoorSe);
    }
    // �p�l������]������Ƃ���SE
    public void SoundSpinSe()
    {
        audioSource.PlayOneShot(spinSe);
    }
    // �R���{��SE
    public void SoundComboSe()
    {
        audioSource.PlayOneShot(comboSe);
    }
    // �U��1��SE
    public void SoundAttackSe_1()
    {
        audioSource.PlayOneShot(attackSe_1);
    }
    // �U��2��SE
    public void SoundAttackSe_2()
    {
        audioSource.PlayOneShot(attackSe_2);
    }
    // �U��3��SE
    public void SoundAttackSe_3()
    {
        audioSource.PlayOneShot(attackSe_3);
    }
    // �U��4��SE
    public void SoundAttackSe_4()
    {
        audioSource.PlayOneShot(attackSe_4);
    }
    // �G�̒ʏ�U����SE
    public void SoundEnemyNormalAttackSe()
    {
        audioSource.PlayOneShot(enemyNormalAttackSe);
    }
    // �G�̓���U����SE
    public void SoundEnemySpAttackSe()
    {
        audioSource.PlayOneShot(enemySpAttackSe);
    }
    // �G�̍U���q�b�g��SE
    public void SoundEnemyAttackSe()
    {
        audioSource.PlayOneShot(enemyAttackSe);
    }
    // �񕜂�SE
    public void SoundHealSe()
    {
        audioSource.PlayOneShot(healSe);
    }
    // �p�����[�^�㏸��SE
    public void SoundParamUpSe()
    {
        audioSource.PlayOneShot(paramUpSe);
    }
    // �p�l���ϊ���SE
    public void SoundChangePanelSe()
    {
        audioSource.PlayOneShot(changePanelSe);
    }
    // �G�̏�����SE
    public void SoundEraseSe()
    {
        audioSource.PlayOneShot(eraseSe);
    }
    // �󔠂�U���SE
    public void SoundShakeTreasureSe()
    {
        audioSource.PlayOneShot(shakeTreasureSe);
    }
    // �󔠂��J����SE
    public void SoundOpenTreasureSe()
    {
        audioSource.PlayOneShot(openTreasureSe);
    }
}
