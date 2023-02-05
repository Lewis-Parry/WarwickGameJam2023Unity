using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : Powerup
{

    protected override void effect() { //extra life
        playerStats.numberLives += 1; 
    }
}
