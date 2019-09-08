using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowGenerator : MonoBehaviour
{
    public GameObject crowPrefab_1;
    public GameObject crowPrefab_2;
    public GameObject crowPrefab_3;
    private GameObject tarotMgr;
    [SerializeField] float span = 3.0f;
    private float delta = 0;
    private float popY = -1.7f;

    void Start()
    {
        tarotMgr = GameObject.Find("Tarot");
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span)
        {
            this.delta = 0;

            int tmplack = (int)tarotMgr.GetComponent<TarotManager>().GetDifficulty();
            
            if (tmplack == 0)
            {
                popY = Random.Range(3, 4);
                GameObject clone = Instantiate(crowPrefab_1) as GameObject;
                clone.transform.position = new Vector3(30, popY, -4);
            }
            if(tmplack == 1)
            {
                popY = Random.Range(2, 3);
                GameObject clone = Instantiate(crowPrefab_2) as GameObject;
                clone.transform.position = new Vector3(30 + popY, popY, -4);
            } 
            if(tmplack == 2)
            {
                popY = Random.Range(-1, 2);
            
                GameObject clone = Instantiate(crowPrefab_3) as GameObject;
                clone.transform.position = new Vector3(30 + popY * 2, popY, -4);
            }

            span = Random.Range(1, 3);

        }
    }
}
