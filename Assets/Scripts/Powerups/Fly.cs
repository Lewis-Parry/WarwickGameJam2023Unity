using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Consumable
{

    protected override IEnumerator effect() { //boosts player to boost speed
        playerStats.canFly = true;
        yield return new WaitForSeconds(duration);
        playerStats.canFly = false;
        Destroy(gameObject); 
    }

    protected override void upgrade(){
        return;
    }
}
