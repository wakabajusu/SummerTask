using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToTitleButtonManager : MonoBehaviour
{
    private GameObject toTitleObj;
    private Text       toTitleText;
    private bool       saveFlag;
    private bool       fadeOutFlag = false;

    private GameObject resultManObj;

    [SerializeField] float fadeSpeed;
    private float nowAlpha;
    private int nowScore;

    public AudioClip audioClip;
    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        int tmpSwitch = TitleManager.GetBeforScene();

        toTitleObj = GameObject.Find("ToTitleText");
        toTitleText = toTitleObj.GetComponent<Text>();

        nowAlpha = 1.0f;

        nowScore = ScoreManager.GetScore();

        // ゲームシーンから来たら
        if (nowScore != 0)
        {
            toTitleText.text = "保存";
            resultManObj = GameObject.Find("ResultManager");
            saveFlag = false;
        }
        else
        {
            toTitleText.text = "タイトルへ戻る";
            saveFlag = true;
        }
    }

    void Update()
    {
        if(fadeOutFlag)
        {
            FadeOut();
        }
        else
        {
            if (nowAlpha > 0.0f) FadeIn();
        }
    }

    public void OnClick()
    {
        if(saveFlag)
        {
            audioSource.PlayOneShot(audioClip);
            fadeOutFlag = true;
        }
        else
        {
            resultManObj.GetComponent<RankingManager>().SaveFile();
            toTitleText.text = "タイトルへ戻る";
            saveFlag = true;
        }
    }

    // フェードインの処理
    void FadeIn()
    {
        nowAlpha -= fadeSpeed;
        GameObject.Find("Panel").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, nowAlpha);

        // フェードインが終わったらカウントダウンスタート
        if (nowAlpha <= 0.0f) nowAlpha = 0.0f;
    }

    // フェードアウトの処理
    void FadeOut()
    {
        nowAlpha += fadeSpeed;
        GameObject.Find("Panel").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, nowAlpha);
        if (nowAlpha >= 1.0f)
        {
            nowScore = 0;
            ScoreManager.SetScore(0);
            nowAlpha = 1.0f;
            SceneManager.LoadScene("Title");
        }
    }
}
