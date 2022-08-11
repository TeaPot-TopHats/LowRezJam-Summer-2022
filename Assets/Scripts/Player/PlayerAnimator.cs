using System.Collections;
using System.Collections.Generic;
using Aarthificial.Reanimation;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator Animator;

    public void CheckFlip(Rigidbody2D Rigid, Vector2 MousePosition, SpriteRenderer SpriteRenderer)
    {
        if (MousePosition.x < Rigid.position.x)
            SpriteRenderer.flipX = true;
        else
            SpriteRenderer.flipX = false;

    }

    public void Render(bool movement)
    {
        Animator.SetBool("Moving", movement);
    }

    /*[SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Reanimator Reanimator;
    public bool facing { get; private set; }
    private string driver;

    public void UpdateRenderer(Rigidbody2D Rigid, Vector2 MousePosition, int state)
    {
        Debug.Log("Working");
        SetDriver(state);
        Debug.Log("Working1");
        Reanimator.Flip = CheckFlip(Rigid, MousePosition);
        Debug.Log("Working2");
        Reanimator.Set("State", state);
        Debug.Log("Working3");
        Debug.Log(renderer.sprite.name);

    }


    public bool CheckFlip(Rigidbody2D Rigid, Vector2 MousePosition)
    {
        if (MousePosition.x < Rigid.position.x)
            return true;
        return false;
    }

    private void SetDriver(int state)
    {
        switch (state)
        {
            case 2:
                driver = "Attacking";
                break;
            case 1:
                driver = "Moving";
                break;
            case 0:
                driver = "Idle";
                break;
        }
    }*/

}
