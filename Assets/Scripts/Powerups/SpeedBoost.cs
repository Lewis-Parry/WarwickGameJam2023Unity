using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Consumable
{

    public float boostSpeed; //speed to boost player to

    protected override IEnumerator effect() { //boosts player to boost speed
        playerStats.speed += boostSpeed; //changes the players speed stat to boost spped
        yield return new WaitForSeconds(duration);
        playerStats.speed -= boostSpeed;
        
    }

    protected override void upgrade(){
        return;
    }

}
