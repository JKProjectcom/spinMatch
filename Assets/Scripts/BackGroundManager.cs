using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackGroundManager : MonoBehaviour
{
    public GameObject topBackGroundPanel;
    public Sprite topBackGround_1;
    public Sprite topBackGround_2;

    public float backGroundTime;

    public string currentBackGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        backGroundTime += Time.deltaTime;

        if(backGroundTime > 1)
        {
            if(currentBackGround == "topBackGround_1")
            {
                topBackGroundPanel.GetComponent<Image>().sprite = topBackGround_2;
                currentBackGround = "topBackGround_2";
            }
            else
            {
                topBackGroundPanel.GetComponent<Image>().sprite = topBackGround_1;
                currentBackGround = "topBackGround_1";
            }
            
            backGroundTime = 0;
        }
    }
}
