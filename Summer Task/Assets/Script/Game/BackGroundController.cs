using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private GameObject backGround;                  // オブジェクト用
    private GameObject BackGround_1, BackGround_2;  // スプライト参照
    private float SpriteWidth;                      // スプライトの幅用
    private BackGroundManager bgm;                  // スクリプト参照

    void Start()
    {
        backGround        = GameObject.Find("BackGround");
        this.BackGround_1 = GameObject.Find("BackGround1");
        this.BackGround_2 = GameObject.Find("BackGround2");

        SpriteWidth = BackGround_2.transform.position.x - BackGround_1.transform.position.x;
        bgm = backGround.GetComponent<BackGroundManager>();
    }


    void Update()
    {
        // BackGroundManagerからScrollPowを持ってくる
        float ScrollPow = bgm.GetScrollPow();

        // 背景スクロール
        transform.Translate(-ScrollPow, 0, 0);
        if (transform.position.x < -SpriteWidth)
        {
            transform.position = new Vector3(SpriteWidth, 0, 0);
        }
    }
}
