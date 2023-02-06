using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerDashCD : Consumable
{
    public float cdr = 0.5f;

    protected override IEnumerator effect() { //boosts player to boost speed
        playerStats.dashCooldown = playerStats.dashCooldown*cdr; //changes the players speed stat to boost spped
        yield return new WaitForSeconds(duration);
        playerStats.dashCooldown = playerStats.dashCooldown/cdr;
        Destroy(gameObject); 
    }

    protected override void upgrade(){
        return;
    }
}
