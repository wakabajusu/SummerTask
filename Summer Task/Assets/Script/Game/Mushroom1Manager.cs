using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom1Manager : MonoBehaviour
{
    private GameObject backGround;          // オブジェクト
    private BackGroundManager bgm;          // スクリプト参照
    private bool hitF = false;

    void Start()
    {
        backGround = GameObject.Find("BackGround");
        bgm = backGround.GetComponent<BackGroundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // BackGroundManagerからScrollPowを持ってくる
        float ScrollPow = bgm.GetScrollPow();

        // スクロール
        transform.Translate(-ScrollPow, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hitF)
        {
            // 当たったら自機のHPをー１
            GameObject.Find("Player").GetComponent<PlayerStatus>().AddHp(-1);
            hitF = true;

        }
    }

    private void OnBecameVisible()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
