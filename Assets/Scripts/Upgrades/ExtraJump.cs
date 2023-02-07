using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraJump : Consumable
{

    protected override void upgrade() { //increases the number of jumps a player has

            playerData.numberJumps += 1; 
            
    }

    protected override IEnumerator effect() { //boosts player to boost speed
        yield return new WaitForSeconds(duration);
    }
}
