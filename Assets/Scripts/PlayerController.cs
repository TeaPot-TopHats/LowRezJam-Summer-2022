using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private PlayerAction PlayerAction;

    [SerializeField] private Rigidbody2D PlayerRigid;
    [SerializeField] private Rigidbody2D WeaponRigid;

    [SerializeField] public GameObject Projectile;
    [SerializeField] public Transform ProjectileSpawn;

    [SerializeField] private bool moveable;
    [SerializeField] private bool turnable;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireForce;

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
        
    }

    private void FixedUpdate()
    {
        if (moveable)
            PlayerAction.Move(PlayerRigid, PlayerInput.MovementInput, moveSpeed);
        if (turnable)
            PlayerAction.Face(WeaponRigid, PlayerInput.MousePosition);
        if (PlayerInput.attack)
            PlayerAction.Attack(Projectile, ProjectileSpawn, fireForce);
    }
}
