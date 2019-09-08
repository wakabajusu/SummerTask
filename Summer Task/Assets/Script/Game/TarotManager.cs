using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotManager : MonoBehaviour
{
    private int lack;

    public Sprite tarotSprite_1;
    public Sprite tarotSprite_2;
    public Sprite tarotSprite_3;

    private enum Difficulty { EASY,NORMAL,HARD};

    public AudioClip beforSE;
    public AudioClip nowSE;
    AudioSource audioSource;

    // SEの長さ×60の値
    private int rouletteTime = 300;
    private int beforRouletteTime = 120;
    private int nowSePeriod = 0;  // 0は鳴ってない,
    private int seCnt = 0;

    private float fadeSpeed;
    private float nowAlpha = 1.0f;

    void Start()
    {
        lack = (int)Difficulty.EASY;
        audioSource = GetComponent<AudioSource>();
        fadeSpeed = 1.0f / (float)rouletteTime;
    }

    void Update()
    {
        // タロットのルーレット処理
        if(nowSePeriod!=0)
        {
            // ルーレット開始前
            if (nowSePeriod == 1)
            {
                GameObject.Find("Tarot_Roulette_Circle").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                audioSource.PlayOneShot(beforSE);
                nowSePeriod = 2;
            }
            else if(nowSePeriod == 2)
            {
                seCnt++;
                if(seCnt>beforRouletteTime)
                {
                    seCnt = 0;
                    nowSePeriod = 3;
                    audioSource.Stop();
                }
            }
            else if (nowSePeriod == 3)
            {
                audioSource.PlayOneShot(nowSE);
                nowSePeriod = 4;
            }
            else if (nowSePeriod == 4)
            {
                seCnt++;
                nowAlpha -= fadeSpeed;
                if (seCnt > rouletteTime)
                {
                    seCnt = 0;
                    nowSePeriod = 5;
                    audioSource.Stop();
                }
            }
            else if(nowSePeriod==5)
            {
                FinishRoulette();
                audioSource.PlayOneShot(beforSE);
                nowAlpha = 1.0f;
                GameObject.Find("Tarot_Roulette_Circle").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }

            // タロットのアルファ値変更
            GameObject.Find("Tarot").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, nowAlpha);
        }
    }

    private void FinishRoulette()
    {
        int tmpInt = Random.Range(0, 10);
        if (tmpInt < 5)
        {
            lack = (int)Difficulty.NORMAL;
            gameObject.GetComponent<SpriteRenderer>().sprite = tarotSprite_1;
        }
        else if (tmpInt < 8)
        {
            lack = (int)Difficulty.EASY;
            gameObject.GetComponent<SpriteRenderer>().sprite = tarotSprite_2;
        }
        else
        {
            lack = (int)Difficulty.HARD;
            gameObject.GetComponent<SpriteRenderer>().sprite = tarotSprite_3;
        }

        nowSePeriod = 0;

    }

    public int GetDifficulty()
    {
        return lack;
    }

    public void ChangeDifficulty()
    {
        // Roulette開始
        if (nowSePeriod == 0) nowSePeriod = 1;
    }
}
