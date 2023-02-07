using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSlam : Consumable
{

    protected override void upgrade() { //increases the number of jumps a player has

        if(playerStats.levelUpgrades == 1){
            playerData.slamUnlocked = true; 
        }
    }

    protected override IEnumerator effect() { //boosts player to boost speed
         gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(duration);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
