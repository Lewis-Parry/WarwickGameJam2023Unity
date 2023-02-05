using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUp : Powerup
{

    public float speedBoost = 0.5f; 

    protected override void effect() { //boosts player to boost speed
        weaponStats.fireRate = weaponStats.fireRate*speedBoost; //changes the players speed stat to boost spped
    }
}
