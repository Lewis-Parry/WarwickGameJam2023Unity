using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraJump : Powerup
{

    protected override void effect() { //increases the number of jumps a player has
        playerStats.numberJumps += 1; 
    }
}
