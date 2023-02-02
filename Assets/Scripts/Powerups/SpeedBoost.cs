using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Powerup
{

    public float boostSpeed; //speed to boost player to

    protected override void effect() { //boosts player to boost speed
        playerStats.speed = boostSpeed; //changes the players speed stat to boost spped
    }
}
