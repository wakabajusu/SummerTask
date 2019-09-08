using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow1Manager : MonoBehaviour
{
    private GameObject backGround;          // オブジェクト
    private BackGroundManager bgm;          // スクリプト参照

    public AudioClip audioClip;
    AudioSource audioSource;
    private bool hitF = false;

    void Start()
    {
        backGround = GameObject.Find("BackGround");
        bgm = backGround.GetComponent<BackGroundManager>();

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // BackGroundManagerからScrollPowを持ってくる
        float ScrollPow = bgm.GetScrollPow();

        // スクロール
        transform.Translate(-ScrollPow, 0, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hitF)
        {
            GameObject.Find("Player").GetComponent<PlayerStatus>().AddHp(-1);
            GameObject.Find("BackGround").GetComponent<BackGroundManager>().SpeedDown();
            hitF = true;            
        }
    }

    private void OnBecameVisible()
    {
        audioSource.PlayOneShot(audioClip);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
