using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sdfzdf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Mute("battleMusic");
        FindObjectOfType<AudioManager>().Play("backRoomsMusic");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
