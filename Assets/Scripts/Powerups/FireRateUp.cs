using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUp : Consumable
{

    public float speedBoost = 0.5f; 
    

    protected override IEnumerator effect() { //boosts player to boost speed
        weaponStats.fireRate = weaponStats.fireRate*speedBoost; //changes the players speed stat to boost spped
        yield return new WaitForSeconds(duration);
        weaponStats.fireRate = weaponStats.fireRate/speedBoost;
        Destroy(gameObject); 
    }

    protected override void upgrade(){
        return;
    }
}
