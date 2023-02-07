using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix : MonoBehaviour
{

    public GameObject[] respawns;
    public GameObject data1;
    public GameObject data2;
    // Start is called before the first frame update
    void Start()
    {
        respawns = GameObject.FindGameObjectsWithTag("Data");

        if ((respawns.Length == 0)) {
            GameObject Player1Data = Instantiate(data1);
            GameObject Player2Data = Instantiate(data2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
