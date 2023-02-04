using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IWeapon
{
    float strength { get; }
    float weaponCooldown {get;}
    float attackRadius {get;}

}

public class MeleeWeapon : ScriptableObject, IWeapon
{
    public float strength
    {
       get
       {
           return 10f;
       }
    }

    public float weaponCooldown{
        get{
            return 2f;
        }
    }

    public float attackRadius{
        get {
            return 10f;
        }
    }
    
    

}
