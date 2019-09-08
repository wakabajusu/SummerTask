using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // ここを見てリザルトのシーンが変わる
    public enum nowScene { Title,Game}  
    public static int beforGameScene;

    private float nowAlpha;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static int GetBeforScene()
    {
        return beforGameScene;
    }

    public void SetBeforScene(int _befor)
    {
        beforGameScene = _befor;
    }
}
