using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string playerName;
    public float speed;
    public float health;
    public bool isAlive = true;
    public int numberLives;
    public float jumpingPower = 15f;
    public float dashCooldown = 1f;
    public int currentJumps = 1;
    public int levelUpgrades = 0;
    public bool canFly;

}
