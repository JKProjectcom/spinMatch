using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class MoldManager : MonoBehaviour
{
    public List<Sprite> moldSpriteList_2;
    public List<Sprite> moldSpriteList_3;
    public List<Sprite> moldSpriteList_4;
    public List<Sprite> moldSpriteList_5;
    public List<Sprite> moldSpriteList_6;
    public List<Sprite> moldSpriteList_7;
    public List<Sprite> moldSpriteList_8;
    public List<Sprite> moldSpriteList_9;
    public List<Sprite> moldSpriteList_10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // モールドに応じた倍率を返す
    public float GetMoldMagnification(string mold)
    {
        if(mold.IndexOf("2") > -1)
        {
            return 1;
        }
        else if(mold.IndexOf("3")> -1)
        {
            return 1.2f;
        }
        else if (mold.IndexOf("4") > -1)
        {
            return 1.5f;
        }
        else if (mold.IndexOf("5") > -1)
        {
            return 2;
        }
        else if (mold.IndexOf("6") > -1)
        {
            return 2.5f;
        }
        else if (mold.IndexOf("7") > -1)
        {
            return 3;
        }
        else if (mold.IndexOf("8") > -1)
        {
            return 3.5f;
        }
        else if (mold.IndexOf("9") > -1)
        {
            return 4;
        }
        else if (mold.IndexOf("10") > -1)
        {
            return 5;
        }

        return 1;
    }

    // ランダムにモールド名を抽選して返す
    public string GetRandomMoldName()
    {
        // パーツの数でまず抽選
        int partsCount = UnityEngine.Random.Range(2, 11);

        return GetRandomMoldNameByCount(partsCount);
    }

    // ランダムにステージのモールドを抽選して返す
    public string GetRandomStageMoldName(string playerMoldName_1, string playerMoldName_2)
    {
        bool haveMold_2 = playerMoldName_1.Contains("2") || playerMoldName_2.Contains("2");
        bool haveMold_3 = playerMoldName_1.Contains("3") || playerMoldName_2.Contains("3");

        if (haveMold_2 || haveMold_3)
        {
            // パーツが2か3のモールドを装備していればステージはそれ以外から抽選
            // パーツの数でまず抽選
            int partsCount = UnityEngine.Random.Range(4, 11);

            return GetRandomMoldNameByCount(partsCount);
        }
        else
        {
            // パーツ4以上のモールドしか装備していなければステージモールドは2か3から抽選
            int partsCount = UnityEngine.Random.Range(2, 4);

            return GetRandomMoldNameByCount(partsCount);
        }
    }


    public string GetRandomMoldNameByCount(int partsCount)
    {
        var moldList = new List<Sprite>();
        switch (partsCount)
        {
            case 2:
                moldList = moldSpriteList_2;
                break;
            case 3:
                moldList = moldSpriteList_3;
                break;
            case 4:
                moldList = moldSpriteList_4;
                break;
            case 5:
                moldList = moldSpriteList_5;
                break;
            case 6:
                moldList = moldSpriteList_6;
                break;
            case 7:
                moldList = moldSpriteList_7;
                break;
            case 8:
                moldList = moldSpriteList_8;
                break;
            case 9:
                moldList = moldSpriteList_9;
                break;
            case 10:
                moldList = moldSpriteList_10;
                break;
        }

        return moldList[UnityEngine.Random.Range(0, moldList.Count)].name;
    }

    // 引数モールド名からモールドの画像を返す
    public Sprite GetMoldSprite(string moldName)
    {
        switch (moldName)
        {
            case "rod_2":
                return moldSpriteList_2[0];
            case "triangle_2":
                return moldSpriteList_2[1];
            case "square_2":
                return moldSpriteList_2[2];

            case "rod_3":
                return moldSpriteList_3[0];
            case "beak_3":
                return moldSpriteList_3[1];
            case "house_3":
                return moldSpriteList_3[2];

            case "rod_4":
                return moldSpriteList_4[0];
            case "square_4":
                return moldSpriteList_4[1];
            case "fox_4":
                return moldSpriteList_4[2];
            case "triangle_4":
                return moldSpriteList_4[3];
            case "trapezoid_4":
                return moldSpriteList_4[4];
            case "bar_4":
                return moldSpriteList_4[5];
            case "bird_4":
                return moldSpriteList_4[6];

            case "rod_5":
                return moldSpriteList_5[0];
            case "ship_5":
                return moldSpriteList_5[1];
            case "phone_5":
                return moldSpriteList_5[2];
            case "house_5":
                return moldSpriteList_5[3];
            case "boots_5":
                return moldSpriteList_5[4];

            case "rod_6":
                return moldSpriteList_6[0];
            case "rugby_6":
                return moldSpriteList_6[1];
            case "windmill_6":
                return moldSpriteList_6[2];
            case "snake_6":
                return moldSpriteList_6[3];
            case "v_6":
                return moldSpriteList_6[4];

            case "rod_7":
                return moldSpriteList_7[0];
            case "shootingStar_7":
                return moldSpriteList_7[1];
            case "staple_7":
                return moldSpriteList_7[2];
            case "diamond_7":
                return moldSpriteList_7[3];
            case "v_7":
                return moldSpriteList_7[4];

            case "rod_8":
                return moldSpriteList_8[0];
            case "s_8":
                return moldSpriteList_8[1];
            case "hat_8":
                return moldSpriteList_8[2];
            case "snake_8":
                return moldSpriteList_8[3];
            case "square_8":
                return moldSpriteList_8[4];

            case "rod_9":
                return moldSpriteList_9[0];
            case "arch_9":
                return moldSpriteList_9[1];
            case "factory_9":
                return moldSpriteList_9[2];
            case "armani_9":
                return moldSpriteList_9[3];

            case "bison_10":
                return moldSpriteList_10[0];
            case "windmill_10":
                return moldSpriteList_10[1];
            case "snake_10":
                return moldSpriteList_10[2];
            case "plus_10":
                return moldSpriteList_10[3];
            case "y_10":
                return moldSpriteList_10[4];
            case "rugby_10":
                return moldSpriteList_10[5];
        }

        return moldSpriteList_2[0];
    }
    
}
