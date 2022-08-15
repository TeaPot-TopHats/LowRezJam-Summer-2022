using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator AmogusAnimator;
    [SerializeField] private Animator FireAnimator;
    [SerializeField] private bool faceRight;

    // Update is called once per frame
    public void MovementRender(bool movement)
    {
        AmogusAnimator.SetBool("Moving", movement);
    }

    public void AttackAnim()
    {
        AmogusAnimator.SetTrigger("Attack");
    }
    public void CheckFlip(Rigidbody2D Rigid, Transform Transform)
    {
        if (Rigid.velocity.x < 0 && faceRight)
        {
            faceRight = false;
            Transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        else if (Rigid.velocity.x > 0 && !faceRight)
        {
            faceRight = true;
            Transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }

    }

    public void SetBurnAnim(bool burning)
    {
        FireAnimator.SetBool("Burning", burning);
    }

    public void SetDeath(bool dead)
    {
        AmogusAnimator.SetBool("Dead", dead);
    }

    
}
