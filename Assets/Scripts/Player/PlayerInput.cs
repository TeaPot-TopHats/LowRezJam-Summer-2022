using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Camera Camera;
    public Vector2 MovementInput { get; private set; }
    public Vector2 MousePosition { get; private set; }
    public bool attack { get; private set; }
    public int state { get; private set; }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        MovementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        attack = Input.GetButton("Fire1");

    }

    public bool CheckMoving()
    {
        if (MovementInput.x != 0 || MovementInput.y != 0)
            return true;
        return false;
    }

    public bool CheckFlip(Rigidbody2D Rigid)
    {
        if (MousePosition.x < Rigid.position.x)
            return true;
        return false;
    }
}
