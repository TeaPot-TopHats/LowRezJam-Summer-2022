using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        Debug.Log("dash");
        PlayerInput movement = parent.GetComponent<PlayerInput>();
        Debug.Log("dash2");

        Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();
        Debug.Log("dash3");

        rigidbody.velocity = movement.MovementInput.normalized * dashVelocity;
        Debug.Log("dash4");

    }

}
