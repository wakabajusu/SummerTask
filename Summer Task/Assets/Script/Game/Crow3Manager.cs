using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow3Manager : MonoBehaviour
{
    private GameObject backGround;          // オブジェクト
    private BackGroundManager bgm;          // スクリプト参照

    public AudioClip audioClip;
    AudioSource audioSource;
    private bool hitF = false;

    private float moveX = 0.05f;
    private float MoveY = -0.05f;

    private bool moveSwitch = false;

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

        // y座標が－１以下なら
        if(transform.position.y < -1)
        {
            // 上に移動
            MoveY *= -1;
        }
        if(transform.position.y>2)
        {
            MoveY *= -1;
        }

        // スクロール
        transform.Translate(-ScrollPow - moveX, MoveY, 0);
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
