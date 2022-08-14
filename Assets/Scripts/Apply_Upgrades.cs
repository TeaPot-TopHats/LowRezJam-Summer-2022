using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apply_Upgrades : MonoBehaviour
{
    public UpgradeSystem applyUpgrade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        applyUpgrade.Apply(collision.gameObject);   
    }
}
