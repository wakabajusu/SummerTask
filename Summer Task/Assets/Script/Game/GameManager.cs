// このスクリプトで、ゲーム開始と終了の処理を行う
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private enum period { FADEIN,COUNTDOWM,PLAYING,STOP,FADEOUT};
    private int now_period;

    [SerializeField] float  fadeSpeed;
    private float           nowAlpha;
    [SerializeField] int    count;
    private Text            tex;
    private GameObject      textObj;   // UIのテキストオブジェクト

    void Start()
    {
        // FPS固定
        Application.targetFrameRate = 60;

        textObj = GameObject.Find("Start And End Text");

        count *= 60;

        now_period = (int)period.FADEIN;
        nowAlpha = 1.0f;
    }


    void Update()
    {
        // ゲーム本編のシーンによって切り替え
        switch (now_period)
        {
            // フェードイン
            case (int)period.FADEIN:
                FadeIn();
                break;

            // カウントダウン
            case (int)period.COUNTDOWM:
                tex = textObj.GetComponent<Text>();

                // 文字描画
                tex.text = "" + (count / 60);

                count--;
                // カウントダウン終了
                if (count / 60 == 0 && count % 60 == 0)
                {
                    // テキスト非表示
                    textObj.GetComponent<Text>().enabled = false;

                    // 各コンポーネントON
                    StartComponent();

                    now_period = (int)period.PLAYING;
                }
                break;

            // Hpが０になったので停止(しばらく[終了]の文字を表示する)
            case (int)period.STOP:
                count--;
                // カウントダウン終了
                if (count / 60 == 0 && count % 60 == 0)
                {
                    now_period = (int)period.FADEOUT;
                }
                break;

            // フェードアウト
            case (int)period.FADEOUT:
                FadeOut();
                break;
        }
    }

    // フェードインの処理
    void FadeIn()
    {
        nowAlpha -= fadeSpeed;
        GameObject.Find("Panel").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, nowAlpha);
        
        // フェードインが終わったらカウントダウンスタート
        if(nowAlpha<=0.0f)
        {
            nowAlpha = 0.0f;
            now_period = (int)period.COUNTDOWM;
        }
    }

    // フェードアウトの処理
    void FadeOut()
    {
        nowAlpha += fadeSpeed;
        GameObject.Find("Panel").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, nowAlpha);
        if (nowAlpha >= 1.0f)
        {
            nowAlpha = 1.0f;
            SceneManager.LoadScene("Result");
        }
    }

    // HPが０になった時にプレイヤーから呼び出す
    public void EndGame()
    {
        // 他のオブジェクトのコンポーネントを停止
        StopComponent();

        now_period = (int)period.STOP;
        count = 180;
        textObj.GetComponent<Text>().enabled = true;
        tex.text = "終了！";
    }


    private void StartComponent()
    {
        // プレイヤー
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerStatus>().enabled = true;

        // 背景
        GameObject.Find("BackGround").GetComponent<BackGroundManager>().enabled = true;
        GameObject.Find("BackGround1").GetComponent<BackGroundController>().enabled = true;
        GameObject.Find("BackGround2").GetComponent<BackGroundController>().enabled = true;

        // スコア
        GameObject.Find("Score").GetComponent<ScoreManager>().enabled = true;

        // 障害物
        GameObject.Find("AppleFactory").GetComponent<AppleGenerator>().enabled = true;
        GameObject.Find("CrowFactory").GetComponent<CrowGenerator>().enabled = true;
        GameObject.Find("MushroomFactory").GetComponent<MushroomGenerator>().enabled = true;        
    }

    void StopComponent()
    {
        // プレイヤー
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerStatus>().enabled = false;

        // 背景
        GameObject.Find("BackGround").GetComponent<BackGroundManager>().enabled = false;
        GameObject.Find("BackGround1").GetComponent<BackGroundController>().enabled = false;
        GameObject.Find("BackGround2").GetComponent<BackGroundController>().enabled = false;

        // スコア
        GameObject.Find("Score").GetComponent<ScoreManager>().enabled = false;

        // 障害物
        GameObject.Find("AppleFactory").GetComponent<AppleGenerator>().enabled = false;
        GameObject.Find("CrowFactory").GetComponent<CrowGenerator>().enabled = false;
        GameObject.Find("MushroomFactory").GetComponent<MushroomGenerator>().enabled = false;    
    }

}
