using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] int MaxHp = 3;
    private int Hp = 3;
    GameObject gameManager;

    public AudioClip damageSE;
    public AudioClip recoverySE;
    AudioSource audioSource;

    private bool goldAppleGetFlag = false;
    [SerializeField] int invincibleTime;
    int invincibleCnt = 0;

    public Sprite playerSprite_1;
    public Sprite playerSprite_2;


    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        GameObject.Find("HpUI").GetComponent<Text>().text = "×" + Hp;
        audioSource = GetComponent<AudioSource>();

        gameObject.GetComponent<SpriteRenderer>().sprite = playerSprite_1;

        invincibleTime *= 60;
    }

    void Update()
    {
        if(goldAppleGetFlag)
        {
            invincibleCnt++;
            if(invincibleCnt>invincibleTime)
            {
                invincibleCnt = 0;
                goldAppleGetFlag = false;             
                gameObject.GetComponent<SpriteRenderer>().sprite = playerSprite_1;
            }
        }
    }

    public void AddHp(int _point,bool _flag = false)
    {

        // 金リンゴ取った？
        if (goldAppleGetFlag == false && _flag == true)
        {
            goldAppleGetFlag = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprite_2;
        }
        // 金リンゴ食べてない
        if (goldAppleGetFlag==false)
        {
            Hp += _point;
            if (Hp > MaxHp) Hp = MaxHp;
            if (Hp < 0) Hp = 0;

            GameObject.Find("HpUI").GetComponent<Text>().text = "×" + Hp;

            // Hp０で終了処理へ
            if (Hp <= 0)
            {
                gameManager.GetComponent<GameManager>().EndGame();
                Hp = 0;
            }


            // リンゴかダメージかで鳴らすSEを変える
            if (_point > 0)
            {
                // 回復のSE
                audioSource.PlayOneShot(recoverySE);
            }
            else
            {
                // ダメージのSE
                audioSource.PlayOneShot(damageSE);
            }

        }
    }

    public bool GetGoldAppleFlag()
    {
        return goldAppleGetFlag;
    }
}
