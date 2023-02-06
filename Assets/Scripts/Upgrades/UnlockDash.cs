using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDash : Consumable
{

    protected override void upgrade() { //increases the number of jumps a player has

        if(playerStats.levelUpgrades == 0){
            playerData.dashUnlocked = true; 
        }
    }

    protected override IEnumerator effect() { //boosts player to boost speed
        yield return new WaitForSeconds(duration);
    }
}
