using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerDashCD : Powerup
{
    public float cdr = 0.5f;

    protected override void effect() { //boosts player to boost speed
        playerStats.dashCooldown = playerStats.dashCooldown*cdr; //changes the players speed stat to boost spped
    }
}
