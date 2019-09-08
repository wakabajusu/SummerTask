using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonManager : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource audioSource;
    bool clickF;

    [SerializeField] float fadeSpeed;
    private float nowAlpha;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clickF = false;

        nowAlpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(clickF)
        {
            FadeOut();
        }
        else
        {
            if (nowAlpha > 0.0f) FadeIn();
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
            nowAlpha = 1.0f;
            SceneManager.LoadScene("Game");
        }
    }


    public void OnClick()
    {
        if(!clickF)
        {
            audioSource.PlayOneShot(audioClip);
            GameObject.Find("TitleManager").GetComponent<TitleManager>().SetBeforScene(1);
            clickF = true;
        }
    }
}
