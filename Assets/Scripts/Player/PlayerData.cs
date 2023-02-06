using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public int numberJumps;
    public bool dashUnlocked;
    public bool slamUnlocked;
    public bool slamDmgUnlocked;
    public bool dashDmgUnlocked;
    public string playerName;
    public int numberLives;
    public float maxHealh;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
