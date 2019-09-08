using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class ScoreManager : MonoBehaviour
{
    private GameObject      backGround;          // 背景オブジェクト
    private BackGroundManager bgm;               // スクリプト参照
    private GameObject      textObj;             // UIのテキストオブジェクト

    [SerializeField] int    baseAddScore = 100;  // 基本の追加スコア
    [SerializeField] int    baseBonusScore = 50; // 基本のボーナススコア
    public static int       score = 0;           // 現在のスコア
    private Text            score_text;          // スコア表示用
    private int             section_score;         // タロットの変更用
    [SerializeField] int    baseSection = 20000; // タロットを変える区切り
    void Start()
    {
        backGround = GameObject.Find("BackGround");
        bgm = backGround.GetComponent<BackGroundManager>();

        textObj = GameObject.Find("ScoreText");
        score = 0;
    }

    void Update()
    {
        score_text = textObj.GetComponent<Text>();

        // スコア加算
        int tmpScore;

        float bornus = bgm.GetScoreBonus();

        tmpScore = baseAddScore + (int)(baseBonusScore * bornus);

        score += tmpScore ;
        section_score -= tmpScore;

        // テキストの表示を入れ替える
        score_text.text = "Score:" + score;

        if (section_score <= 0)
        {
            section_score = baseSection;
            GameObject.Find("Tarot").GetComponent<TarotManager>().ChangeDifficulty();
        }
    }

    public static int GetScore()
    {
        return score;
    }

    public static void SetScore(int _point)
    {
        score = _point;
    }
}
