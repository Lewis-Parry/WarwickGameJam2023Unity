using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp: Consumable
{

    public float boost = 10; //speed to boost player to

    protected override IEnumerator effect() { //boosts player to boost speed
        playerStats.health += boost;
        Destroy(gameObject); 
        yield return new WaitForSeconds(duration);
        
    }

    protected override void upgrade(){
        return;
    }

}
