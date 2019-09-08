using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    private GameObject backGround;          // オブジェクト
    private BackGroundManager bgm;          // スクリプト参照

    [SerializeField] float AddPow = 0.0f;   // スクロール速度の加算用変数

    // Start is called before the first frame update
    void Start()
    {
        backGround = GameObject.Find("BackGround");
        bgm = backGround.GetComponent<BackGroundManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionStay2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == "Player")
        {
            bgm.AddScrollPow(AddPow);
        }
    }
}
