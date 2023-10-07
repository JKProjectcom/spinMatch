using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeTopManager : MonoBehaviour
{
    public TextManager textManager;

    public Text volcanoTitle;
    public Text volcanoCleared;
    public Text volcanoChallenge;
    public Text shipTitle;
    public Text shipCleared;
    public Text shipChallenge;
    public Text forestTitle;
    public Text forestCleared;
    public Text forestChallenge;
    public Text bossTitle;
    public Text bossCleared;
    public Text bossChallenge;
    public Text magTitle_1;
    public Text magTitle_2;
    public Text bgm;
    public Text se;
    public Text langTitle;
    public Text langDesc;
    public Text policyTitle;
    public Text policyButtonText;
    public Text handOverCodeTitle;
    public Text handOverCodeButtonText;
    public Text handOverDesc;
    public Text copyrightText;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText()
    {
        volcanoTitle.text = textManager.GetLocalizeText("�ΎR");
        volcanoCleared.text = textManager.GetLocalizeText("�N���A�ς�");
        volcanoChallenge.text = textManager.GetLocalizeText("���탌�x��");
        shipTitle.text = textManager.GetLocalizeText("�D");
        shipCleared.text = textManager.GetLocalizeText("�N���A�ς�");
        shipChallenge.text = textManager.GetLocalizeText("���탌�x��");
        forestTitle.text = textManager.GetLocalizeText("�X��");
        forestCleared.text = textManager.GetLocalizeText("�N���A�ς�");
        forestChallenge.text = textManager.GetLocalizeText("���탌�x��");
        bossTitle.text = textManager.GetLocalizeText("�{�X");
        bossCleared.text = textManager.GetLocalizeText("�N���A�ς�");
        bossChallenge.text = textManager.GetLocalizeText("���탌�x��");
        magTitle_1.text = textManager.GetLocalizeText("�{��");
        magTitle_2.text = textManager.GetLocalizeText("�{��");
        bgm.text = textManager.GetLocalizeText("BGM����");
        se.text = textManager.GetLocalizeText("SE����");
        langTitle.text = textManager.GetLocalizeText("����");
        langDesc.text = textManager.GetLocalizeText("OK�������ƌ��ꂪ�؂�ւ��܂��B��x�Q�[���̃g�b�v�ɖ߂�܂��B");
        policyTitle.text = textManager.GetLocalizeText("�v���C�o�V�[�|���V�[");
        policyButtonText.text = textManager.GetLocalizeText("�v���C�o�V�[�|���V�[��Web�T�C�g�Ŋm�F����");
        handOverCodeTitle.text = textManager.GetLocalizeText("�����p���R�[�h");
        handOverCodeButtonText.text = textManager.GetLocalizeText("�R�[�h����");
        handOverDesc.text = textManager.GetLocalizeText("�����p�����@�̐���");
        copyrightText.text = textManager.GetLocalizeText("�R�s�[���C�g��");
    }
}
