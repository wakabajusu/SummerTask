using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowRankingButtonManager : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource audioSource;
    bool clickF;

    private GameObject panel;
    [SerializeField] float fade_Speed = 0.016f;
    private float now_alpha;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clickF = false;

        panel = GameObject.Find("Panel");
        now_alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (clickF)
        {
            // フェードアウト
            now_alpha += fade_Speed;
            panel.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, now_alpha);
            if (now_alpha >= 1.0f)
            {
                now_alpha = 1.0f;
                SceneManager.LoadScene("Result");
            }

        }
    }

    public void OnClick()
    {
        if (!clickF)
        {
            audioSource.PlayOneShot(audioClip);
            GameObject.Find("TitleManager").GetComponent<TitleManager>().SetBeforScene(0);
            clickF = true;
        }
    }
}
