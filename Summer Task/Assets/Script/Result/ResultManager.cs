using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    private GameObject texObj;
    private int nowScore;

  
    void Start()
    {
        texObj = GameObject.Find("NowScore");

        nowScore = ScoreManager.GetScore();

        // タイトルから飛んで来たらTrue
        if (nowScore == 0)
        {
            // 現在のスコアを表示
            texObj.GetComponent<Text>().text = "Score : ";
        }
        else
        {
            texObj.GetComponent<Text>().text = "NowScore : " + nowScore;
        }

    }
  
    void Update()
    {

    }
}
