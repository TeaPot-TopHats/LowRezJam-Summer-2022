using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Health_Upgrade : UpgradeSystem

{
    
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<JSONSavingScript>().myplayer.health += amount;
    }
}//
