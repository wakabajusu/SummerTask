using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomGenerator : MonoBehaviour
{
    public GameObject mushroomPrefab_1;
    public GameObject mushroomPrefab_2;
    private GameObject tarotMgr;

    [SerializeField] float span = 3.0f;
    private float delta = 0;
    private float baseY = -1.7f;

    void Start()
    {
        tarotMgr = GameObject.Find("Tarot");
    }

    void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span)
        {
            this.delta = 0;
            this.span = Random.Range(1, 7);
        
            int tmplack = tarotMgr.GetComponent<TarotManager>().GetDifficulty();
        
            if (tmplack <= 1)
            {
                GameObject clone = Instantiate(mushroomPrefab_1) as GameObject;
                clone.transform.position = new Vector3(30, baseY, -4);
            }
            else
            {
                GameObject clone = Instantiate(mushroomPrefab_2) as GameObject;
                clone.transform.position = new Vector3(30, baseY, -4);
            }
        }

        span = Random.Range(2, 3);
    }
}
