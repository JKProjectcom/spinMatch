using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SpinManager : MonoBehaviour
{
    public PuzzleMain puzzleMain;
    public SeManager seManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �u���b�N�i�{�^���j���������ꂽ�Ƃ��Ƀp�[�c����]������
    public void Spin()
    {
        if(puzzleMain.puzzleState != "puzzle")
        {
            // �p�Y�����ȊO�����s��
            return;
        }

        seManager.SoundSpinSe();

        int buttonNum = int.Parse(this.gameObject.name);

        // �{�^����̃u���b�N���擾����
        Dictionary<string, GameObject> block = puzzleMain.GetBlock(buttonNum);

        // �p�[�c����]������
        if (block["lr"])
        {
            block["lr"].transform.Rotate(new Vector3(0, 0, -90f), Space.Self);
            block["ul"].transform.Rotate(new Vector3(0, 0, -90f), Space.Self);

            // �ۑ�����
            block["ll"] = block["lr"];
            block["ur"] = block["ul"];
            block["lr"] = null;
            block["ul"] = null;
        }
        else if (block["ll"])
        {
            block["ll"].transform.Rotate(new Vector3(0, 0, -90f), Space.Self);
            block["ur"].transform.Rotate(new Vector3(0, 0, -90f), Space.Self);

            // �ۑ�����
            block["ul"] = block["ll"];
            block["lr"] = block["ur"];
            block["ll"] = null;
            block["ur"] = null;
        }
    }
}
