using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthUp : Consumable
{

    public float boostAmount;
    protected override void upgrade() { //increases the number of jumps a player has

        if(playerStats.levelUpgrades == 1){
            playerData.maxHealth += boostAmount; 
        }
    }

    protected override IEnumerator effect() { //boosts player to boost speed
        yield return new WaitForSeconds(duration);
    }
}
