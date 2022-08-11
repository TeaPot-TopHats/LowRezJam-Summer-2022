using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public void Move(Rigidbody2D Rigid, Rigidbody2D Rigid2, Vector2 Movement, float speed)
    {
        Movement.Normalize();
        Movement *= speed * Time.deltaTime;
        Rigid.velocity = Movement;
        Rigid2.velocity = Movement;
    }

    public void Face(Rigidbody2D Rigid, Vector2 MousePosition)
    {
        Vector2 AimDirection = MousePosition - Rigid.position;
        float aimAngle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg - 90f;
        Rigid.rotation = aimAngle;
    }

    public void Attack(GameObject Projectile, Transform ProjectileSpawn, float fireForce)
    {
        GameObject projectile = Instantiate(Projectile, ProjectileSpawn.position, ProjectileSpawn.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(ProjectileSpawn.up * fireForce, ForceMode2D.Impulse);
        GetComponent<Animator>().SetTrigger("Attack");
    }
}
