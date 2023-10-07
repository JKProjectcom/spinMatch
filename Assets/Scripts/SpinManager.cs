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

    // ブロック（ボタン）が押下されたときにパーツを回転させる
    public void Spin()
    {
        if(puzzleMain.puzzleState != "puzzle")
        {
            // パズル時以外押下不可
            return;
        }

        seManager.SoundSpinSe();

        int buttonNum = int.Parse(this.gameObject.name);

        // ボタン上のブロックを取得する
        Dictionary<string, GameObject> block = puzzleMain.GetBlock(buttonNum);

        // パーツを回転させる
        if (block["lr"])
        {
            block["lr"].transform.Rotate(new Vector3(0, 0, -90f), Space.Self);
            block["ul"].transform.Rotate(new Vector3(0, 0, -90f), Space.Self);

            // 保存する
            block["ll"] = block["lr"];
            block["ur"] = block["ul"];
            block["lr"] = null;
            block["ul"] = null;
        }
        else if (block["ll"])
        {
            block["ll"].transform.Rotate(new Vector3(0, 0, -90f), Space.Self);
            block["ur"].transform.Rotate(new Vector3(0, 0, -90f), Space.Self);

            // 保存する
            block["ul"] = block["ll"];
            block["lr"] = block["ur"];
            block["ll"] = null;
            block["ur"] = null;
        }
    }
}
