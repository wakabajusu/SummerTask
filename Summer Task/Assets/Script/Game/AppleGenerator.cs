using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{

    public GameObject applePrefab;
    public GameObject goldApplePrefab;
    [SerializeField] float span = 3.0f;
    private float delta = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        if(this.delta>this.span)
        {
            this.delta = 0;
            this.span = Random.Range(1, 7);
            int lack = Random.Range(0, 10);

            if(lack<=3)
            {
                GameObject clone = Instantiate(goldApplePrefab) as GameObject;
                int py = Random.Range(2, 4);
                clone.transform.position = new Vector3(30, py, -3);
            }
            else
            {
                GameObject clone = Instantiate(applePrefab) as GameObject;
                int py = Random.Range(2, 4);
                clone.transform.position = new Vector3(30, py, -3);
            }

            span = Random.Range(0, 3);
        }
    }
}
