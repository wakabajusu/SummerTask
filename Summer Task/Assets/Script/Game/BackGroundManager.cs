using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    private float ScrollPow = 0.2f;        // 初期値 
                                         
    [SerializeField] float Max_Pow = 0.4f; // 速度上限
    [SerializeField] float Min_Pow = 0.1f; // 速度下限


    void Start()
    {
        
    }

    void Update()
    {

    }

    public float GetScrollPow()
    {
        return ScrollPow;
    }

 
    public float GetScoreBonus()
    {
        return (ScrollPow / Max_Pow) * 2.0f;
    }


    public void AddScrollPow(float _pow)
    {
        // 速度加算
        ScrollPow += _pow;

        // 速度制限
        if (ScrollPow > Max_Pow) ScrollPow = Max_Pow;
        if (ScrollPow < Min_Pow) ScrollPow = Min_Pow;
    }

    public void SpeedDown()
    {
        bool tmpFlag = GameObject.Find("Player").GetComponent<PlayerStatus>().GetGoldAppleFlag();

        if(!tmpFlag)
        {
            ScrollPow -= 0.5f;
            if (ScrollPow < Min_Pow) ScrollPow = Min_Pow;
        }
    }

}
