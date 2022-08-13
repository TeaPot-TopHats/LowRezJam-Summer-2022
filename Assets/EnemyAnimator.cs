using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private bool faceRight;

    // Update is called once per frame
    public void MovementRender(bool movement)
    {
        Animator.SetBool("Moving", movement);
    }

    public void AttackAnim()
    {
        Animator.SetTrigger("Attack");
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
}
