using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D     rigidBody;
    [SerializeField] float  MovePow_Y = 0.3f;   // 上下の移動速度
    [SerializeField] float  MovePow_X = 0.3f;   // 左右の移動速度

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 ToVec = new Vector2(0,0);

        // 上下左右の移動
        if(Input.GetKey(KeyCode.UpArrow))
        {
            ToVec += new Vector2(0, MovePow_Y);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ToVec += new Vector2(0, -MovePow_Y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ToVec += new Vector2(-MovePow_X,0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ToVec += new Vector2(MovePow_X,0);
        }   


        rigidBody.AddForce(ToVec,ForceMode2D.Force);

    }
}
