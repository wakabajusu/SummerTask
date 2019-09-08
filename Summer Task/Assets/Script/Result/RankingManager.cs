using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class RankingManager : MonoBehaviour
{

    private int nowScore;
    private NCMBObject obj;

    List<string> nameList;
    List<int> scoreList;

    void Start()
    {
        // 現在のゲームのスコア獲得
        nowScore = ScoreManager.GetScore();

        // データ取得
        obj = new NCMBObject("SummerTask");
        LoadFile();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadFile()
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("SummerTask");
        query.OrderByDescending("Score");
        query.Limit = 10; // 上位10件のみ取得
        query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
            if (e == null)
            { //検索成功したら
                nameList = new List<string>(); // 名前のリスト
                scoreList = new List<int>(); // スコアのリスト
                GameObject tmpObj;
                Text tmpText;

                for (int i = 0; i < objList.Count; i++)
                {
                    string s = System.Convert.ToString(objList[i]["Name"]); // 名前を取得
                    int n = System.Convert.ToInt32(objList[i]["Score"]); // スコアを取得
                    nameList.Add(s); // リストに突っ込む
                    scoreList.Add(n);

                    tmpObj = GameObject.Find("No" + (i + 1)); // ランキング表示用のオブジェクト取得

                    // テキストに代入
                    tmpText = tmpObj.GetComponent<Text>();
                    tmpText.text = "No." + (i + 1) + "    " + s + "   " + n;

                }
            }
        });
    }

    public void SaveFile()
    {
        GameObject tmpObj = GameObject.Find("InNameText");

        if(tmpObj.GetComponent<Text>().text == null)
        {
            obj["Name"] = "ナナシ";
        }
        else
        {
            obj["Name"] = tmpObj.GetComponent<Text>().text;
        }
        obj["Score"] = nowScore;
        obj.SaveAsync();

        int tmpCnt = 180;
        while(tmpCnt>0)
        {
            tmpCnt--;
        }

        LoadFile();
    }
}
