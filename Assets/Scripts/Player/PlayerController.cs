using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private PlayerAction PlayerAction;
    [SerializeField] private PlayerAnimator PlayerAnimator;

    [SerializeField] private Rigidbody2D PlayerRigid;
    [SerializeField] private Rigidbody2D WeaponRigid;

    [SerializeField] public GameObject Projectile;
    [SerializeField] public Transform ProjectileSpawn;
    [SerializeField] public SpriteRenderer SpriteRenderer;

    [SerializeField] private bool moveable;
    [SerializeField] private bool turnable;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireForce;
    [SerializeField] private int state;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(PlayerRigid);
        Debug.Log(PlayerInput.MousePosition);
        Debug.Log(PlayerInput.CheckMoving());
        Debug.Log(PlayerInput.attack);
        
    }

    private void FixedUpdate()
    {
        if (moveable)
            PlayerAction.Move(PlayerRigid, WeaponRigid, PlayerInput.MovementInput, moveSpeed);
        if (turnable)
            PlayerAction.Face(WeaponRigid, PlayerInput.MousePosition);
        if (PlayerInput.attack)
            PlayerAction.Attack(Projectile, ProjectileSpawn, fireForce);
        PlayerAnimator.CheckFlip(PlayerRigid, PlayerInput.MousePosition, SpriteRenderer);
        PlayerAnimator.Render(PlayerInput.CheckMoving());
    }

    private int SetState(bool moving, bool attacking)
    {
        if (attacking)
            return 2;
        if (moving && moveable)
            return 1;
        return 0;
    }
}
