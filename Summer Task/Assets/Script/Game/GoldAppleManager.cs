using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldAppleManager : MonoBehaviour
{
    private GameObject backGround;          // オブジェクト
    private BackGroundManager bgm;          // スクリプト参照

    void Start()
    {
        backGround = GameObject.Find("BackGround");
        bgm = backGround.GetComponent<BackGroundManager>();
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
        Destroy(gameObject);
        GameObject.Find("Player").GetComponent<PlayerStatus>().AddHp(1,true);
    }

    private void OnBecameVisible()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
