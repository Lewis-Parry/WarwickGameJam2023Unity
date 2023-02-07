using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDash : Consumable
{

    protected override void upgrade() { //increases the number of jumps a player has

            playerData.dashUnlocked = true; 

    }

    protected override IEnumerator effect() { //boosts player to boost speed
    gameObject.GetComponent<SpriteRenderer>().enabled = false;
    
        yield return new WaitForSeconds(duration);
         gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
