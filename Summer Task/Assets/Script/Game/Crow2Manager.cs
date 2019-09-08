using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow2Manager : MonoBehaviour
{
    private GameObject backGround;          // オブジェクト
    private BackGroundManager bgm;          // スクリプト参照
    private bool hitF = false;

    public AudioClip audioClip;
    AudioSource audioSource;
    private float moveX = 0.01f;

    void Start()
    {
        backGround = GameObject.Find("BackGround");
        bgm = backGround.GetComponent<BackGroundManager>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // BackGroundManagerからScrollPowを持ってくる
        float ScrollPow = bgm.GetScrollPow();

        // スクロール
        transform.Translate(-ScrollPow - moveX, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hitF)
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
